using PremierLeaguePredictory.API.Models.Domain;
using PremierLeaguePredictory.API.Services.Interfaces;
using System.Text.Json;

public class ExternalApiService : IExternalApiService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public ExternalApiService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<List<Teams>> FetchTeamsFromApiAsync()
    {
        var apiUrl = "https://api.football-data.org/v4/competitions/PL/teams";
        var apiKey = _configuration["ExternalApi:ApiKey"];

        if (string.IsNullOrEmpty(apiKey))
        {
            throw new Exception("API Key is missing.");
        }

        if (!_httpClient.DefaultRequestHeaders.Contains("X-Auth-Token"))
        {
            _httpClient.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);
        }

        var response = await _httpClient.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();

            // Deserialize to match the JSON structure
            var apiResponse = JsonSerializer.Deserialize<TeamApiResponse>(jsonData);

            if (apiResponse == null || apiResponse.Teams == null)
            {
                throw new Exception("API response is null or does not contain teams.");
            }

            // Map API response to your domain model
            var teams = apiResponse.Teams.Select(apiTeam => new Teams
            {
                Name = apiTeam.Name,
                ShortName = apiTeam.ShortName,
                Logo = apiTeam.Crest,
                Stadium = apiTeam.Venue,
                Manager = apiTeam.Coach?.Name ?? "Unknown",
                Website = apiTeam.Website
            }).ToList();

            return teams;
        }

        throw new Exception($"Failed to fetch teams: {response.StatusCode}");
    }

    public async Task<List<Fixtures>> FetchFixturesFromApiAsync()
    {
        var apiUrl = "https://api.football-data.org/v4/competitions/PL/matches";
        var apiKey = _configuration["ExternalApi:ApiKey"];

        if (string.IsNullOrEmpty(apiKey))
        {
            throw new Exception("API Key is missing.");
        }

        if (!_httpClient.DefaultRequestHeaders.Contains("X-Auth-Token"))
        {
            _httpClient.DefaultRequestHeaders.Add("X-Auth-Token", apiKey);
        }

        var response = await _httpClient.GetAsync(apiUrl);

        if (response.IsSuccessStatusCode)
        {
            var jsonData = await response.Content.ReadAsStringAsync();
            // Deserialize to match the JSON structure
            var apiResponse = JsonSerializer.Deserialize<FixtureApiResponse>(jsonData);
            if (apiResponse == null || apiResponse == null)
            {
                throw new Exception("API response is null or does not contain matches.");
            }
            // Map API response to your domain model
            var fixtures = apiResponse.Fixtures.Select(apiMatch => new Fixtures
            {
                Gameweek = apiMatch.Gameweek,
                KickOff = apiMatch.KickOff,
                HomeTeam = apiMatch.HomeTeam.Name,
                AwayTeam = apiMatch.AwayTeam.Name,
                HomeTeamScore = apiMatch.Score.FullTime.HomeTeamScore,
                AwayTeamScore = apiMatch.Score.FullTime.AwayTeamScore,
                Status = apiMatch.Status,
                Season = apiResponse.Filters.Season, // Accessing season from Filters
                Winner = apiMatch.Score.Winner
            }).ToList();
            return fixtures;
        }

        throw new Exception($"Failed to fetch fixtures: {response.StatusCode}");
    }
}
