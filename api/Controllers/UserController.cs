using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.User;
using api.Interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var users = await _userRepository.GetUsers();
            return Ok(users);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDto());
        }
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] AddUserRequestDto userDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = userDto.ToUserFromAddUserRequestDto();
            var newUser = await _userRepository.AddUser(user);
            return CreatedAtAction("GetUser", new { id = newUser.Id }, newUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userRepository.DeleteUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user.ToUserDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserRequestDto userDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedUser = await _userRepository.UpdateUser(id, userDto);

            if (updatedUser == null)
            {
                return NotFound();
            }

            return Ok(updatedUser.ToUserDto());
        }
    }
}