using System.Threading.Tasks;
using iloHealthChecker.Configurations;
using iloHealthChecker.Contracts;
using MailKit.Net.Smtp;
using MimeKit;
using MimeKit.Text;

namespace iloHealthChecker.States.concreteStates
{
    class EmailSender : State
    {
        private readonly string message;
        private SmtpClient client = new SmtpClient();
        private Smtp smtp = ServerConfiguration.GetServerConfiguration().configuration.smtp;

        public EmailSender(string message)
        {
            this.message = message;
        }

        public override async Task Handle()
        {
            send();
            this._stateMachine.TransitionTo(new Completed());
            await this._stateMachine.Request();

        }

        public void send()
        {
            connect();

            var mimeMessage = new MimeMessage();
            mimeMessage.To.Add(new MailboxAddress(smtp.recipientName, smtp.mailTo));
            mimeMessage.From.Add(new MailboxAddress(smtp.senderName, smtp.mailFrom));
            mimeMessage.Subject = smtp.mailSubject;
            mimeMessage.Body = new TextPart(TextFormat.Html)
            {
                Text = $"<div><pre>{message}</pre></div>"
            };
            client.Send(mimeMessage);
            disconnect();
        }

        private void connect()
        {
            client.Connect(smtp.mailserver, smtp.mailport);
            client.Authenticate(smtp.username, smtp.password);
        }

        private void disconnect()
        {
            client.Disconnect(true);
        }
    }
}