using System.Net;
using Application.UseCases.CreateUser;
using Auth.Authorization;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Auth.Functions
{
    public class CreateUser
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        public CreateUser(ILoggerFactory loggerFactory, IMediator mediator)
        {
            _logger = loggerFactory.CreateLogger<CreateUser>();
            _mediator = mediator;
        }

        [Function("CreateUser")]
        public async Task<CreateUserCommandResponse> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "create/")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var user = JsonConvert.DeserializeObject<User>(requestBody);
            var response = await _mediator.Send(new CreateUserCommand { User = user });


            return response;
        }
    }
}
