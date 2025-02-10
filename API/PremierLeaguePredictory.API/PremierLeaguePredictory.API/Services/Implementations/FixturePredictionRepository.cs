using Microsoft.EntityFrameworkCore;
using PremierLeaguePredictory.API.Data;
using PremierLeaguePredictory.API.Models.Domain;
using PremierLeaguePredictory.API.Models.DTO;
using PremierLeaguePredictory.API.Services.Interfaces;

namespace PremierLeaguePredictory.API.Services.Implementations
{
    public class FixturePredictionRepository : IFixturePredictionRepository
    {
        private readonly ApplicationDbContext dbContext;

        public FixturePredictionRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<FixturesPredictions> CreateAsync(FixturesPredictions fixturesPredictions)
        {
            await dbContext.FixturesPredictions.AddAsync(fixturesPredictions);
            await dbContext.SaveChangesAsync();
            return fixturesPredictions;
        }

        public async Task<IEnumerable<FixturePredictionResponseDto>> GetByEmailAsync(string userId)
        {



            var predictionsWithFixturesInfo = await dbContext.FixturesPredictions
    .Where(pred => pred.UserId == userId)
    .Join(
        dbContext.Fixtures,
        pred => pred.FixtureId,
        fixture => fixture.FixtureId,
        (pred, fixture) => new FixturePredictionResponseDto
        {
            Gameweek = fixture.Gameweek,
            KickOff = fixture.KickOff,
            HomeTeam = fixture.HomeTeam,
            AwayTeam = fixture.AwayTeam,
            PredictedHomeTeamScore = pred.PredictedHomeScore,
            PredictedAwayTeamScore = pred.PredictedAwayScore,
            PredictedWinner = pred.PredictedWinner,
            HomeTeamScore = fixture.HomeTeamScore,
            AwayTeamScore = fixture.AwayTeamScore,
            Winner = fixture.Winner,
            Season = fixture.Season,
            Status = fixture.Status
        }
    ).ToListAsync();
            return predictionsWithFixturesInfo;
        }
    }
}
