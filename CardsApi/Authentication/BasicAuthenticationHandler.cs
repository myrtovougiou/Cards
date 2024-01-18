using CardsApi.Abstractions.Services;
using CardsApi.Requests;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace CardsApi.Authentication
{
    public class BasicAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOptions>
    {
        private readonly IUserService _userService;

        public BasicAuthenticationHandler(
            IOptionsMonitor<BasicAuthenticationOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            IUserService userService) 
            : base(options, logger, encoder)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.Fail("Missing Authorization header");
            }

            var authorizationHeader = Request.Headers["Authorization"].ToString();

            if (!authorizationHeader.StartsWith("Basic", StringComparison.OrdinalIgnoreCase))
            {
                return AuthenticateResult.Fail("Authorization header does not start with Basic");
            }

            var authDecoded = Encoding.UTF8.GetString(Convert.FromBase64String(authorizationHeader.Replace("Basic ", "", StringComparison.OrdinalIgnoreCase)));
            var credentials = authDecoded.Split(':', 2);

            var userRequest = new UserRequest
            {
                Email = credentials[0],
                Password = credentials[1]
            };

            var user = await _userService.GetAsync(userRequest);

            if (user == null)
            {
                return AuthenticateResult.Fail("Invalid Username or Password");
            }

            var claims = new[] 
            {
                new Claim(ClaimTypes.Email, user.Email),
            };

            var identity = new ClaimsIdentity(claims, BasicAuthenticationOptions.Scheme);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, BasicAuthenticationOptions.Scheme);

            return AuthenticateResult.Success(ticket);
        }
    }
}
