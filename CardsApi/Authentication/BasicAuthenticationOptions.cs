using Microsoft.AspNetCore.Authentication;

namespace CardsApi.Authentication
{
    public class BasicAuthenticationOptions: AuthenticationSchemeOptions
    {
        public const string Scheme = "BasicAuthentication";
    }
}
