
using curifyapi.Extensions;
using curifyapi.Extensions.Auth;
using curifyapi.Extensions.PasswordHasher;
using curifyapi.Models.DTO;
using curifyapi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace curifyapi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ICreateJwtToken _createJwtToken;

        public UserController(IUnitOfWork unitOfWork, IPasswordHasher passwordHasher, ICreateJwtToken createJwtToken)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _createJwtToken = createJwtToken;
        }



        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetUserByIdAsync(id);

                if (user == null)
                {
                    return NotFound("User not found");
                }
                // Map User entity to UserDto for controlled data exposure
                var userDto = user.MapToDto();

                return Ok(userDto);
            }
            catch (Exception err)
            {
                return StatusCode(500, err.Message);
            }
        }



        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _unitOfWork.UserRepository.GetAllUsersAsync();

                // Map User entities to UserDtos for controlled data exposure
                var userDtos = users.MapToDtos();

                return Ok(userDtos);
            }
            catch (Exception err)
            {
                // Handle exceptions gracefully
                return StatusCode(500, err.Message);
            }
        }



        [HttpPost("Create")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDto request)
        {
            try
            {

                var user = request.MapToUser();
                user.Password = _passwordHasher.Hash(user.Password);

                var createdUser = await _unitOfWork.UserRepository.CreateUserAsync(user);
                await _unitOfWork.SaveChangesAsync();

                // Map created User entity to UserDto for controlled data exposure
                var userDto = createdUser.MapToDto();

                return CreatedAtAction("GetUserById", new { id = createdUser.Id }, userDto);
            }
            catch (Exception err)
            {
                // Handle exceptions gracefully
                return StatusCode(500, err.Message);
            }
        }



        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginDto request)
        {
            try
            {
                // Find the user with the provided email
                var user = await _unitOfWork.UserRepository.LoginUserAsync(request.Email);

                // Temporarily check for password match directly (replace with secure hashing later)
                if (user == null || !_passwordHasher.Verify(request.Password, user.Password))
                {
                    return BadRequest("Invalid credentials");
                }

                // Return successful login response (token generation will be added later)
                user.Token = _createJwtToken.GenerateToken(user);
                return Ok(new
                {
                    Token = user.Token,
                    Message = "Login Success!"
                }); // Temporary placeholder
            }
            catch (Exception err)
            {
                return StatusCode(500, err.Message);
            }
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserDto request)
        {
            try
            {
                // Validate user update data (implementation not shown for brevity)

                var existingUser = await _unitOfWork.UserRepository.GetUserByIdAsync(id);

                if (existingUser == null)
                {
                    return NotFound("User not found");
                }

                // Apply UpdateUserDto properties to existing User entity using extension method
                request.ApplyToUser(existingUser);

                var updatedUser = await _unitOfWork.UserRepository.UpdateUserAsync(id, existingUser);
                await _unitOfWork.SaveChangesAsync();

                // Map updated User entity to UserDto for controlled data exposure
                var userDto = updatedUser.MapToDto();

                return Ok(userDto);
            }
            catch (Exception err)
            {
                // Handle exceptions gracefully
                return StatusCode(500, err.Message);
            }
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var user = await _unitOfWork.UserRepository.GetUserByIdAsync(id);

                if (user == null)
                {
                    return NotFound("User not found");
                }

                await _unitOfWork.UserRepository.DeleteUserAsync(id);
                await _unitOfWork.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception err)
            {
                // Handle exceptions gracefully
                return StatusCode(500, err.Message);
            }
        }


    }
}