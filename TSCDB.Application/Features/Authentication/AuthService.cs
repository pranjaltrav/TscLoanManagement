using AutoMapper;
using TscLoanManagement.TSCDB.Application.DTOs;
using TscLoanManagement.TSCDB.Application.Interfaces;
using TscLoanManagement.TSCDB.Core.Domain.Authentication;
using TscLoanManagement.TSCDB.Core.Interfaces.Repositories;

namespace TscLoanManagement.TSCDB.Application.Features.Authentication
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;

        public AuthService(IUserRepository userRepository, IMapper mapper, IJwtService jwtService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtService = jwtService;
        }

        public async Task<UserDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (user == null || user.PasswordHash != request.Password || user.UserType != request.UserType)
            {
                throw new ApplicationException("Invalid username or password");
            }

            var userDto = _mapper.Map<UserDto>(user);
            userDto.Token = _jwtService.GenerateToken(user);

            return userDto;
        }

        public async Task<UserDto> RegisterAsync(RegisterRequestDto request)
        {
            var existingUser = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (existingUser != null)
            {
                throw new ApplicationException("Username already exists");
            }

            var newUser = new User
            {
                Username = request.Username,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                PasswordHash = request.Password, // Note: This is using the plain password as in original code
                UserType = request.UserType,
                IsActive = true
            };

            await _userRepository.AddAsync(newUser);
            await _userRepository.SaveChangesAsync();

            var userDto = _mapper.Map<UserDto>(newUser);
            userDto.Token = _jwtService.GenerateToken(newUser);

            return userDto;
        }

        public async Task<UserDto> CreateRepresentativeAsync(CreateRepresentativeDto request)
        {
            var existingUser = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (existingUser != null)
            {
                throw new ApplicationException("Username already exists");
            }

            var newUser = new User
            {
                Username = request.Username,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                PasswordHash = request.Password,
                UserType = "representative",
                IsActive = true
            };

            await _userRepository.AddAsync(newUser);
            await _userRepository.SaveChangesAsync();

            var userDto = _mapper.Map<UserDto>(newUser);
            userDto.Token = _jwtService.GenerateToken(newUser);

            return userDto;
        }

        public async Task<IEnumerable<UserDto>> GetAllRepresentativesAsync()
        {
            var users = await _userRepository.GetAllAsync();
            var reps = users.Where(u => u.UserType == "representative" && u.IsActive);
            return _mapper.Map<IEnumerable<UserDto>>(reps);
        }

        public async Task<UserDto> GetRepresentativeByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null || user.UserType != "representative")
                throw new ApplicationException("Representative not found");

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> UpdateRepresentativeAsync(int id, UpdateRepresentativeDto request)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null || user.UserType != "representative")
                throw new ApplicationException("Representative not found");

            user.Email = request.Email;
            user.PhoneNumber = request.PhoneNumber;
            user.IsActive = request.IsActive;

            await _userRepository.UpdateAsync(user);
            await _userRepository.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> DeleteRepresentativeAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null || user.UserType != "representative")
                return false;

            await _userRepository.DeleteAsync(user);
            await _userRepository.SaveChangesAsync();

            return true;
        }

    }
}
