using System.Threading.Tasks;

namespace iloHealthChecker.States.concreteStates
{
    class Failed : State
    {
        private protected string failMessage;
        public Failed(string message)
        {
            this.failMessage = message;
        }
        public override Task Handle()
        {
            return Task.Run(() => { System.Console.WriteLine($"Task failed with message [{failMessage}]"); });
        }
    }
}