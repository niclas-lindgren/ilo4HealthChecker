using System.Threading.Tasks;

namespace iloHealthChecker.States.concreteStates
{
    class Completed : State
    {
        public override Task Handle()
        {
            return Task.Run(() => { System.Console.WriteLine("Completed"); });
        }
    }
}