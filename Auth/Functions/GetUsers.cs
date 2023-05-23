using Application.UseCases.CreateUser;
using Application.UseCases.GetUser;
using Auth.Authorization;
using Domain.Entities;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;

namespace Auth.Functions
{
    public class GetUsers
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public GetUsers(ILoggerFactory loggerFactory, IMediator mediator)
        {
            _logger = loggerFactory.CreateLogger<GetUsers>();
            _mediator = mediator;
        }

        [Function("GetUsers")]
        public async Task<GetUserCommandResponse> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "getUsers/")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            _logger.LogInformation("Get Jwt and authenticate");
            var accessToken = AccessTokenResult.ValidateToken(req);
            if (accessToken == null)
            {
                return new GetUserCommandResponse { Message = $"{HttpStatusCode.Unauthorized}" };
            }
            else if (accessToken.Role != Roles.ROLE_ADMIN)
            {
                return new GetUserCommandResponse { Message = $"{HttpStatusCode.Unauthorized}" };
            }

            var requestBody = new StreamReader(req.Body).ReadToEnd();
            var result = JsonConvert.DeserializeObject<User>(requestBody);
            var response = await _mediator.Send(new GetUserCommand { Email = result == null ? null : result.Email });

            return response;

        }
    }
}
