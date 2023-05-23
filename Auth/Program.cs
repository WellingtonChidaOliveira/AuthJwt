using Application.Abstraction;
using Infrastructure.Repositories;
using Infrastructure.Security;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices((appBuilder, services) =>
    {
        var configuration = appBuilder.Configuration;
        var assembly = AppDomain.CurrentDomain.Load("Application");
        services.AddMediatR(assembly);
        services.AddSingleton<IJwtProvider, JwtProvider>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminOnly", policy => policy.RequireRole("admin"));
        });

    })
    .Build();

host.Run();


