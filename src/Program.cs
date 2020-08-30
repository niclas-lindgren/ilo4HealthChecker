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
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
            var stateMachine = new StateMachine(configuration, new Login());
            await stateMachine.Request();
        }
    }
}

