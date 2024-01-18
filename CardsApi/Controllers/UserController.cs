using CardsApi.Abstractions.Services;
using CardsApi.Requests;
using Microsoft.AspNetCore.Mvc;

namespace CardsApi.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromQuery] UserRequest request,
            CancellationToken token = default)
        {
            var result = await _userService.GetAsync(request, token);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AuthenticateAsync(
            [FromBody] UserRequest request,
            CancellationToken token = default)
        {
            var result = await _userService.AuthenticateAsync(request, token);
            return Ok(result);
        }
    }
}
