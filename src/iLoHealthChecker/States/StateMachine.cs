using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using iloHealthChecker.Configurations;
using NLog;

namespace iloHealthChecker.States
{
    public class StateMachine
    {
        private readonly Logger _log;
        private State _state;
        public readonly ServerConfiguration serverConfiguration;

        public readonly HttpClient client;

        public StateMachine(State state)
        {
            _log = LogManager.GetCurrentClassLogger();
            TransitionTo(state);
            serverConfiguration = ServerConfiguration.GetServerConfiguration();
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,
                CookieContainer = new CookieContainer()
            };
            client = new HttpClient(handler) {BaseAddress = serverConfiguration.configuration.loginDetails.url};
        }

        public void TransitionTo(State state)
        {
            _log.Info($"Transition to state [{state.GetType().Name}]");
            _state = state;
            _state.setStateMachine(this);
        }

        public async Task Request()
        {
            await _state.Handle();
        }
    }
}