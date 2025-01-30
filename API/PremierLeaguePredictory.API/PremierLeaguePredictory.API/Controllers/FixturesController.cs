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
    public class FixturesController : ControllerBase
    {

        private readonly ApplicationDbContext dbContext;
        private readonly IExternalApiService externalApiService;
        private readonly IFixturesRepository fixturesRepository;

        public FixturesController(ApplicationDbContext dbContext, IExternalApiService externalApiService, IFixturesRepository fixturesRepository)
        {
            this.dbContext = dbContext;
            this.externalApiService = externalApiService;
            this.fixturesRepository = fixturesRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddFixture(CreateFixtureRequestDto request)
        {
            var fixtures = await externalApiService.FetchFixturesFromApiAsync();
            foreach (var fixture in fixtures)
            {
                var existingFixture = await dbContext.Fixtures.FirstOrDefaultAsync(f => f.HomeTeam == fixture.HomeTeam && f.AwayTeam == fixture.AwayTeam && f.Gameweek == fixture.Gameweek);
                if (existingFixture == null)
                {
                    await dbContext.Fixtures.AddAsync(fixture);
                }
                else
                {
                    await UpdateFixture(fixture);
                }
            }
            await dbContext.SaveChangesAsync();
            return Ok(new { message = "Fixtures added successfully!" });
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFixture(Fixtures fixture)
        {
            var updatedFixture = await fixturesRepository.UpdateAsync(fixture);
            if (updatedFixture == null)
            {
                return NotFound();
            }
            return Ok(updatedFixture);
        }

    }
}
