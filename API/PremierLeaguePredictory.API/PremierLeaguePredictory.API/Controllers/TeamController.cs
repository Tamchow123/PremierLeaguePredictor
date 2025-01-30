using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PremierLeaguePredictory.API.Data;
using PremierLeaguePredictory.API.Models.Domain;
using PremierLeaguePredictory.API.Models.DTO;
using PremierLeaguePredictory.API.Services.Interfaces;



namespace PremierLeaguePredictory.API.Controllers
{
    // https://localhost:5193/api/Team
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IExternalApiService externalApiService;
        private readonly ITeamsRepository teamsRepository;


        public TeamController(ApplicationDbContext dbContext, IExternalApiService externalApiService, ITeamsRepository teamsRepository)
        {
            this.dbContext = dbContext;
            this.externalApiService = externalApiService;
            this.teamsRepository = teamsRepository;

        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeams()
        {
            var teams = await teamsRepository.GetAllAsync();

            // Map Domain model to DTO
            var response = new List<TeamDto>();
            foreach (var team in teams)
            {
                response.Add(new TeamDto
                {
                    Name = team.Name,
                    ShortName = team.Name,
                    Logo = team.Logo,
                    Stadium = team.Stadium,
                    Manager = team.Manager,
                    Website = team.Website
                });
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddTeam(CreateTeamRequestDto request)
        {
            var teams = await externalApiService.FetchTeamsFromApiAsync();

            foreach (var team in teams)
            {
                var existingTeam = await dbContext.Teams.FirstOrDefaultAsync(t => t.Name == team.Name);
                if (existingTeam == null)
                {
                    await dbContext.Teams.AddAsync(team);
                }
                else
                {
                    await UpdateTeam(team);
                }
            }

            await dbContext.SaveChangesAsync();

            return Ok(new { message = "Teams added successfully!" });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeam(Teams team)
        {
            var updatedTeam = await teamsRepository.UpdateAsync(team);

            if(updatedTeam is null)
            {
                return NotFound();
            }

            return Ok();
        }

    }
}
