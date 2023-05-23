using Domain.Entities;
using MediatR;

namespace Application.UseCases.CreateUser
{
    public record class CreateUserCommand : IRequest<CreateUserCommandResponse>
    {
        public User User { get; init; }
    }
}
