using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.User;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<User> AddUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> DeleteUser(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
            {
                return null;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUser(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public Task<User?> UpdateUser(int id, UpdateUserRequestDto user)
        {
            var existingUser = _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            
            if (existingUser == null)
            {
                return null;
            }

            existingUser.Result.Password = user.Password;
            existingUser.Result.FistName = user.FistName;
            existingUser.Result.LastName = user.LastName;
            existingUser.Result.PhoneNumber = user.PhoneNumber;
            existingUser.Result.Email = user.Email;
            _context.SaveChangesAsync();
            return existingUser;
        }
    }
}