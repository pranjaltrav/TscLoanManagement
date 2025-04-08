using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TscLoanManagement.TSCDB.Application.DTOs;
using TscLoanManagement.TSCDB.Application.Interfaces;

namespace TscLoanManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginRequestDto request)
        {
            try
            {
                var user = await _authService.LoginAsync(request);
                return Ok(user);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterRequestDto request)
        {
            try
            {
                var user = await _authService.RegisterAsync(request);
                return CreatedAtAction(nameof(Login), new { username = user.Username }, user);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("add-representative")]
        //[Authorize(Roles = "Admin")] // make sure role-based auth is in place
        public async Task<ActionResult<UserDto>> AddRepresentative(CreateRepresentativeDto request)
        {
            try
            {
                var user = await _authService.CreateRepresentativeAsync(request);
                return CreatedAtAction(nameof(Login), new { username = user.Username }, user);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

    }
}
