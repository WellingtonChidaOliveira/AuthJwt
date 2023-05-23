using Application.Abstraction;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var result = await DeleteUser(request.Email);
            if (result is null) return new DeleteUserCommandResponse { User = null, Message = "Fail!"};
            return new DeleteUserCommandResponse { User = result, Message = "Success!"};
        }

        private async Task<User> DeleteUser(string email)
        {
            var result = await _userRepository.GetUser(email);
            if (result is null) return null;
            await _userRepository.DeleteUser(email);
            return result;
        }
    }
}
