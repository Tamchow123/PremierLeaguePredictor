using System.ComponentModel.DataAnnotations;

namespace PremierLeaguePredictory.API.Models.Domain
{
    public class GoldenBoot
    {
        [Key]
        public Guid GoldenBootId { get; set; }
        public string PlayerName { get; set; }
        public Guid TeamId { get; set; }
        public int Goals { get; set; }
        public string Season { get; set; }
    }
}
