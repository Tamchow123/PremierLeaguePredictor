using Azure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PremierLeaguePredictory.API.Data;
using PremierLeaguePredictory.API.Models.Domain;
using PremierLeaguePredictory.API.Models.DTO;
using PremierLeaguePredictory.API.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace PremierLeaguePredictory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IUserRepository userRepository;

        public UserController(ApplicationDbContext dbContext, IUserRepository userRepository)
        {
            this.dbContext = dbContext;
            this.userRepository = userRepository;
        }

        private byte[] HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }



        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto request)
        {

            // Hash the password before storing
            var hashedPassword = HashPassword(request.PasswordHash);

            var existingUser = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

            if (existingUser != null)
            {
                return Conflict(new { message = "A user with this email already exists." }); // Return proper HTTP 409 response
            }

            // Convert DTO to domain model
            var user = new Users
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = hashedPassword, // Now correctly using byte[]
                CreatedDate = request.CreatedDate
            };

            user = await userRepository.CreateUserAsync(user);

            // Convert Domain model to DTO
            var response = new UsersDto
            {
                Username = user.Username,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                CreatedDate = user.CreatedDate
            };

            return Ok(response);
        }

        [HttpPost("login")] 
        public async Task<IActionResult> GetUser([FromBody] GetUserRequestDto request)
        {
            var existingUser = await userRepository.GetByEmailAsync(request.Email);

            if (existingUser == null)
            {
                return NotFound(new { message = "User not found." }); // Return proper HTTP 404 response
            }

            var hashedPassword = HashPassword(request.PasswordHash);

            if (!hashedPassword.SequenceEqual(existingUser.PasswordHash))
            {
                return Unauthorized(new
                {
                    message = "Invalid password."
                });
            }


            var response = new 
            {
                Username = existingUser.Username,
                Email = existingUser.Email,
            };

            return Ok(response);
        }


    }
}
