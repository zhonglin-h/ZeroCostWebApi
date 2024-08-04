using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;

namespace testWebAPI.Service.Authentication
{
    public class FirebaseAuthenticationFunctionHandler
    {
        private const string BEARER_PREFIX = "Bearer ";

        private readonly FirebaseApp _firebaseApp;

        public FirebaseAuthenticationFunctionHandler(FirebaseApp firebaseApp)
        {
            _firebaseApp = firebaseApp;
        }

        public Task<AuthenticateResult> HandleAuthenticateAsync(HttpRequest request) => HandleAuthenticateAsync(request.HttpContext);

        public async Task<AuthenticateResult> HandleAuthenticateAsync(HttpContext context)
        {
            if (!context.Request.Headers.ContainsKey("Authorization"))
            {
                return AuthenticateResult.NoResult();
            }

            string bearerToken = context.Request.Headers["Authorization"];

            if (bearerToken == null || !bearerToken.StartsWith(BEARER_PREFIX))
                return AuthenticateResult.Fail("Invalid scheme");

            string token = bearerToken.Substring(BEARER_PREFIX.Length);

            try
            {
                FirebaseToken firebaseToken = await FirebaseAuth.GetAuth(_firebaseApp).VerifyIdTokenAsync(token);

                return AuthenticateResult.Success(CreateAuthenticationTicket(firebaseToken));
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException || ex is FirebaseAuthException)
                {
                    return AuthenticateResult.Fail(ex);
                }
                throw;
            }

        }

        private AuthenticationTicket CreateAuthenticationTicket(FirebaseToken token)
        {
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(new List<ClaimsIdentity>()
            {
                new ClaimsIdentity(ToClaims(token.Claims), nameof(ClaimsIdentity))
            });

            return new AuthenticationTicket(claimsPrincipal, JwtBearerDefaults.AuthenticationScheme);
        }

        private IEnumerable<Claim> ToClaims(IReadOnlyDictionary<string, object> claims)
        {
            return new List<Claim>
            {
                new Claim("id", claims.GetValueOrDefault("user_id", "").ToString()),
                new Claim("email", claims.GetValueOrDefault("email", "").ToString()),
                new Claim("email_verified", claims.GetValueOrDefault("email_verified", "").ToString()),
                new Claim("username", claims.GetValueOrDefault("name", "").ToString()),
            };
        }
    }
}
