using System;
using Microsoft.Extensions.Configuration;

namespace iloHealthChecker
{
    sealed class Properties
    {
        public readonly string username;
        public readonly string password;
        public readonly string serverUrl;
        public Properties(IConfiguration configuration)
        {
            username = Environment.GetEnvironmentVariable("ilo4Username");
            password = Environment.GetEnvironmentVariable("ilo4Password");
            serverUrl = configuration["iloServer:url"];
        }
    }
}