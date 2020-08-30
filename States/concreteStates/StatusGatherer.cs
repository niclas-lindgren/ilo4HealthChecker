using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using iloHealthChecker.Contracts;
using Newtonsoft.Json;

namespace iloHealthChecker.States.concreteStates
{
    class StatusGatherer : State
    {

        private LoginResponse responseObj;

        public StatusGatherer(LoginResponse responseObj)
        {
            this.responseObj = responseObj;
        }

        public override async Task Handle()
        {
            try
            {
                string path = $"json/health_summary?null&_={DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}";
                var uri = new Uri(this._stateMachine.client.BaseAddress + path);
                System.Console.WriteLine($"Getting status");
                var request = new HttpRequestMessage()
                {
                    RequestUri = uri,
                    Method = HttpMethod.Get,
                };
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Referrer = new Uri($"{this._stateMachine.serverConfiguration.configuration.loginDetails.url}/html/info_system.html");
                var response = await this._stateMachine.client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var responseObj = JsonConvert.DeserializeObject<HealthSummaryResponse>(responseContent);
                System.Console.WriteLine("Getting status success");
                this._stateMachine.TransitionTo(new Statusassesser(responseObj));
            }
            catch (Exception exception)
            {
                this._stateMachine.TransitionTo(new Failed(exception.Message));
            }
            await this._stateMachine.Request();
        }
    }
}