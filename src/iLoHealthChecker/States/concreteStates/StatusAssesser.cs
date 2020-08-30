using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using iloHealthChecker.Contracts;

namespace iloHealthChecker.States.concreteStates
{

    public class Statusassesser : State
    {
        private Dictionary<string, string> responseObj;

        public Statusassesser(Dictionary<string, string> responseObj)
        {
            this.responseObj = responseObj;
        }

        public override async Task Handle()
        {
            var failedstatuses = GetFailedStatuses(responseObj);
            if (failedstatuses.Count > 0)
            {
                this._stateMachine.TransitionTo(new EmailSender(string.Join(",", failedstatuses)));
                await this._stateMachine.Request();
            }
            else
            {

                this._stateMachine.TransitionTo(new Completed());
                await this._stateMachine.Request();
            }

        }

        private Dictionary<string, string> GetFailedStatuses(Dictionary<string, string> responseObj)
        {
            var failedstatuses = new Dictionary<string, string>();
            foreach (var status in responseObj)
            {
                if (!HealthSummaryResponse.okStatuses.Contains(status.Value))
                {
                    if (int.TryParse(status.Value, out var result) && result == 0)
                    {
                        continue;
                    }
                    failedstatuses.Add(status.Key, status.Value);
                }
            }
            return failedstatuses;
        }
    }
}