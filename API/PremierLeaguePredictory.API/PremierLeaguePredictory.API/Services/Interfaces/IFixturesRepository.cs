using PremierLeaguePredictory.API.Models.Domain;

namespace PremierLeaguePredictory.API.Services.Interfaces
{
    public interface IFixturesRepository
    {
        Task<Fixtures> UpdateAsync(Fixtures fixture);

    }
}
