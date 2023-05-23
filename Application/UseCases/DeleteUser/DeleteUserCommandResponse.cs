using Domain.Entities;
using MediatR;

namespace Application.UseCases.DeleteUser
{
    public record class DeleteUserCommandResponse 
    {
        public User User { get; init; }
        public string Message { get; init; }
    }
}
