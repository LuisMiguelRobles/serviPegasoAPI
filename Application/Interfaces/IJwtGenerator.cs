namespace Application.Interfaces
{
    using Domain.Auth;

    public interface IJwtGenerator
    {
        string CreateToken(AppUser user);
    }
}
