using System;
namespace BackSecurity.Dto.Authentication
{
    [Serializable]
    public class AuthenticationException : Exception
    {
        public AuthenticationError Error { get; set; }


        public enum AuthenticationError
        {
            UNAUTHENTICATED,
            UNAUTHORIZED
        }

        public AuthenticationException(AuthenticationError authentication)
        {
            Error = authentication;
        }
    }
}

