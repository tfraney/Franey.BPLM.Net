using Franey.BPS.Net.Factories;
using Franey.BPS.Net.Strategies;
using Franey.BPUL.Net;
using Franey.BPUL.Net.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Franey.PatternInjector.Net;



internal class ServiceCollectionScoped<TPacket, TStrategy> : IServiceCollection<TPacket>
    where TPacket : IPacket
    where TStrategy : ChainStrategyProvider<TPacket>
{
    public ServiceCollectionScoped(IServiceCollection services)
    {
        ToServices = services;
        StartRegistration();
    }

    public IServiceCollection ToServices { get; }

    public IServiceCollection<TPacket> ThenToUnitOfWork<TUow, TUnitChain>()
        where TUow : ServiceUnit<TPacket>
        where TUnitChain : ChainFactoryUnit<TPacket, TUow>
    {
        ToServices.AddScoped<ILogger<TUow>, Logger<TUow>>();
        ToServices.AddScoped<ILogger<TUnitChain>, Logger<TUnitChain>>();

        ToServices.AddScoped(provider =>
            new Lazy<TUow>(() => ActivatorUtilities.CreateInstance<TUow>(provider,
                provider.GetRequiredService<ILogger<TUow>>())));

        ToServices.AddScoped<TUnitChain>();
        return this;
    }

    public IServiceCollection<TPacket> AddAnotherStrategy<TNewStrategy>()
        where TNewStrategy : ChainStrategyProvider<TPacket>
    {
        return ToServices.AddStrategyAsScoped<TPacket, TNewStrategy>();
    }
    public IServiceCollection<TPacket> AddAnotherStrategy<TNewStrategy, TNewDefaultFactory>()
        where TNewStrategy : ChainStrategyProvider<TPacket>
        where TNewDefaultFactory : DefaultFactoryUnit<TPacket, ServiceUnit<TPacket>>
    {
        return ToServices.AddStrategyAsScoped<TPacket, TNewStrategy, TNewDefaultFactory>();
    }

    private void StartRegistration()
    {
        ToServices.AddScoped<ILogger<TStrategy>, Logger<TStrategy>>();
        ToServices.AddScoped<TStrategy>();
    }
}


internal class ServiceCollectionScoped<TPacket, TStrategy, TDefaultFactory> : IServiceCollection<TPacket>
    where TPacket : IPacket
    where TStrategy : ChainStrategyProvider<TPacket>
    where TDefaultFactory : DefaultFactoryUnit<TPacket, ServiceUnit<TPacket>>
{
    public ServiceCollectionScoped(IServiceCollection services)
    {
        ToServices = services;
        StartRegistration();
    }

    public IServiceCollection ToServices { get; }

    public IServiceCollection<TPacket> ThenToUnitOfWork<TUow, TUnitChain>()
        where TUow : ServiceUnit<TPacket>
        where TUnitChain : ChainFactoryUnit<TPacket, TUow>
    {
        ToServices.AddScoped<ILogger<TUow>, Logger<TUow>>();
        ToServices.AddScoped<ILogger<TUnitChain>, Logger<TUnitChain>>();

        ToServices.AddScoped(provider =>
            new Lazy<TUow>(() => ActivatorUtilities.CreateInstance<TUow>(provider,
                provider.GetRequiredService<ILogger<TUow>>())));

        ToServices.AddScoped<TUnitChain>();
        return this;
    }

    public IServiceCollection<TPacket> AddAnotherStrategy<TNewStrategy>()
        where TNewStrategy : ChainStrategyProvider<TPacket>
    {
        return ToServices.AddStrategyAsScoped<TPacket, TNewStrategy>();
    }

    public IServiceCollection<TPacket> AddAnotherStrategy<TNewStrategy, TNewDefaultFactory>()
        where TNewStrategy : ChainStrategyProvider<TPacket>
        where TNewDefaultFactory : DefaultFactoryUnit<TPacket, ServiceUnit<TPacket>>
    {
        return ToServices.AddStrategyAsScoped<TPacket, TNewStrategy, TNewDefaultFactory>();
    }

    private void StartRegistration()
    {
        ToServices.AddScoped<ILogger<TStrategy>, Logger<TStrategy>>();
        ToServices.AddScoped<TStrategy>();
        ToServices.AddScoped<ILogger<TDefaultFactory>, Logger<TDefaultFactory>>();
        ToServices.AddScoped<TDefaultFactory>();
    }
}