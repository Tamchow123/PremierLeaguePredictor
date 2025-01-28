using System.Text.Json.Serialization;

namespace PremierLeaguePredictory.API.Models.Domain
{ 
    public class TeamApiResponse
    {
        [JsonPropertyName("teams")]
        public List<ApiTeam> Teams { get; set; }
    }

    public class ApiTeam
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("shortName")]
        public string ShortName { get; set; }

        [JsonPropertyName("crest")]
        public string Crest { get; set; } // Logo

        [JsonPropertyName("venue")]
        public string Venue { get; set; } // Stadium

        [JsonPropertyName("website")]
        public string Website { get; set; }

        [JsonPropertyName("coach")]
        public ApiCoach Coach { get; set; }
    }


    public class ApiCoach
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }


}
