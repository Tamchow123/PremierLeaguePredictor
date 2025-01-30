using PremierLeaguePredictory.API.Data;
using PremierLeaguePredictory.API.Models.Domain;
using PremierLeaguePredictory.API.Services.Interfaces;

namespace PremierLeaguePredictory.API.Services.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Users> CreateUserAsync(Users user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }
    }
}
