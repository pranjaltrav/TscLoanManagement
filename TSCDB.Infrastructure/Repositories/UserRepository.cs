﻿using Microsoft.EntityFrameworkCore;
using TscLoanManagement.TSCDB.Core.Domain.Authentication;
using TscLoanManagement.TSCDB.Core.Interfaces.Repositories;
using TscLoanManagement.TSCDB.Infrastructure.Data.Context;

namespace TscLoanManagement.TSCDB.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(TSCDbContext context) : base(context)
        {
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        //public async Task<User> GetUserByEmailAsync(string email)
        //{
        //    return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        //}

        //public async Task<User> GetUserByPhoneNumberAsync(string phoneNumber)
        //{
        //    return await _context.Users.FirstOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        //}

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
