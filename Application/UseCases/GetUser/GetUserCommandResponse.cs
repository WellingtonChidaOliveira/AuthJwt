using Domain.Entities;
using MediatR;

namespace Application.UseCases.GetUser
{
    public record class GetUserCommandResponse 
    {
        public List<User> user { get; init; }
    }
}
