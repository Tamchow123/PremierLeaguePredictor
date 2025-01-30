namespace PremierLeaguePredictory.API.Models.DTO
{
    public class GetUserRequestDto
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
