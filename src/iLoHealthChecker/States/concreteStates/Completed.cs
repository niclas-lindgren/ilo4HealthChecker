using System.Threading.Tasks;

namespace iloHealthChecker.States.concreteStates
{
    public class Completed : State
    {
        public override Task Handle()
        {
            return Task.Run(() => { System.Console.WriteLine("Completed"); });
        }
    }
}