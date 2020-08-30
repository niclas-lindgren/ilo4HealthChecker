namespace iloHealthChecker.Contracts
{
    public class Smtp
    {
        public readonly string mailserver;
        public readonly int mailport;
        public readonly string username;
        public readonly string password;
        public readonly string mailTo;
        public readonly string mailFrom;
        public readonly string mailSubject;
        public readonly string senderName;
        public readonly string recipientName;

        public Smtp(string mailserver,
                    int mailport,
                    string username,
                    string password,
                    string mailTo,
                    string mailFrom,
                    string mailSubject,
                    string senderName,
                    string recipientName)
        {
            this.mailserver = mailserver;
            this.mailport = mailport;
            this.username = username;
            this.password = password;
            this.mailTo = mailTo;
            this.mailFrom = mailFrom;
            this.mailSubject = mailSubject;
            this.senderName = senderName;
            this.recipientName = recipientName;
        }
    }
}