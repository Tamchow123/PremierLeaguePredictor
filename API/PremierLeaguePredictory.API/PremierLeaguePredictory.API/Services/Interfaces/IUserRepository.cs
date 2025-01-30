using PremierLeaguePredictory.API.Models.Domain;

namespace PremierLeaguePredictory.API.Services.Interfaces
{
    public interface IUserRepository
    {
        Task<Users> CreateUserAsync(Users user);

        Task<Users?> GetByEmailAsync(string email);
    }
}
