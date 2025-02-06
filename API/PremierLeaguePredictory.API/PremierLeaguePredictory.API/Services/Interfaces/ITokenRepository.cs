using Microsoft.AspNetCore.Identity;

namespace PremierLeaguePredictory.API.Services.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);

    }
}
