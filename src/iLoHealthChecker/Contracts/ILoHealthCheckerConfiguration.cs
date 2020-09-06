using System.Collections.Generic;

namespace iloHealthChecker.Contracts
{

    public class ILoHealthCheckerConfiguration
    {
        public readonly LoginDetails loginDetails;
        public readonly Smtp smtp;
        public readonly IList<string> okStatuses;

        public ILoHealthCheckerConfiguration(LoginDetails loginDetails, Smtp smtp, IList<string> okStatuses)
        {
            this.loginDetails = loginDetails;
            this.smtp = smtp;
            this.okStatuses = okStatuses;
        }
    }
}