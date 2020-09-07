#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iloHealthChecker.Configurations;
using NLog;

namespace iloHealthChecker.States.concreteStates
{
    public class StatusAssesser : State
    {
        private readonly Dictionary<string, string> _responseObj;

        private readonly IList<string> _okStatuses =
            ServerConfiguration.GetInstance().configuration.okStatuses;

        private readonly Logger _log;

        public StatusAssesser(Dictionary<string, string> responseObj)
        {
            _log = LogManager.GetCurrentClassLogger();
            _responseObj = responseObj;
        }

        public override async Task Handle()
        {
            var failedStatuses = GetFailedStatuses(_responseObj);
            if (failedStatuses.Count == 0)
            {
                stateMachine.TransitionTo(new Completed());
                await stateMachine.Request();
                return;
            }

            _log.Warn($"Failed statuses {string.Join(Environment.NewLine, failedStatuses)}");
            stateMachine.TransitionTo(new MailBodyCreator(failedStatuses));
            await stateMachine.Request();
        }

        private Dictionary<string, string> GetFailedStatuses(Dictionary<string, string> ResponseObj)
        {
            var failedStatuses = new Dictionary<string, string>();
            foreach (var (key, value) in ResponseObj.Where(status =>
                !_okStatuses.Contains(status.Value)))
            {
                if (int.TryParse((string?) value, out var result) && result == 0)
                {
                    continue;
                }

                failedStatuses.Add(key, value);
            }

            return failedStatuses;
        }
    }
}