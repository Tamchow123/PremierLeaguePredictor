using Microsoft.EntityFrameworkCore;
using PremierLeaguePredictory.API.Models.Domain;

namespace PremierLeaguePredictory.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<FixturesPredictions> FixturesPredictions { get; set; }
        public DbSet<EndOfSeasonPredictions> EndOfSeasonPredictions { get; set; }
        public DbSet<GoldenBootPredictions> GoldenBootPredictions { get; set; }
        public DbSet<Fixtures> Fixtures { get; set; }
        public DbSet<Teams> Teams { get; set; }
        public DbSet<Table> Table { get; set; }
        public DbSet<GoldenBoot> GoldenBoot { get; set; }
    }
}
