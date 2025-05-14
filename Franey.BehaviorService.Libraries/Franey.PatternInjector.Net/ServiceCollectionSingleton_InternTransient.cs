using Franey.BPS.Net.Factories;
using Franey.BPUL.Net;
using Franey.BPUL.Net.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Franey.PatternInjector.Net;


internal class ServiceCollectionTransient<TPacket, TStrategy> : IServiceCollection<TPacket>
    where TPacket : IPacket
    where TStrategy : BaseStrategyProvider<TPacket>
{
    public ServiceCollectionTransient(IServiceCollection services)
    {
        ToServices = services;
        StartRegistration();
    }

    public IServiceCollection ToServices { get; }

    public IServiceCollection<TPacket> ThenToUnitOfWork<TUow, TUnitChain>()
        where TUow : ServiceUnit<TPacket>
        where TUnitChain : BaseFactoryUnit<TPacket, TUow>
    {
        ToServices.AddTransient<ILogger<TUow>, Logger<TUow>>();
        ToServices.AddTransient<ILogger<TUnitChain>, Logger<TUnitChain>>();

        ToServices.AddTransient(provider =>
            new Lazy<TUow>(() => ActivatorUtilities.CreateInstance<TUow>(provider,
                provider.GetRequiredService<ILogger<TUow>>())));

        ToServices.AddTransient<TUnitChain>();
        return this;
    }

    public IServiceCollection<TPacket> AddAnotherStrategy<TNewStrategy>()
        where TNewStrategy : BaseStrategyProvider<TPacket>
    {
        return ToServices.AddStrategyAsTransient<TPacket, TNewStrategy>();
    }

    public IServiceCollection<TPacket> AddAnotherStrategy<TNewStrategy, TNewDefaultFactory>()
        where TNewStrategy : BaseStrategyProvider<TPacket>
        where TNewDefaultFactory : DefaultFactoryUnit<TPacket, ServiceUnit<TPacket>>
    {
        return ToServices.AddStrategyAsTransient<TPacket, TNewStrategy, TNewDefaultFactory>();
    }


    private void StartRegistration()
    {
        ToServices.AddTransient<ILogger<TStrategy>, Logger<TStrategy>>();
        ToServices.AddTransient<TStrategy>();
    }
}

internal class ServiceCollectionTransient<TPacket, TStrategy, TDefaultFactory> : IServiceCollection<TPacket>
    where TPacket : IPacket
    where TStrategy : BaseStrategyProvider<TPacket>
    where TDefaultFactory : DefaultFactoryUnit<TPacket, ServiceUnit<TPacket>>
{
    public ServiceCollectionTransient(IServiceCollection services)
    {
        ToServices = services;
        StartRegistration();
    }

    public IServiceCollection ToServices { get; }

    public IServiceCollection<TPacket> ThenToUnitOfWork<TUow, TUnitChain>()
        where TUow : ServiceUnit<TPacket>
        where TUnitChain : BaseFactoryUnit<TPacket, TUow>
    {
        ToServices.AddTransient<ILogger<TUow>, Logger<TUow>>();
        ToServices.AddTransient<ILogger<TUnitChain>, Logger<TUnitChain>>();

        ToServices.AddTransient(provider =>
            new Lazy<TUow>(() => ActivatorUtilities.CreateInstance<TUow>(provider,
                provider.GetRequiredService<ILogger<TUow>>())));

        ToServices.AddTransient<TUnitChain>();
        return this;
    }

    public IServiceCollection<TPacket> AddAnotherStrategy<TNewStrategy>()
        where TNewStrategy : BaseStrategyProvider<TPacket>
    {
        return ToServices.AddStrategyAsTransient<TPacket, TNewStrategy>();
    }

    public IServiceCollection<TPacket> AddAnotherStrategy<TNewStrategy, TNewDefaultFactory>()
        where TNewStrategy : BaseStrategyProvider<TPacket>
        where TNewDefaultFactory : DefaultFactoryUnit<TPacket, ServiceUnit<TPacket>>
    {
        return ToServices.AddStrategyAsTransient<TPacket, TNewStrategy, TNewDefaultFactory>();
    }


    private void StartRegistration()
    {
        ToServices.AddTransient<ILogger<TStrategy>, Logger<TStrategy>>();
        ToServices.AddTransient<TStrategy>();
        ToServices.AddTransient<ILogger<TDefaultFactory>, Logger<TDefaultFactory>>();
        ToServices.AddTransient<TDefaultFactory>();
    }
}