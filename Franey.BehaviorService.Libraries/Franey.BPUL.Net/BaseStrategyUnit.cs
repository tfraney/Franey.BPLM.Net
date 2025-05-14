using Franey.BPUL.Net.Interfaces;
using Microsoft.Extensions.Logging;

namespace Franey.BPUL.Net
{
    public abstract class BaseStrategyProvider<T>(ILogger logger, string entityName)
        : Unit(logger, entityName), IStrategyProvider<T>
        where T : IPacket
    {
        public abstract ChainStrategyMode StrategyMode { get; }

        public abstract ValueTask<T> ExecuteStrategyAsync(T packet);


        public abstract T ExecuteStrategy(T packet);
        

        protected override void Dispose(bool disposing)
        {
            if (DisposedValue) return;
            if (!disposing) return;
            base.Dispose(disposing);
        }
    }
}
