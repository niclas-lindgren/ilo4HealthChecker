using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NLog;

namespace iloHealthChecker.States.concreteStates
{
    public class StatusGatherer : State
    {
        private readonly Logger _log;

        public StatusGatherer()
        {
            _log = LogManager.GetCurrentClassLogger();
        }

        public override async Task Handle()
        {
            try
            {
                var path = $"json/health_summary?null&_={DateTimeOffset.UtcNow.ToUnixTimeMilliseconds()}";
                var uri = new Uri(stateMachine.client.BaseAddress + path);
                _log.Info("Getting status");
                var request = new HttpRequestMessage
                {
                    RequestUri = uri,
                    Method = HttpMethod.Get,
                };
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Headers.Referrer = new Uri($"{stateMachine.serverConfiguration.configuration.loginDetails.url}/html/info_system.html");
                var response = await stateMachine.client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var responseObj = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);
                _log.Info("Getting status success");
                stateMachine.TransitionTo(new StatusAssesser(responseObj));
            }
            catch (Exception exception)
            {
                stateMachine.TransitionTo(new Failed(exception.Message));
            }
            await stateMachine.Request();
        }
    }
}