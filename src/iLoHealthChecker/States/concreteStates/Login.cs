using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using iloHealthChecker.Configurations;
using iloHealthChecker.Contracts;

using Newtonsoft.Json;

namespace iloHealthChecker.States.concreteStates
{
    public class Login : State
    {
        private readonly string url;
        private readonly string loginRequest;
        private readonly StringContent stringContent;

        public Login()
        {
            var loginDetails = ServerConfiguration.GetServerConfiguration().configuration.loginDetails;
            url = $"/json/login_session";
            loginRequest = new LoginRequest(
                "login",
                loginDetails.username,
               loginDetails.password)
                .ToString();
            stringContent = new StringContent(loginRequest, Encoding.UTF8, "application/json");
        }
        public override async Task Handle()
        {
            System.Console.WriteLine($"Logging in to server at {this._stateMachine.client.BaseAddress}");
            try
            {
                var response = await this._stateMachine.client.PostAsync(url, stringContent);
                response.EnsureSuccessStatusCode();
                var responseObj = JsonConvert.DeserializeObject<LoginResponse>(response.Content.ReadAsStringAsync().Result);
                System.Console.WriteLine("Login success");
                this._stateMachine.TransitionTo(new StatusGatherer(responseObj));
            }
            catch (Exception e)
            {
                this._stateMachine.TransitionTo(new Failed(e.Message));
            }
            await this._stateMachine.Request();
        }
    }
}