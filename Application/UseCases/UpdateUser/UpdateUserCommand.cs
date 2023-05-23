using Domain.Entities;
using MediatR;

namespace Application.UseCases.UpdateUser
{
    public record class UpdateUserCommand : IRequest<UpdateUserCommandResponse>
    {
        public User User { get; init; }
    }
}
