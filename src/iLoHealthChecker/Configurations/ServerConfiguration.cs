
using System.IO;
using iloHealthChecker.Contracts;
using Newtonsoft.Json;

namespace iloHealthChecker.Configurations
{
   public sealed class ServerConfiguration
    {
        private static ServerConfiguration _serverConfiguration;
        public readonly ILoHealthCheckerConfiguration configuration;

        private ServerConfiguration()
        {
            configuration = JsonConvert.DeserializeObject<ILoHealthCheckerConfiguration>(File.ReadAllText("iLoHealthCheckerConfiguration.json"));
        }

        public static ServerConfiguration GetInstance()
        {
            return _serverConfiguration ??= new ServerConfiguration();
        }
    }
}