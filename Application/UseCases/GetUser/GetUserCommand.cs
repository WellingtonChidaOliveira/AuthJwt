using MediatR;

namespace Application.UseCases.GetUser
{
    public record class GetUserCommand : IRequest<GetUserCommandResponse>
    {
        public string Email { get; set; } = string.Empty;
    }
}
