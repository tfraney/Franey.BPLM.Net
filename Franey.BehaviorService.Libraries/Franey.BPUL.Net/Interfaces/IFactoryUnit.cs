namespace Franey.BPUL.Net.Interfaces;


public interface IFactoryUnit<T> : IDisposable
    where T : IPacket
{
    
    bool FactoryRule(T packet) => true;

    T ProcessRequest(T packet, ChainStrategyMode strategyMode);

    Task<T> ProcessRequestAsync(T packet, ChainStrategyMode strategyMode);
}


public interface IDefaultFactoryUnit<T> : IFactoryUnit<T>
    where T : IPacket
{
    public abstract string DefaultErrorMessage(T packet);
}
