using System.ComponentModel.DataAnnotations;

namespace PremierLeaguePredictory.API.Models.Domain
{
    public class FixturesPredictions
    {
        [Key]
        public Guid FixturesPredictionsId { get; set; }
        public Guid UserId { get; set; }
        public Guid FixtureId { get; set; }
        public int PredictedHomeScore { get; set; }
        public int PredictedAwayScore { get; set; }
        public DateTime PredictionDate { get; set; }
    }
}
