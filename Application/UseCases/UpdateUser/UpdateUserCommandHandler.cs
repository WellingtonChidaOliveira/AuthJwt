using Application.Abstraction;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = await UpdateUser(request.User);
            if (response is null) return new UpdateUserCommandResponse { Message = "User not found" };
            return new UpdateUserCommandResponse { Message = "User updated successfully", User = response };
        }

        private async Task<User> UpdateUser(User user)
        {
            var result = await _userRepository.UpdateUser(user);
            if (result is null) return null;
            return result;

        }
    }
}
