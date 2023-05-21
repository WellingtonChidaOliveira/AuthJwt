using Application.Abstraction;
using MediatR;

namespace Application.UseCases.Authorization
{

    public class AuthorizationCommandHandler : IRequestHandler<AuthorizationCommand, AuthorizationCommandResponse>
    {
        private readonly IJwtProvider _jwtProvider;
        //private readonly IUserRepository _userRepository;

        public AuthorizationCommandHandler(IJwtProvider jwtProvider)
        {
            _jwtProvider = jwtProvider;
            //_userRepository = userRepository;
        }

        public async Task<AuthorizationCommandResponse> Handle(AuthorizationCommand request, CancellationToken cancellationToken)
        {
            if (request is not null)
            {
                //var user = await _userRepository.GetUser(request.User.Email);
                //if (user is null) return new AuthorizationCommandResponse { Token = null, Message = "Invalid User!" };

                var tokenResult = _jwtProvider.GenerateJwtToken(request.User);
                return new AuthorizationCommandResponse { Token = tokenResult };
            }
            else
            {
                throw new NotImplementedException();
            }
           
            
        }
    }
}
