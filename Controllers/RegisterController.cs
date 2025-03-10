using Microsoft.AspNetCore.Mvc;
using YouTube_Clone.DTO;
using YouTube_Clone.Models;
using YouTube_Clone.Service.Interface;

namespace YouTube_Clone.Controllers
{
    public class RegisterController : ControllerBase
    {
        private readonly IUserService _userService;

        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("users/register")]
        public IActionResult Register([FromBody] UserDTO userDTO)
        {
            //Validation
            if (userDTO.Name == null || userDTO.ClerkID == null)
            {
                return BadRequest(new { Message = "Invalid user data" });
            }

            var user = new User
            {
                Name = userDTO.Name,
                ClerkID = userDTO.ClerkID,
                ImageURL = userDTO.ImageURL ?? string.Empty
            };

            _userService.AddUser(user);

            return Ok(new { Message = "User Register successfully !" });
        }

        [HttpGet("users/getAllUser")]
        public IActionResult GetUsers()
        {
            var users = _userService.GetAllUsers();

            if (users == null || !users.Any())
            {
                return NotFound(new { Message = "No users found." });
            }

            return Ok(users);
        }

        [HttpDelete("users/deleteUser/{clerkId}")]
        public async Task<IActionResult> DeleteUser(string clerkId)
        {
            var result = await _userService.DeleteUserAsync(clerkId);
            if (!result)
            {
                return NotFound(new { Message = "User not found" });
            }

            return Ok(new { Message = "User deleted successfully!" });
        }

        [HttpPut("users/updateUser")]
        public async Task<IActionResult> UpdateUser(string clerkId, [FromBody] UpdateUserDTO updateUserDto)
        {
            if (updateUserDto == null || string.IsNullOrWhiteSpace(updateUserDto.Name))
            {
                return BadRequest(new { Message = "Invalid user data" });
            }

            var result = await _userService.UpdateUserAsync(clerkId, updateUserDto);
            if (!result)
            {
                return NotFound(new { Message = "User not found" });
            }

            return Ok(new { Message = "User updated successfully!" });
        }
    }
}

    
