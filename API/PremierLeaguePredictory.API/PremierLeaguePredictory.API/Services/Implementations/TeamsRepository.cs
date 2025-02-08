using Microsoft.EntityFrameworkCore;
using PremierLeaguePredictory.API.Data;
using PremierLeaguePredictory.API.Models.Domain;
using PremierLeaguePredictory.API.Services.Interfaces;

namespace PremierLeaguePredictory.API.Services.Implementations
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly ApplicationDbContext dbContext;

        public TeamsRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Teams>> GetAllAsync()
        {
            return await dbContext.Teams.ToListAsync();
        }

        public async Task<Teams> GetByNameAsync(string teamName)
        {
            var existingTeam = await dbContext.Teams.FirstOrDefaultAsync(t => t.Name == teamName);

            if (existingTeam == null)
            {
                return null;
            }

            return existingTeam;

        }

        public async Task<Teams> UpdateAsync(Teams team)
        {
            var existingTeam = await dbContext.Teams.FirstOrDefaultAsync(x => x.Name == team.Name);

            if (existingTeam == null)
            {
                return null;
            }

            existingTeam.Name = team.Name;
            existingTeam.ShortName = team.ShortName;
            existingTeam.Logo = team.Logo;
            existingTeam.Stadium = team.Stadium;
            existingTeam.Manager = team.Manager;
            existingTeam.Website = team.Website;

            await dbContext.SaveChangesAsync();

            return team;



        }
    }
}
