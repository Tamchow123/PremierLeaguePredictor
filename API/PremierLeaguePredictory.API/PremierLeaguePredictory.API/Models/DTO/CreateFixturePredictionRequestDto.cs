namespace PremierLeaguePredictory.API.Models.DTO
{
    public class CreateFixturePredictionRequestDto
    {
        public string Username { get; set; }
        public DateTime KickOff { get; set; }
        public int Gameweek { get; set; }
        public string Season { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int PredictedHomeTeamScore { get; set; }
        public int PredictedAwayTeamScore { get; set; }
    }
}
