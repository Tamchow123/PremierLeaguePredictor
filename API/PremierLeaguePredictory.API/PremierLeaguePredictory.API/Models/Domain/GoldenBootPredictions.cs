using System.ComponentModel.DataAnnotations;

namespace PremierLeaguePredictory.API.Models.Domain
{
    public class GoldenBootPredictions
    {
        [Key]
        public Guid GoldenBootPredictionsId { get; set; }
        public Guid UserId { get; set; }
        public int PlayerId { get; set; }
        public int Year { get; set; }
    }
}
