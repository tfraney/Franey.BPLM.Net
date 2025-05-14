using Franey.BPS.Net.Factories;
using Franey.BPS.Net.Strategies;
using Franey.BPUL.Net;
using Franey.BPUL.Net.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Franey.PatternInjector.Net;

public static class ServiceRegisterExtTransient

{
    public static IServiceCollection<TPacket> AddStrategyAsTransient<TPacket, TStrategy, TDefaultFactory>(
        this IServiceCollection services)
        where TPacket : IPacket
        where TStrategy : BaseStrategyProvider<TPacket>
        where TDefaultFactory : DefaultFactoryUnit<TPacket, ServiceUnit<TPacket>>
    {
        return new ServiceCollectionTransient<TPacket, TStrategy, TDefaultFactory>(services);
    }

    public static IServiceCollection<TPacket> AddStrategyAsTransient<TPacket, TStrategy>(
        this IServiceCollection services)
        where TPacket : IPacket
        where TStrategy : BaseStrategyProvider<TPacket>
    {
        return new ServiceCollectionTransient<TPacket, TStrategy>(services);
    }
}