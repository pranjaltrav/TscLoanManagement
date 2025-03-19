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
        public async Task<ActionResult<TokenResponseDto>> Login(LoginRequestDto request)
        {
            try
            {
                var response = await _authService.LoginAsync(request);
                return Ok(response);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("send-otp")]
        public async Task<ActionResult> SendOtp(OtpRequestDto request)
        {
            try
            {
                var result = await _authService.SendOtpAsync(request);
                return Ok(new { success = result });
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("verify-otp")]
        public async Task<ActionResult<TokenResponseDto>> VerifyOtp(OtpVerificationDto request)
        {
            try
            {
                var response = await _authService.VerifyOtpAsync(request);
                return Ok(response);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
