using PremierLeaguePredictory.API.Models.Domain;
using PremierLeaguePredictory.API.Models.DTO;

namespace PremierLeaguePredictory.API.Services.Interfaces
{
    public interface ITablePredictionRepository
    {
        Task<EndOfSeasonPredictions> CreateAsync(EndOfSeasonPredictions prediction);
        Task<IEnumerable<TablePredictionResponseDto>> GetByEmailAsync(string userId);
    }
}
