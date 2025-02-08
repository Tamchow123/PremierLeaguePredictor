using Microsoft.EntityFrameworkCore;
using PremierLeaguePredictory.API.Data;
using PremierLeaguePredictory.API.Models.Domain;
using PremierLeaguePredictory.API.Models.DTO;
using PremierLeaguePredictory.API.Services.Interfaces;

namespace PremierLeaguePredictory.API.Services.Implementations
{
    public class TablePredictionRepository : ITablePredictionRepository
    {
        private readonly ApplicationDbContext dbContext;

        public TablePredictionRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<EndOfSeasonPredictions> CreateAsync(EndOfSeasonPredictions prediction)
        {
            await dbContext.EndOfSeasonPredictions.AddAsync(prediction);
            await dbContext.SaveChangesAsync();
            return prediction;
        }

        public async Task<IEnumerable<TablePredictionResponseDto>> GetByEmailAsync(string userId)
        {
            var predictionsWithTeamInfo = await dbContext.EndOfSeasonPredictions
                .Where(pred => pred.UserId == userId) // or check by email -> userId
            .Join(
                    dbContext.Teams,
                    pred => pred.TeamId,
                    team => team.TeamId,
                    (pred, team) => new TablePredictionResponseDto{
                        Position = pred.Position,
                        Season = pred.Season,
                        TeamName = team.Name,
                        Logo = team.Logo
                    }
                )
                .ToListAsync();

            return predictionsWithTeamInfo;

        }
    }
}
