using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using iloHealthChecker.Configurations;
using iloHealthChecker.Contracts;
using Newtonsoft.Json;
using NLog;

namespace iloHealthChecker.States.concreteStates
{
    public class Login : State, IServiceProvider
    {
        private readonly Logger _log;
        private readonly string _url;
        private readonly StringContent _stringContent;

        public Login()
        {
            _log = LogManager.GetCurrentClassLogger();
            var loginDetails = ServerConfiguration.GetServerConfiguration().configuration.loginDetails;
            _url = "/json/login_session";
            var loginRequest = new LoginRequest(
                    "login",
                    loginDetails.username,
                    loginDetails.password)
                .ToString();
            _stringContent = new StringContent(loginRequest, Encoding.UTF8, "application/json");
        }

        public override async Task Handle()
        {
            _log.Info($"Logging in to server at {_stateMachine.client.BaseAddress}");
            try
            {
                var response = await _stateMachine.client.PostAsync(_url, _stringContent);
                response.EnsureSuccessStatusCode();
                var responseObj =
                    JsonConvert.DeserializeObject<LoginResponse>(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine("Login success");
                _stateMachine.TransitionTo(new StatusGatherer(responseObj));
            }
            catch (Exception e)
            {
                _stateMachine.TransitionTo(new Failed(e.Message));
            }

            await _stateMachine.Request();
        }

        public object GetService(Type serviceType)
        {
            return new Login();
        }
    }
}