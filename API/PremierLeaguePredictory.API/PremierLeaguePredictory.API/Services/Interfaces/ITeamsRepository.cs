using PremierLeaguePredictory.API.Models.Domain;

namespace PremierLeaguePredictory.API.Services.Interfaces
{
    public interface ITeamsRepository
    {
        Task<Teams> UpdateAsync(Teams team);

        Task<IEnumerable<Teams>> GetAllAsync();

    }
}
