using System.Runtime.Serialization;

namespace iloHealthChecker.Contracts
{
    [DataContract]
    class LoginResponse
    {
        public readonly string session_Key;
        public readonly string user_Name;
        public readonly string user_Account;
        public readonly string user_Dn;
        public readonly string user_Type;
        public readonly string user_Ip;
        public readonly string user_Expires;
        public readonly string login_Priv;
        public readonly string remote_Cons_Priv;
        public readonly string virtual_Media_Priv;
        public readonly string reset_Priv;
        public readonly string config_Priv;
        public readonly string user_Priv;

        public LoginResponse(
            string session_key,
            string user_name,
            string user_account,
            string user_dn,
            string user_type,
            string user_ip,
            string user_expires,
            string login_priv,
            string remote_cons_priv,
            string virtual_media_priv,
            string reset_priv,
            string config_priv,
            string user_priv
        )
        {
            session_Key = session_key;
            user_Name = user_name;
            user_Account = user_account;
            user_Dn = user_dn;
            user_Type = user_type;
            user_Ip = user_ip;
            user_Expires = user_expires;
            login_Priv = login_priv;
            remote_Cons_Priv = remote_cons_priv;
            virtual_Media_Priv = virtual_media_priv;
            reset_Priv = reset_priv;
            config_Priv = config_priv;
            user_Priv = user_priv;
        }
    }
}