using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PremierLeaguePredictory.API.Data;
using PremierLeaguePredictory.API.Models.Domain;
using PremierLeaguePredictory.API.Models.DTO;



namespace PremierLeaguePredictory.API.Controllers
{
    // https://localhost:5193/api/Team
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public TeamController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddTeam(CreateTeamRequestDto request)
        {
            // Map DTO to Domain Model
            var team = new Teams
            {
                Name = request.Name,
                ShortName = request.ShortName,
                Logo = request.Logo,
                Stadium = request.Stadium,
                Manager = request.Manager,
                Location = request.Location,
                Website = request.Website
            };

            // Add to Database
            await dbContext.Teams.AddAsync(team);
            await dbContext.SaveChangesAsync();

            // Domain Model to DTO
            var response = new TeamDto
            {
                TeamId = team.TeamId,
                Name = team.Name,
                ShortName = team.ShortName,
                Logo = team.Logo,
                Stadium = team.Stadium,
                Manager = team.Manager,
                Location = team.Location,
                Website = team.Website
            };

            return Ok(response);
        }

    }
}
