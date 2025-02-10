using PremierLeaguePredictory.API.Models.Domain;
using PremierLeaguePredictory.API.Models.DTO;

namespace PremierLeaguePredictory.API.Services.Interfaces
{
    public interface IFixturePredictionRepository
    {
        Task<FixturesPredictions> CreateAsync(FixturesPredictions fixturesPredictions);

        Task<IEnumerable<FixturePredictionResponseDto>> GetByEmailAsync(string userId);

    }
}
