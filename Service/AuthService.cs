using Firebase.Auth;
using Firebase.Auth.Providers;
using FirebaseAdmin;
using FirebaseAdmin.Auth;
using Newtonsoft.Json.Linq;
using testWebAPI.Dtos.Auth;
using testWebAPI.Dtos.Student;
using testWebAPI.Service.Contract;

namespace testWebAPI.Service
{
    public class AuthService : IAuthService
    {
        private readonly FirebaseApp _firebaseApp;
        private readonly FirebaseAuthClient authProvider;
        private readonly String API_KEY = "FIREBASE_API_KEY";
        private readonly String AUTH_DOMAIN = "AUTH_DOMAIN";

        public AuthService(FirebaseApp firebaseApp)
        {
            _firebaseApp = firebaseApp;

            authProvider = new FirebaseAuthClient(new FirebaseAuthConfig { 
                ApiKey = Environment.GetEnvironmentVariable(API_KEY),
                AuthDomain = Environment.GetEnvironmentVariable(AUTH_DOMAIN),
                Providers =
                [
                    // Add and configure individual providers
                    new GoogleProvider().AddScopes("email"),
                    new EmailProvider()
                ],
            });
        }

        public async Task<ServiceResponse<string>> GetBearerToken(SignInDto inDto)
        {
            ServiceResponse<string> response = new();

            try
            {
                UserCredential userCred = await authProvider.SignInWithEmailAndPasswordAsync(inDto.username, inDto.password);
                String token = await userCred.User.GetIdTokenAsync();

                response.Success = true;
                response.Message = "Ok";
                response.Data = token;
            } catch (Exception ex)
            {
                response.Success = false;
                response.Message = "Error";
                response.Data = "";
                response.ErrorMessages = new List<string> { Convert.ToString(ex.Message) };
            }

            return response;
        }
    }
}
