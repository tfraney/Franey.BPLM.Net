using Franey.BPS.Net.Factories;
using Franey.BPS.Net.Strategies;
using Franey.BPUL.Net;
using Franey.BPUL.Net.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Franey.PatternInjector.Net;

public interface IServiceCollection<TPacket>
    where TPacket : IPacket


{
    IServiceCollection ToServices { get; }

    IServiceCollection<TPacket> AddAnotherStrategy<TNewStrategy, TNewDefaultFactory>()
        where TNewStrategy : ChainStrategyProvider<TPacket>
        where TNewDefaultFactory : DefaultFactoryUnit<TPacket, ServiceUnit<TPacket>>;
    IServiceCollection<TPacket> AddAnotherStrategy<TNewStrategy>()
        where TNewStrategy : ChainStrategyProvider<TPacket>;

    IServiceCollection<TPacket> ThenToUnitOfWork<TUow, TUnitChain>()
        where TUow : ServiceUnit<TPacket>
        where TUnitChain : ChainFactoryUnit<TPacket, TUow>;
}