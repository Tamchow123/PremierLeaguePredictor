using System.Text.Json.Serialization;
using PremierLeaguePredictory.API.Models.Domain;

namespace PremierLeaguePredictory.API.Models.Domain
{
    public class FixtureApiResponse
    {
        [JsonPropertyName("filters")]
        public ApiFilters Filters { get; set; }
        [JsonPropertyName("resultSet")]
        public ApiResultSet ResultSet { get; set; }
        [JsonPropertyName("competition")]
        public ApiCompetition Competition { get; set; }
        [JsonPropertyName("matches")]
        public List<ApiFixture> Fixtures { get; set; }
    }

    public class ApiFilters
    {
        [JsonPropertyName("season")]
        public string Season { get; set; }
        [JsonPropertyName("matchday")]
        public string Matchday { get; set; }
    }

    public class ApiResultSet
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }
        [JsonPropertyName("first")]
        public string First { get; set; }
        [JsonPropertyName("last")]
        public string Last { get; set; }
        [JsonPropertyName("played")]
        public int Played { get; set; }
    }

    public class ApiCompetition
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("emblem")]
        public string Emblem { get; set; }
    }

    public class ApiFixture
    {
        [JsonPropertyName("area")]
        public ApiArea Area { get; set; }
        [JsonPropertyName("competition")]
        public ApiCompetition Competition { get; set; }
        [JsonPropertyName("season")]
        public ApiSeason Season { get; set; }
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("utcDate")]
        public DateTime KickOff { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("matchday")]
        public int Gameweek { get; set; }
        [JsonPropertyName("stage")]
        public string Stage { get; set; }
        [JsonPropertyName("group")]
        public object Group { get; set; }
        [JsonPropertyName("lastUpdated")]
        public DateTime LastUpdated { get; set; }
        [JsonPropertyName("homeTeam")]
        public ApiTeamFixtures HomeTeam { get; set; }
        [JsonPropertyName("awayTeam")]
        public ApiTeamFixtures AwayTeam { get; set; }
        [JsonPropertyName("score")]
        public ApiScore Score { get; set; }
        [JsonPropertyName("odds")]
        public ApiOdds Odds { get; set; }
        [JsonPropertyName("referees")]
        public List<object> Referees { get; set; }
    }

    public class ApiArea
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("flag")]
        public string Flag { get; set; }
    }


    public class ApiTeamFixtures
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("shortName")]
        public string ShortName { get; set; }
        [JsonPropertyName("tla")]
        public string Tla { get; set; }
        [JsonPropertyName("crest")]
        public string Crest { get; set; }
    }

    public class ApiOdds
    {
        [JsonPropertyName("msg")]
        public string Msg { get; set; }
    }

    public class ApiSeason
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("startDate")]
        public DateTime StartDate { get; set; }
        [JsonPropertyName("endDate")]
        public DateTime EndDate { get; set; }
        [JsonPropertyName("currentMatchday")]
        public int CurrentMatchday { get; set; }
        [JsonPropertyName("winner")]
        public object Winner { get; set; }
    }

    public class ApiScore
    {
        [JsonPropertyName("winner")]
        public string? Winner { get; set; }
        [JsonPropertyName("duration")]
        public string Duration { get; set; }
        [JsonPropertyName("fullTime")]
        public ApiFullTime FullTime { get; set; }
        [JsonPropertyName("halfTime")]
        public ApiHalfTime HalfTime { get; set; }
    }

    public class ApiFullTime
    {
        [JsonPropertyName("home")]
        public int? HomeTeamScore { get; set; }
        [JsonPropertyName("away")]
        public int? AwayTeamScore { get; set; }
    }

    public class ApiHalfTime
    {
        [JsonPropertyName("home")]
        public int? HomeTeamScore { get; set; }
        [JsonPropertyName("away")]
        public int? AwayTeamScore { get; set; }
    }
}