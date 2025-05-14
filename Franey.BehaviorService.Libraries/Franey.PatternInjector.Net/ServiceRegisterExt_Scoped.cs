using Franey.BPS.Net.Factories;
using Franey.BPS.Net.Strategies;
using Franey.BPUL.Net;
using Franey.BPUL.Net.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Franey.PatternInjector.Net;

public static class ServiceRegisterExtScoped

{
    public static IServiceCollection<TPacket> AddStrategyAsScoped<TPacket, TStrategy, TDefaultFactory>(
        this IServiceCollection services)
        where TPacket : IPacket
        where TStrategy : BaseStrategyProvider<TPacket>
        where TDefaultFactory : DefaultFactoryUnit<TPacket, ServiceUnit<TPacket>>
    {
        return new ServiceCollectionScoped<TPacket, TStrategy, TDefaultFactory>(services);
    } public static IServiceCollection<TPacket> AddStrategyAsScoped<TPacket, TStrategy>(
        this IServiceCollection services)
        where TPacket : IPacket
        where TStrategy : BaseStrategyProvider<TPacket>
    {
        return new ServiceCollectionScoped<TPacket, TStrategy>(services);
    }
}