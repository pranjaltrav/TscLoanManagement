using TscLoanManagement.TSCDB.Application.DTOs;

namespace TscLoanManagement.TSCDB.Application.Interfaces
{
    public interface IAuthService
    {
        Task<TokenResponseDto> LoginAsync(LoginRequestDto request);
        Task<bool> SendOtpAsync(OtpRequestDto request);
        Task<TokenResponseDto> VerifyOtpAsync(OtpVerificationDto request);
    }
}
