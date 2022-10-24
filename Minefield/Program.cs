using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Minefield.core;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddTransient<IGameController, GameController>()
                .AddTransient<IGameEngine, GameEngine>()
                .AddTransient<INavigationService, NavigationService>()
                .AddTransient<IMineService, MineService>())
    .Build();

host.Services.GetRequiredService<IGameController>().Run();