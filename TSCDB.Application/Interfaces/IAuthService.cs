﻿using TscLoanManagement.TSCDB.Application.DTOs;

namespace TscLoanManagement.TSCDB.Application.Interfaces
{
    public interface IAuthService
    {
        Task<UserDto> LoginAsync(LoginRequestDto request);
        Task<UserDto> RegisterAsync(RegisterRequestDto request);
        Task<UserDto> CreateRepresentativeAsync(CreateRepresentativeDto request);
        Task<IEnumerable<UserDto>> GetAllRepresentativesAsync();
        Task<UserDto> GetRepresentativeByIdAsync(int id);
        Task<UserDto> UpdateRepresentativeAsync(int id, UpdateRepresentativeDto request);
        Task<bool> DeleteRepresentativeAsync(int id);

    }
}
