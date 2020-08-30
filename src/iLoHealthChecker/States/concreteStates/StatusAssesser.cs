using System.Collections.Generic;
using System.Threading.Tasks;

using iloHealthChecker.Contracts;

namespace iloHealthChecker.States.concreteStates
{

    public class Statusassesser : State
    {
        private HealthSummaryResponse responseObj;

        public Statusassesser(HealthSummaryResponse responseObj)
        {
            this.responseObj = responseObj;
        }

        public override async Task Handle()
        {
            var failedStatuses = GetFailedStatuses();
            if (failedStatuses.Count > 0)
            {
                this._stateMachine.TransitionTo(new EmailSender(string.Join(",", responseObj.ToString())));
                await this._stateMachine.Request();
            }
            else
            {

                this._stateMachine.TransitionTo(new Completed());
                await this._stateMachine.Request();
            }

        }

        private List<string> GetFailedStatuses()
        {
            return new List<string> { "test", "test2" };
        }
    }
}