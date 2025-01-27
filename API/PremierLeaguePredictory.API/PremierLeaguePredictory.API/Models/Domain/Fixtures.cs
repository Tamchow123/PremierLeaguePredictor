using System.ComponentModel.DataAnnotations;

namespace PremierLeaguePredictory.API.Models.Domain
{
    public class Fixtures
    {
        [Key]
        public Guid FixtureId { get; set; }
        public int Gameweek { get; set; }
        public DateTime KickOff { get; set; }
        public Guid HomeTeamId { get; set; }
        public Guid AwayTeamId { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public string Status { get; set; }
        public string Season { get; set; }
    }
}
