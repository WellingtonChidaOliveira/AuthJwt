using Domain.Entities;

namespace Application.UseCases.CreateUser
{
    public record class CreateUserCommandResponse
    {
        public User User { get; init; }
        public string Message { get; init; } = string.Empty;
    }
}
