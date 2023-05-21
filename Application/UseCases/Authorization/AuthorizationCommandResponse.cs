using Domain.Entities;
using MediatR;

namespace Application.UseCases.Authorization
{
    public record class AuthorizationCommandResponse : IRequest<Token>
    {
        public Token Token { get; init; }
    }
}
