using PremierLeaguePredictory.API.Models.Domain;
using PremierLeaguePredictory.API.Models.DTO;

namespace PremierLeaguePredictory.API.Services.Interfaces
{
    public interface IFixturesRepository
    {
        Task<Fixtures> UpdateAsync(Fixtures fixture);
        Task<Fixtures> GetFixtureAsync(CreateFixturePredictionRequestDto fixture);

    }
}
