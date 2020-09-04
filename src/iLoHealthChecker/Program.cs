using System.Threading.Tasks;

using iloHealthChecker.States;
using iloHealthChecker.States.concreteStates;

using Microsoft.Extensions.Configuration;

namespace iloHealthChecker
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var stateMachine = new StateMachine(new Login());
            await stateMachine.Request();
        }
    }
}

