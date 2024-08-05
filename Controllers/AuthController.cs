using Microsoft.AspNetCore.Mvc;
using testWebAPI.Dtos.Auth;
using testWebAPI.Service.Contract;

namespace testWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController (IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> GetBearerToken(SignInDto inDto)
        {
            var response = await _authService.GetBearerToken(inDto);

            return Ok(response);
        }
    }
}
