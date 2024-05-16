using Microsoft.AspNetCore.Identity;

namespace WebApi03.Repositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser user, List<string> roles);
    }
}