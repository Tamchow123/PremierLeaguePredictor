using System.ComponentModel.DataAnnotations;

namespace PremierLeaguePredictory.API.Models.Domain
{
    public class EndOfSeasonPredictions
    {
        [Key]
        public Guid EndOfSeasonPredictionsId { get; set; }
        public Guid UserId { get; set; }
        public int PredictedPosition { get; set; }
        public int TeamId { get; set; }
        public string Season { get; set; }
    }
}
