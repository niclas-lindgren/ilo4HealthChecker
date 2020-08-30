using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using iloHealthChecker.Configurations;

using Microsoft.Extensions.Configuration;

namespace iloHealthChecker.States
{
    public class StateMachine
    {
        private State _state = null;
        public readonly IConfiguration configuration;
        public readonly ServerConfiguration serverConfiguration;

        public readonly HttpClient client;

        public StateMachine(IConfiguration configuration, State state)
        {
            this.TransitionTo(state);
            this.configuration = configuration;
            this.serverConfiguration = ServerConfiguration.GetServerConfiguration();
            var handler = new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
                CookieContainer = new CookieContainer()
            };
            this.client = new HttpClient(handler);
            this.client.BaseAddress = serverConfiguration.configuration.loginDetails.url;
        }

        public void TransitionTo(State state)
        {
            System.Console.WriteLine($"Transition to state [{state.GetType().Name}]");
            this._state = state;
            this._state.setStateMachine(this);
        }

        public async Task Request()
        {
            await this._state.Handle();
        }
    }
}