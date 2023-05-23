using MediatR;

namespace Application.UseCases.DeleteUser
{
    public record class DeleteUserCommand : IRequest<DeleteUserCommandResponse>
    {
        public string Email { get; init; } = string.Empty;
    }
}
