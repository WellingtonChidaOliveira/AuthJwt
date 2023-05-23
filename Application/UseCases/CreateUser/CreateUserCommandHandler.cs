using Application.Abstraction;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<CreateUserCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await CreateUser(request.User);
            if (user is null) return new CreateUserCommandResponse { User = null, Message = "Fail!"};
            return new CreateUserCommandResponse { User = user, Message = "Success!"};
        }

        private async Task<User> CreateUser(User user)
        {
            var result = await _userRepository.GetUser(user.Email);
            if (result is not null) return null;
            await _userRepository.CreateUser(user);
            return user;
        }
    }
}
