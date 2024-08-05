using testWebAPI.Dtos.Auth;

namespace testWebAPI.Service.Contract
{
    public interface IAuthService
    {
        /// <summary>
        /// Verifies login with hashed password and username
        /// </summary>
        /// <param name="inDto"></param>
        /// <returns>Bearer token in string form</returns>
        Task<ServiceResponse<String>> GetBearerToken(SignInDto inDto);
    }
}
