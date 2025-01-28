using PremierLeaguePredictory.API.Models.Domain;

namespace PremierLeaguePredictory.API.Services.Interfaces
{
    public interface IExternalApiService
    {
        Task<List<Teams>> FetchTeamsFromApiAsync();
    }
}
