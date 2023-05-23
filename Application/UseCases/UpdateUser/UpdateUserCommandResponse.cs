using Domain.Entities;

namespace Application.UseCases.UpdateUser
{
    public record class UpdateUserCommandResponse
    {
        public string Message { get; init; } = string.Empty;
        public User User { get; init; }
    }
}
