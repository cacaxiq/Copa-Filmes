using System;

namespace CopaFilmes.Api.Security
{
    public class AccessToken
    {
        public AccessToken(bool authenticated, DateTime created, DateTime expiration, string token, string message)
        {
            Authenticated = authenticated;
            Created = created;
            Expiration = expiration;
            Token = token;
            Message = message;
        }

        public AccessToken(bool authenticated, string message)
        {
            Authenticated = authenticated;
            Message = message;
        }

        public bool Authenticated { get; private set; }
        public DateTime Created { get; private set; }
        public DateTime Expiration { get; private set; }
        public string Token { get; private set; }
        public string Message { get; private set; }
    }
}
