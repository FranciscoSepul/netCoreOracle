using System;
namespace BackSecurity.Settings
{
    /**
	 * 
	 * Configuration of security
	 */
    public class SecurityConfig
    {
        /**
		 *
		 * Url of the server for make login
		 */
        public string AuthenticationUrl { get; set; }
        

        public string ResetUrl { get; set; }

        public string ResetKey { get; set; }

        public string ResetIss { get; set; }

        public string ResetAud { get; set; }

        public SecurityConfig()
        {
        }
    }
}

