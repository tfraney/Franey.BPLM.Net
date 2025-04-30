using Franey.BPUL.Net;
using Franey.BPUL.Net.Interfaces;
using Microsoft.Extensions.Logging;

namespace Franey.BPS.Net.Strategies;

public abstract class ChainStrategyProvider<T>(ILogger logger, IFactoryUnit<T>? startingFactory)
    : Unit(logger, Verbiage.TypeChainstrategy), IStrategyProvider<T>
    where T : IPacket
{
    public abstract ChainStrategyMode StrategyMode { get; }

    public T ExecuteStrategy(T packet)
    {
        if (startingFactory != null) packet = startingFactory.ProcessRequest(packet, StrategyMode);
        if (packet.Response != null) return packet;

        LogWarning(Verbiage.ResponseNotimplemented);
        packet.CreateResponse(false, string.Empty, Codes.Warning, Verbiage.ResponseNotimplemented);
        return packet;
    }

    public async ValueTask<T> ExecuteStrategyAsync(T packet)
    {
        if (startingFactory != null)
            packet = await startingFactory.ProcessRequestAsync(packet, StrategyMode).ConfigureAwait(false);

        if (packet.Response != null) return packet;

        LogWarning(Verbiage.ResponseNotimplemented);
        packet.CreateResponse(false, string.Empty, Codes.Warning, Verbiage.ResponseNotimplemented);
        return packet;
    }

    protected override void Dispose(bool disposing)
    {
        if (DisposedValue) return;
        if (!disposing) return;
        startingFactory?.Dispose();
        base.Dispose(disposing);
    }
}