using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TscLoanManagement.TSCDB.Application.DTOs;
using TscLoanManagement.TSCDB.Application.Interfaces;
using TscLoanManagement.TSCDB.Core.Domain.Authentication;
using TscLoanManagement.TSCDB.Core.Interfaces.Repositories;

namespace TscLoanManagement.TSCDB.Application.Features.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly Random _random;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
            _random = new Random();
        }

        public async Task<TokenResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (user == null)
            {
                throw new ApplicationException("Invalid username or password");
            }

            // In a real application, you should use a password hasher to compare passwords
            if (user.PasswordHash != request.Password)
            {
                throw new ApplicationException("Invalid username or password");
            }

            return GenerateJwtToken(user);
        }

        public async Task<bool> SendOtpAsync(OtpRequestDto request)
        {
            // In a real application, you would send an SMS or email with the OTP
            // For this example, we'll just return true
            return true;
        }

        public async Task<TokenResponseDto> VerifyOtpAsync(OtpVerificationDto request)
        {
            // In a real application, you would verify the OTP
            // For this example, we'll just authenticate the user by phone number
            var user = await _userRepository.GetUserByPhoneNumberAsync(request.PhoneNumber);
            if (user == null)
            {
                throw new ApplicationException("User not found");
            }

            return GenerateJwtToken(user);
        }

        private TokenResponseDto GenerateJwtToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.UserType)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(3),
                signingCredentials: credentials);

            return new TokenResponseDto
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = token.ValidTo,
                UserType = user.UserType,
                UserId = user.Id
            };
        }
    }
}
