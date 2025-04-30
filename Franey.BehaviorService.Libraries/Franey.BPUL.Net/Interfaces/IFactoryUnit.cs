namespace Franey.BPUL.Net.Interfaces;

public interface IFactoryUnit<T> : IDisposable 
    where T : IPacket
{
    T ProcessRequest(T packet, ChainStrategyMode strategyMode);
    Task<T> ProcessRequestAsync(T packet, ChainStrategyMode strategyMode);
}