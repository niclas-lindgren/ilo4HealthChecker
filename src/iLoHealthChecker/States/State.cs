using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using iloHealthChecker.Configurations;

namespace iloHealthChecker.States
{
    abstract class State
    {
        protected StateMachine _stateMachine;

        public void setStateMachine(StateMachine machine)
        {
            this._stateMachine = machine;
        }

        public abstract Task Handle();
    }
}