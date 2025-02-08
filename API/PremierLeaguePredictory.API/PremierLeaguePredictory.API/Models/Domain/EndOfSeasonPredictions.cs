using System.ComponentModel.DataAnnotations;

namespace PremierLeaguePredictory.API.Models.Domain
{
    public class EndOfSeasonPredictions
    {
        [Key]
        public Guid EndOfSeasonPredictionsId { get; set; }
        public string UserId { get; set; }
        public int Position { get; set; }
        public Guid TeamId { get; set; }
        public string Season { get; set; }
    }
}
