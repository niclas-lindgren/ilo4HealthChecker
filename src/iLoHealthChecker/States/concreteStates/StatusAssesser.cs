using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iloHealthChecker.Contracts;
using NLog;

namespace iloHealthChecker.States.concreteStates
{
    public class StatusAssesser : State
    {
        private readonly Dictionary<string, string> _responseObj;
        private readonly Logger _log;

        public StatusAssesser(Dictionary<string, string> responseObj)
        {
            _log = LogManager.GetCurrentClassLogger();
            _responseObj = responseObj;
        }

        public override async Task Handle()
        {
            _log.Info($"Statuses: {Environment.NewLine + string.Join(Environment.NewLine, _responseObj)}");
            var failedstatuses = GetFailedStatuses(_responseObj);
            if (failedstatuses.Count > 0)
            {
                _log.Warn($"Failed statuses {string.Join(Environment.NewLine, failedstatuses)}");
                _stateMachine.TransitionTo(new EmailSender(string.Join(",", failedstatuses)));
                await _stateMachine.Request();
            }
            else
            {
                _stateMachine.TransitionTo(new Completed());
                await _stateMachine.Request();
            }
        }

        private static Dictionary<string, string> GetFailedStatuses(Dictionary<string, string> ResponseObj)
        {
            var failedStatuses = new Dictionary<string, string>();
            foreach (var (key, value) in ResponseObj.Where(status =>
                !HealthSummaryResponse.okStatuses.Contains(status.Value)))
            {
                if (int.TryParse(value, out var result) && result == 0)
                {
                    continue;
                }

                failedStatuses.Add(key, value);
            }

            return failedStatuses;
        }
    }
}