using Domain.Entities;

namespace Application.Abstraction
{
    public interface IJwtProvider
    {
        Token GenerateJwtToken(User user);
    }
}
