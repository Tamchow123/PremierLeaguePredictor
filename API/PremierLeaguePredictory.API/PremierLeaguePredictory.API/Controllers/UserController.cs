using Azure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierLeaguePredictory.API.Data;
using PremierLeaguePredictory.API.Models.Domain;
using PremierLeaguePredictory.API.Models.DTO;
using PremierLeaguePredictory.API.Services.Interfaces;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;
using System.Text;
using System.Security.Cryptography;

namespace PremierLeaguePredictory.API.Controllers
{
    // https://localhost:5193/api/User
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

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestDto request)
        {
            // Convert DTO to domain model
            var user = new Users
            {
                Username = request.Username,
                Email = request.Email,
                PasswordHash = request.PasswordHash,
                CreatedDate = DateTime.Now
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

            return Ok();
        }
    }
}
