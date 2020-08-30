using System.Threading.Tasks;

namespace iloHealthChecker.States
{
    public abstract class State
    {
        protected StateMachine _stateMachine;

        public void setStateMachine(StateMachine machine)
        {
            this._stateMachine = machine;
        }

        public abstract Task Handle();
    }
}