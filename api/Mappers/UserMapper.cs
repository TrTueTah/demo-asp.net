using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Models;

namespace api.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User user)
        {
            return new UserDto
            {
                Username = user.Username,
                Password = user.Password,
                FullName = $"{user.FistName} {user.LastName}",
                PhoneNumber = user.PhoneNumber,
                Email = user.Email
            };
        }
        public static User ToUserFromAddUserRequestDto(this AddUserRequestDto addUserRequestDto)
        {
            return new User
            {
                Username = addUserRequestDto.Username,
                Password = addUserRequestDto.Password,
                Email = addUserRequestDto.Email
            };
        }
        public static User ToUserFromUpdateUserRequestDto(this UpdateUserRequestDto updateUserRequestDto)
        {
            return new User
            {
                Password = updateUserRequestDto.Password,
                FistName = updateUserRequestDto.FistName,
                LastName = updateUserRequestDto.LastName,
                PhoneNumber = updateUserRequestDto.PhoneNumber,
                Email = updateUserRequestDto.Email
            };
        }
    }
}