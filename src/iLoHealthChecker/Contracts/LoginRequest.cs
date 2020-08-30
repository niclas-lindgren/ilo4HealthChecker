using Newtonsoft.Json;

namespace iloHealthChecker.Contracts
{
    class LoginRequest
    {
        public readonly string method;
        public readonly string user_login;
        public readonly string password;

        public LoginRequest(
            string method,
            string user_login,
            string password
        )
        {
            this.method = method;
            this.user_login = user_login;
            this.password = password;
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}