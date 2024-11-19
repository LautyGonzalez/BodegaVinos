using BodegaVinos.Entities;
using BodegaVinos.DTOs;
using BodegaVinos.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BodegaVinos.Interfaces.Services;

namespace BodegaVinos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserCreateDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new User
            {
                Username = userDto.Username,
                Password = userDto.Password
            };

            _userService.AddUser(user);

            var responseDto = new UserResponseDto
            {
                Id = user.Id,
                Username = user.Username
            };

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, responseDto);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }

            var userDto = new UserResponseDto
            {
                Id = user.Id,
                Username = user.Username
            };

            return Ok(userDto);
        }
    }
}