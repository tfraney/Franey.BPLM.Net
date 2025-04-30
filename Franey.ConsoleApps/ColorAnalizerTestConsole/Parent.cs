using ColorAnalizerCorService;
using ColorAnalizerCorService.ColorValidationServices;
using ColorAnalizerCorService.UnitFactories;
using ColorAnalizerCorServiceAsync;
using ColorAnalizerCorServiceAsync.ColorValidationServices;
using ColorAnalizerCorServiceAsync.UnitFactories;
using Franey.PatternInjector.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ColorPacket = ColorAnalizerCorServiceAsync.ColorPacket;

namespace ColorAnalizerTestConsole;

public static class Parent
{
    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");


        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true)
            .AddJsonFile($"appsettings.{environment}.json", true, true)
            .AddEnvironmentVariables();

        var configurationRoot = builder.Build();


        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((_, config) => { config.AddCommandLine(args); })
            .ConfigureServices((_, services) =>
            {
                var appConfig = configurationRoot.GetSection(nameof(AppConfig)).Get<AppConfig>();
                Console.WriteLine($"Environment: {appConfig?.Environment ?? "Local"}");
                services.AddLogging(logging =>
                {
                    logging.AddConfiguration(configurationRoot.GetSection("Logging"));
                    logging.AddSimpleConsole(options => options.IncludeScopes = true);
                });


                RegisterStrategyWithColorChainFactoriesAsTransient(services);
                RegisterStrategyWithColorChainFactoriesAsScoped(services);
                RegisterStrategyWithColorChainFactoriesAsSingleton(services);
                RegisterStrategyWithColorChainFactoriesAsSingletonAsync(services);
                RegisterStrategyWithColorChainFactoriesAsScopeAsync(services);
                RegisterStrategyWithColorChainFactoriesAsTransientAsync(services);
            });
    }

    public static void RegisterStrategyWithColorChainFactoriesAsSingletonAsync(IServiceCollection services)
    {
        services.AddStrategyAsSingleton<ColorPacket, SingleColorStrategyProviderAsync, NoSingleColorFactoryAsync>()
            .AddAnotherStrategy<AllStrategyProviderAsync, NotAllColorsFactoryAsync>()
            .AddAnotherStrategy<AnyStrategyProviderAsync>()
            .ThenToUnitOfWork<RedUnitServiceAsync, RedColorFactoryAsync>()
            .ThenToUnitOfWork<BlueUnitServiceAsync, BlueColorFactoryAsync>()
            .ThenToUnitOfWork<GreenUnitServiceAsync, GreenColorFactoryAsync>()
            .ThenToUnitOfWork<HotUnitServiceAsync, HotColorFactoryAsync>()
            .ThenToUnitOfWork<CoolUnitServiceAsync, CoolColorFactoryAsync>();
    }


    public static void RegisterStrategyWithColorChainFactoriesAsScopeAsync(IServiceCollection services)
    {
        services
            .AddStrategyAsScoped<ColorPacket, SingleColorStrategyProviderScopedAsync, NoSingleColorScopedFactoryAsync>()
            .AddAnotherStrategy<AllStrategyProviderScopedAsync, NotAllColorsScopedFactoryAsync>()
            .AddAnotherStrategy<AnyStrategyProviderScopedAsync>()
            .ThenToUnitOfWork<RedUnitScopedServiceAsync, RedColorScopedFactoryAsync>()
            .ThenToUnitOfWork<BlueUnitScopedServiceAsync, BlueColorScopedFactoryAsync>()
            .ThenToUnitOfWork<GreenUnitScopedServiceAsync, GreenColorScopedFactoryAsync>()
            .ThenToUnitOfWork<HotUnitScopedServiceAsync, HotColorScopedFactoryAsync>()
            .ThenToUnitOfWork<CoolUnitScopedServiceAsync, CoolColorScopedFactoryAsync>();
    }

    public static void RegisterStrategyWithColorChainFactoriesAsTransientAsync(IServiceCollection services)
    {
        services
            .AddStrategyAsTransient<ColorPacket, SingleColorStrategyProviderTransientAsync,
                NoSingleColorTransientFactoryAsync>()
            .AddAnotherStrategy<AllStrategyProviderTransientAsync, NotAllColorsTransientFactoryAsync>()
            .AddAnotherStrategy<AnyStrategyProviderTransientAsync>()
            .ThenToUnitOfWork<RedUnitTransientServiceAsync, RedColorTransientFactoryAsync>()
            .ThenToUnitOfWork<BlueUnitTransientServiceAsync, BlueColorTransientFactoryAsync>()
            .ThenToUnitOfWork<GreenUnitTransientServiceAsync, GreenColorTransientFactoryAsync>()
            .ThenToUnitOfWork<HotUnitTransientServiceAsync, HotColorTransientFactoryAsync>()
            .ThenToUnitOfWork<CoolUnitTransientServiceAsync, CoolColorTransientFactoryAsync>();
    }

    public static void RegisterStrategyWithColorChainFactoriesAsSingleton(IServiceCollection services)
    {
        services
            .AddStrategyAsSingleton<ColorAnalizerCorService.ColorPacket, SingleColorStrategyProvider,
                NoSingleColorFactory>()
            .AddAnotherStrategy<AllStrategyProvider, NotAllColorsFactory>()
            .AddAnotherStrategy<AnyStrategyProvider>()
            .ThenToUnitOfWork<RedUnitService, RedColorFactory>()
            .ThenToUnitOfWork<BlueUnitService, BlueColorFactory>()
            .ThenToUnitOfWork<GreenUnitService, GreenColorFactory>()
            .ThenToUnitOfWork<HotUnitService, HotColorFactory>()
            .ThenToUnitOfWork<CoolUnitService, CoolColorFactory>();
    }


    public static void RegisterStrategyWithColorChainFactoriesAsScoped(IServiceCollection services)
    {
        services
            .AddStrategyAsScoped<ColorAnalizerCorService.ColorPacket, SingleColorStrategyProviderScoped,
                NoSingleColorScopedFactory>()
            .AddAnotherStrategy<AllStrategyProviderScoped, NotAllColorsScopedFactory>()
            .AddAnotherStrategy<AnyStrategyProviderScoped>()
            .ThenToUnitOfWork<RedUnitScopedService, RedColorScopedFactory>()
            .ThenToUnitOfWork<BlueUnitScopedService, BlueColorScopedFactory>()
            .ThenToUnitOfWork<GreenUnitScopedService, GreenColorScopedFactory>()
            .ThenToUnitOfWork<HotUnitScopedService, HotColorScopedFactory>()
            .ThenToUnitOfWork<CoolUnitScopedService, CoolColorScopedFactory>();
    }

    private static void RegisterStrategyWithColorChainFactoriesAsTransient(IServiceCollection services)
    {
        services
            .AddStrategyAsTransient<ColorAnalizerCorService.ColorPacket, SingleColorStrategyProviderTransient,
                NoSingleColorTransientFactory>()
            .AddAnotherStrategy<AllStrategyProviderTransient, NotAllColorsTransientFactory>()
            .AddAnotherStrategy<AnyStrategyProviderTransient>()
            .ThenToUnitOfWork<RedUnitTransientService, RedColorTransientFactory>()
            .ThenToUnitOfWork<BlueUnitTransientService, BlueColorTransientFactory>()
            .ThenToUnitOfWork<GreenUnitTransientService, GreenColorTransientFactory>()
            .ThenToUnitOfWork<HotUnitTransientService, HotColorTransientFactory>()
            .ThenToUnitOfWork<CoolUnitTransientService, CoolColorTransientFactory>();
    }
}

public class AppConfig
{
    public string? Environment { get; set; }
}