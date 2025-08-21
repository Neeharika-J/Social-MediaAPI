using Asp.Versioning;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMApi.DTO;
using SMApi.Interfaces;
using SMApi.Services;
using SMApi.Validators;

namespace SMApi.Controllers
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [MapToApiVersion("1.0")]
        [HttpPost("createUser")]
        public async Task<ActionResult> createUserAsync(UserCreateDTO userCreateDTO)
        {
            UserValidator validations = new UserValidator();
            ValidationResult validation=validations.Validate(userCreateDTO);
            if (validation.IsValid)
            {
                var (token, expiry) = await userService.createUserAsync(userCreateDTO);
                return Ok(new { Token = token, Expiry = expiry });
            }
            else
            {
                return BadRequest("One or more validation errors");
            }
        }

        [MapToApiVersion("1.0")]
        //[Authorize]
        [HttpGet("getAllUsers")]
        public async Task<ActionResult> getAllUsersAsync()
        {
            IEnumerable<UserReadDTO> dto = await userService.getAllUsersAsync();
            return Ok(dto);
        }

        [MapToApiVersion("1.0")]
        //[Authorize]
        [HttpGet("getUserById")]
        public async Task<ActionResult> getUserByIdAsync(int userid)
        {
            UserReadDTO dto=await userService.getUserByIdAsync(userid);
            return Ok(dto); 
        }

        [MapToApiVersion("1.0")]
        [HttpPost("updateUser")]
        public async Task<IActionResult> updateUserByIdAsync(UserUpdateDTO userUpdateDTO)
        {
            var userdto=await userService.updateUserByIdAsync(userUpdateDTO);
            if (userdto == null)
            {
                return BadRequest("Email already exists.");
            }
            return Ok(userdto);
        }

        [MapToApiVersion("1.0")]
        [HttpPost("Login")]
        public async Task<IActionResult> loginUser(LoginDTO logindto)
        {
            var response=await userService.loginUserAsync(logindto);
            if(response.message.Equals("Login Successful"))
            {
                return Accepted(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [MapToApiVersion("1.0")]
        [HttpPost("deleteUser")]
        public async Task<IActionResult> deleteUser(string email)
        {
            if (email == null)
            {
                return BadRequest(email);
            }
            else
            {
                await userService.deleteUserAsync(email);
                return Ok("User Deleted");
            }
        }

    }
}
