namespace PremierLeaguePredictory.API.Models.DTO
{
    public class CreateTablePredictionRequestDto
    {
        public string Username { get; set; }
        public List<PositionTeamDto> Predictions { get; set; }
    }

    public class PositionTeamDto
    {
        public int Position { get; set; }
        public string Team { get; set; }
    }

}
