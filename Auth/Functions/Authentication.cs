using System.Net;
using System.Runtime.InteropServices;
using Application.UseCases.Authorization;
using Domain.Entities;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Auth.Functions
{
    public class Authentication
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;

        public Authentication(ILoggerFactory loggerFactory, IMediator mediator)
        {
            _logger = loggerFactory.CreateLogger<Authentication>();
            _mediator = mediator;
        }

        [Function("Authentication")]
        public async Task<AuthorizationCommandResponse> Run([HttpTrigger(AuthorizationLevel.Function, "post", Route = "login/")] HttpRequestData req)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var credentials = JsonConvert.DeserializeObject<User>(requestBody);

            var response = await _mediator.Send( new AuthorizationCommand {User = credentials});
            
            _logger.LogInformation("C# HTTP trigger function processed a request.");


            return response;
        }
    }
}
