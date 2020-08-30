using System;

namespace iloHealthChecker.Contracts
{

    public class LoginDetails
    {
        public readonly string username;
        public readonly string password;
        public readonly Uri url;

        public LoginDetails(
                string username,
                string password,
                Uri url
            )
        {
            this.username = username;
            this.password = password;
            this.url = url;
        }
    }
}