using Microsoft.EntityFrameworkCore;
using PremierLeaguePredictory.API.Data;
using PremierLeaguePredictory.API.Models.Domain;
using PremierLeaguePredictory.API.Services.Interfaces;

namespace PremierLeaguePredictory.API.Services.Implementations
{
    public class FixturesRepository : IFixturesRepository
    {
        private readonly ApplicationDbContext dbContext;

        public FixturesRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Fixtures> UpdateAsync(Fixtures fixture)
        {
            var existingFixture = await dbContext.Fixtures.FirstOrDefaultAsync(x => x.HomeTeam == fixture.HomeTeam && x.AwayTeam == fixture.AwayTeam && x.Gameweek == fixture.Gameweek);

            if (existingFixture == null)
            {
                return null;
            }

            existingFixture.HomeTeam = fixture.HomeTeam;
            existingFixture.AwayTeam = fixture.AwayTeam;
            existingFixture.Gameweek = fixture.Gameweek;
            existingFixture.KickOff = fixture.KickOff;
            existingFixture.HomeTeamScore = fixture.HomeTeamScore;
            existingFixture.AwayTeamScore = fixture.AwayTeamScore;
            existingFixture.Status = fixture.Status;
            existingFixture.Season = fixture.Season;
            existingFixture.Winner = fixture.Winner;

            await dbContext.SaveChangesAsync();

            return fixture;


        }
    }
}
