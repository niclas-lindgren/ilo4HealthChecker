using System.Threading.Tasks;
using iloHealthChecker.Configurations;
using iloHealthChecker.Contracts;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;
using NLog;

namespace iloHealthChecker.States.concreteStates
{
    public class EmailSender : State
    {
        private readonly string _message;
        private readonly SmtpClient _client = new SmtpClient();
        private readonly Smtp _smtp = ServerConfiguration.GetInstance().configuration.smtp;
        private readonly Logger _log;

        public EmailSender(string message)
        {
            _message = message;
            _log = LogManager.GetCurrentClassLogger();
        }

        public override async Task Handle()
        {
            Send();
            stateMachine.TransitionTo(new Completed());
            await stateMachine.Request();

        }

        private void Send()
        {
            Connect();
            var mimeMessage = new MimeMessage();
            mimeMessage.To.Add(new MailboxAddress(_smtp.recipientName, _smtp.mailTo));
            mimeMessage.From.Add(new MailboxAddress(_smtp.senderName, _smtp.mailFrom));
            mimeMessage.Subject = _smtp.mailSubject;
            mimeMessage.Body = new TextPart(TextFormat.Html)
            {
                Text = $"<div><pre>{_message}</pre></div>"
            };
            _log.Info("Sending message");
            _client.Send(mimeMessage);
            Disconnect();
        }

        private void Connect()
        {
            _log.Info("Connecting to mailserver");
            _client.Connect(_smtp.mailserver, _smtp.mailport);
            _client.Authenticate(_smtp.username, _smtp.password);
            _log.Info("Connected");
        }

        private void Disconnect()
        {
            _log.Info("Disconnecting from mailserver");
            _client.Disconnect(true);
        }
    }
}