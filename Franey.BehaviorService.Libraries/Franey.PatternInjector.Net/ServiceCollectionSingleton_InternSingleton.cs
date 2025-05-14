using Franey.BPS.Net.Factories;
using Franey.BPS.Net.Strategies;
using Franey.BPUL.Net;
using Franey.BPUL.Net.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Franey.PatternInjector.Net;

internal class ServiceCollectionSingleton<TPacket, TStrategy> : IServiceCollection<TPacket>
    where TPacket : IPacket
    where TStrategy : BaseStrategyProvider<TPacket>
{
    public ServiceCollectionSingleton(IServiceCollection services)
    {
        ToServices = services;
        StartRegistration();
    }

    public IServiceCollection ToServices { get; }

    public IServiceCollection<TPacket> ThenToUnitOfWork<TUow, TUnitChain>()
        where TUow : ServiceUnit<TPacket>
        where TUnitChain : BaseFactoryUnit<TPacket, TUow>
    {
        ToServices.AddSingleton<ILogger<TUow>, Logger<TUow>>();
        ToServices.AddSingleton<ILogger<TUnitChain>, Logger<TUnitChain>>();

        ToServices.AddSingleton(provider =>
            new Lazy<TUow>(() => ActivatorUtilities.CreateInstance<TUow>(provider,
                provider.GetRequiredService<ILogger<TUow>>())));

        ToServices.AddSingleton<TUnitChain>();
        return this;
    }

    public IServiceCollection<TPacket> AddAnotherStrategy<TNewStrategy>()
        where TNewStrategy : BaseStrategyProvider<TPacket>
    {
        return ToServices.AddStrategyAsSingleton<TPacket, TNewStrategy>();
    }

    public IServiceCollection<TPacket> AddAnotherStrategy<TNewStrategy, TNewDefaultFactory>()
        where TNewStrategy : BaseStrategyProvider<TPacket>
        where TNewDefaultFactory : DefaultFactoryUnit<TPacket, ServiceUnit<TPacket>>
    {
        return ToServices.AddStrategyAsSingleton<TPacket, TNewStrategy, TNewDefaultFactory>();
    }

    private void StartRegistration()
    {
        ToServices.AddSingleton<ILogger<TStrategy>, Logger<TStrategy>>();
        ToServices.AddSingleton<TStrategy>();
    }
}
internal class ServiceCollectionSingleton<TPacket, TStrategy, TDefaultFactory> : IServiceCollection<TPacket>
    where TPacket : IPacket
    where TStrategy : BaseStrategyProvider<TPacket>
    where TDefaultFactory : DefaultFactoryUnit<TPacket, ServiceUnit<TPacket>>
{
    public ServiceCollectionSingleton(IServiceCollection services)
    {
        ToServices = services;
        StartRegistration();
    }

    public IServiceCollection ToServices { get; }

    public IServiceCollection<TPacket> ThenToUnitOfWork<TUow, TUnitChain>()
        where TUow : ServiceUnit<TPacket>
        where TUnitChain : BaseFactoryUnit<TPacket, TUow>
    {
        ToServices.AddSingleton<ILogger<TUow>, Logger<TUow>>();
        ToServices.AddSingleton<ILogger<TUnitChain>, Logger<TUnitChain>>();

        ToServices.AddSingleton(provider =>
            new Lazy<TUow>(() => ActivatorUtilities.CreateInstance<TUow>(provider,
                provider.GetRequiredService<ILogger<TUow>>())));

        ToServices.AddSingleton<TUnitChain>();
        return this;
    }

    public IServiceCollection<TPacket> AddAnotherStrategy<TNewStrategy>()
        where TNewStrategy : BaseStrategyProvider<TPacket>
    {
        return ToServices.AddStrategyAsSingleton<TPacket, TNewStrategy>();
    }

    public IServiceCollection<TPacket> AddAnotherStrategy<TNewStrategy, TNewDefaultFactory>()
        where TNewStrategy : BaseStrategyProvider<TPacket>
        where TNewDefaultFactory : DefaultFactoryUnit<TPacket, ServiceUnit<TPacket>>
    {
        return ToServices.AddStrategyAsSingleton<TPacket, TNewStrategy, TNewDefaultFactory>();
    }


    private void StartRegistration()
    {
        ToServices.AddSingleton<ILogger<TStrategy>, Logger<TStrategy>>();
        ToServices.AddSingleton<TStrategy>();
        ToServices.AddSingleton<ILogger<TDefaultFactory>, Logger<TDefaultFactory>>();
        ToServices.AddSingleton<TDefaultFactory>();
    }
}