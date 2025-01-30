namespace PremierLeaguePredictory.API.Models.DTO
{
    public class CreateUserRequestDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
