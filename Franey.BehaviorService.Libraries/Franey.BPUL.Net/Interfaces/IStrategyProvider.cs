namespace Franey.BPUL.Net.Interfaces
{
    public interface IStrategyProvider<T> : IUnit
        where T : IPacket
    {
        public ChainStrategyMode StrategyMode { get; }
        public T ExecuteStrategy(T packet);
        public ValueTask<T> ExecuteStrategyAsync(T packet);
    }

}
