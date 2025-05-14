namespace Franey.BPUL.Net.Interfaces
{
    public interface IStrategyProvider<T> : IConcurrentStrategyProvider<T>
        where T : IPacket
    {
        public T ExecuteStrategy(T packet);
        
    }

    public interface IConcurrentStrategyProvider<T> : IUnit
        where T : IPacket
    {
        public ChainStrategyMode StrategyMode { get; }
        public ValueTask<T> ExecuteStrategyAsync(T packet);
    }

}
