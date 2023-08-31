using System;
using System.Collections.Generic;
using System.Text;

namespace BackSecurity.Settings
{
    public class MailSettings
    {
        public string Host { get; set; }

        public int Port { get; set; }

        public bool UseSsl { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
