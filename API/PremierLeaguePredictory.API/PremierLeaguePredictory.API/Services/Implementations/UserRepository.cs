using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PremierLeaguePredictory.API.Data;
using PremierLeaguePredictory.API.Services.Interfaces;

namespace PremierLeaguePredictory.API.Services.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext dbContext;
        private readonly AuthDbContext authDbContext;

        public UserRepository(ApplicationDbContext dbContext, AuthDbContext authDbContext)
        {
            this.dbContext = dbContext;
            this.authDbContext = authDbContext;
        }

        public async Task<IdentityUser> GetByEmailAsync(string email)
        {
            var existingUser = await authDbContext.Users.FirstOrDefaultAsync(x => x.Email == email);        

            if (existingUser == null)
            {
                return null;
            }

            return existingUser;
        }
    }
}
