using Domain.Entities;
using MediatR;

namespace Application.UseCases.Authorization
{
    public record class AuthorizationCommand : IRequest<AuthorizationCommandResponse>
    {
        public User User { get; init; }
    }
}
