using TscLoanManagement.TSCDB.Application.DTOs;

namespace TscLoanManagement.TSCDB.Application.Interfaces
{
    public interface IAuthService
    {
        Task<UserDto> LoginAsync(LoginRequestDto request);
        Task<UserDto> RegisterAsync(RegisterRequestDto request);
    }
}
