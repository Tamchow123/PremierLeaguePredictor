namespace PremierLeaguePredictory.API.Models.DTO
{
    public class FixturePredictionResponseDto
    {
        public int Gameweek { get; set; }
        public DateTime KickOff { get; set; }
        public string HomeTeam { get; set; }
        public string AwayTeam { get; set; }
        public int PredictedHomeTeamScore { get; set; }
        public int PredictedAwayTeamScore { get; set; }
        public string PredictedWinner{ get; set; }
        public int? HomeTeamScore { get; set; }
        public int? AwayTeamScore { get; set; }
        public string? Winner { get; set; }
        public string Season { get; set; }
        public string Status { get; set; }
    }
}
