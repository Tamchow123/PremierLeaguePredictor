namespace PremierLeaguePredictory.API.Models.DTO
{
    public class UsersDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
