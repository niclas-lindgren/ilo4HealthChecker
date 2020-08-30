using System.Runtime.Serialization;

namespace iloHealthChecker.Contracts
{

    public class ILoHealthCheckerConfiguration
    {
        public readonly LoginDetails loginDetails;
        public readonly Smtp smtp;

        public ILoHealthCheckerConfiguration(LoginDetails loginDetails, Smtp smtp)
        {
            this.loginDetails = loginDetails;
            this.smtp = smtp;
        }
    }
}