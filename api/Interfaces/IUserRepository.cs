using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Models;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User?> GetUser(int id);
        Task<User> AddUser(User user);
        Task<User?> UpdateUser(int id, UpdateUserRequestDto userDto);
        Task<User?> DeleteUser(int id);
    }
}