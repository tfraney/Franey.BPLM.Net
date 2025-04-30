using Franey.BPUL.Net.Interfaces;
using Microsoft.Extensions.Logging;

namespace Franey.BPUL.Net;

public abstract class FactoryUnit<T, TFunc>(ILogger logger, string unitType, Lazy<TFunc>? unitOfWork = null) :
    Unit(logger, unitType), IFactoryUnit<T>
    where T : IPacket
    where TFunc : ServiceUnit<T>
{
    protected readonly Lazy<TFunc>? UnitOfWork = unitOfWork;

    public abstract Task<T> ProcessRequestAsync(T packet, ChainStrategyMode strategyMode);


    public abstract T ProcessRequest(T packet, ChainStrategyMode strategyMode);
    
    protected virtual T ProcessMessage(T packet)
    {
        return packet;
    }
    protected bool ValidatePacketForFailure(T packet)
    {
        if (packet.Response != null)
        {
            return packet.Response.Response != Codes.Failed &&
                   packet.Response.Response  != Codes.Error &&
                   packet.Response.Response  != Codes.FullChainNotSatisified;
        }

        return true;
    }

    public abstract bool FactoryRule(T packet);
}