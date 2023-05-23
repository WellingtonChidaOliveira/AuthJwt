using Application.Abstraction;
using Domain.Entities;
using MediatR;

namespace Application.UseCases.GetUser
{
    public class GetUserCommandHandler : IRequestHandler<GetUserCommand, GetUserCommandResponse>
    {
        private readonly IUserRepository _userRepository;

        private List<User> users = new List<User>();

        public GetUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserCommandResponse> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {
            await GetUser(request.Email);
            return  new GetUserCommandResponse { user = users };

        }

        private async Task GetUser(string? user)
        {
            if (user is null)
            { 
               var result = await  _userRepository.GetUsers();
               if (result is null) return;
               users = result;
            }
            else
            {
                var result = await _userRepository.GetUser(user);
                if (result is null) return;
                users.Add(result);
            }
                
        }
    }
}
