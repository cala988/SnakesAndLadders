using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SnakesAndLadders;
using SnakesAndLadders.Application.Interfaces;
using SnakesAndLadders.Application.Services;

IHost host = Host
    .CreateDefaultBuilder(args)

    .ConfigureServices(services =>
    {
        services.AddTransient<IDieService, DieService>();
        services.AddTransient<IBoardGameService, BoardGameService>();

        services.AddSingleton<IHostedService, ConsoleApp>();
    })
    .Build();

host.RunAsync();