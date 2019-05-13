using System.Net;

namespace ClassLibrary3.Components
{
    public class AuthResult
    {
        public AuthResultResponse Response { get; set; }
        public CookieCollection Cookie { get; set; }
    }
    public class AuthResultResponse
    {
        public bool auth { get; set; }
    }
}
