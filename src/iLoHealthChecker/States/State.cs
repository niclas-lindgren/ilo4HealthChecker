using System.Threading.Tasks;
using iloHealthChecker.Configurations;

namespace iloHealthChecker.States
{
    public abstract class State
    {
        protected StateMachine stateMachine;

        public void SetStateMachine(StateMachine machine)
        {
            stateMachine = machine;
        }

        public abstract Task Handle();
    }
}