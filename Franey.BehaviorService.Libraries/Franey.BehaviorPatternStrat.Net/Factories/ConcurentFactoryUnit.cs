
using Franey.BPUL.Net;
using Franey.BPUL.Net.Interfaces;
using Microsoft.Extensions.Logging;

namespace Franey.BPS.Net.Factories;

public abstract class ConcurrentFactoryUnit<T, TFunc>(ILogger logger, Lazy<TFunc> unitOfWork) :
    BaseFactoryUnit<T, TFunc>(logger, Verbiage.TypeChainfactory), IFactoryUnit<T>
    where T : IPacket
    where TFunc :ServiceUnit<T>
{
    
    public T ProcessRequest(T packet, ChainStrategyMode strategyMode)
    {
        using var t = ProcessRequestAsync(packet, strategyMode);
        return t.GetAwaiter().GetResult();
    }

    public async Task<T> ProcessRequestAsync(T packet, ChainStrategyMode strategyMode)
    {
        packet.Response = null;
        packet = (T)packet.ClonePacket();
        if (!FactoryRule(packet)) return packet;
        var newpacket = await unitOfWork.Value.ExecuteAsync(packet).ConfigureAwait(false);
        newpacket.Priority = Priority;

        return newpacket.Response != null ? packet : newpacket;
    }

    protected override void Dispose(bool disposing)
    {
        if (DisposedValue) return;
        if (!disposing) return;
        if (unitOfWork.IsValueCreated) unitOfWork.Value.Dispose();
        base.Dispose(disposing);
    }
   
}