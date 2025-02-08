using Microsoft.AspNetCore.Identity;
using PremierLeaguePredictory.API.Models.Domain;

namespace PremierLeaguePredictory.API.Services.Interfaces
{
    public interface IUserRepository
    {
        Task<IdentityUser> GetByEmailAsync(string email);

    }
}
