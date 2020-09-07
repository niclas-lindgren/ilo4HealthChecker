using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iloHealthChecker.States.concreteStates
{
    public class MailBodyCreator : State
    {
        private readonly Dictionary<string, string> _failedStatuses;

        public MailBodyCreator(Dictionary<string, string> failedStatuses)
        {
            _failedStatuses = failedStatuses;
        }

        public override async Task Handle()
        {
            var body = CreateEmailBody();
            stateMachine.TransitionTo(new EmailSender(body));
            await stateMachine.Request();
        }

        private string CreateEmailBody()
        {
            var sb = new StringBuilder();
            foreach (var (key, value) in _failedStatuses)
            {
                sb.Append("<tr>");
                sb.Append($"<td>{key}</td>");
                sb.Append($"<td>{value}</td>");
                sb.Append("</tr>");
            }

            return GetHtmlTemplate().Replace("---status-content---", sb.ToString());
        }

        private static string GetHtmlTemplate()
        {
            return
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?><!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\"\"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\"><html xmlns=\"http://www.w3.org/1999/xhtml\" xml:lang=\"en\" lang=\"en\"><head><title>iLo4 Health Check Report</title></head><body><h4>Below services did not report OK on the iLo status</h4><table><tr><th>Name</th><th>Status</th></tr>---status-content---</table></body></html>";
        }
    }
}