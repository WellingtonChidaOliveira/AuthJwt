using Application.Abstraction;
using MediatR;

namespace Application.UseCases.Authorization
{

    public class AuthorizationCommandHandler : IRequestHandler<AuthorizationCommand, AuthorizationCommandResponse>
    {
        private readonly IJwtProvider _jwtProvider;
        private readonly IUserRepository _userRepository;

        public AuthorizationCommandHandler(IJwtProvider jwtProvider, IUserRepository userRepository)
        {
            _jwtProvider = jwtProvider;
            _userRepository = userRepository;
        }

        public async Task<AuthorizationCommandResponse> Handle(AuthorizationCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUser(request.User.Email);
            if (user is null) return new AuthorizationCommandResponse { Token = null };

            var tokenResult = _jwtProvider.GenerateJwtToken(user);
            return new AuthorizationCommandResponse { Token = tokenResult };


        }
    }
}
