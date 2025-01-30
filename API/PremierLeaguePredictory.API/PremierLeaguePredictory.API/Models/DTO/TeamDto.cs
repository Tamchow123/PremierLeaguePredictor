using System.ComponentModel.DataAnnotations;

namespace PremierLeaguePredictory.API.Models.DTO
{
    public class TeamDto
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Logo { get; set; }
        public string Stadium { get; set; }
        public string Manager { get; set; }
        public string Website { get; set; }
    }
}
