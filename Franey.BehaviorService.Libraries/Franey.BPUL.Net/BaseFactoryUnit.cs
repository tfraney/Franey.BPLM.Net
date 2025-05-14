using Franey.BPUL.Net.Interfaces;
using Microsoft.Extensions.Logging;

namespace Franey.BPUL.Net;

public abstract class BaseFactoryUnit<T, TFunc>(ILogger logger, string unitType, Lazy<TFunc>? unitOfWork = null) :
    Unit(logger, unitType) 
    where T : IPacket
    where TFunc : ServiceUnit<T>
{
    protected readonly Lazy<TFunc>? UnitOfWork = unitOfWork;

    public abstract int Priority { get; }

    protected bool ValidatePacketForFailure(T packet)
    {
        if (packet.Response != null)
        {
            return packet.Response.Response != Codes.Failed &&
                   packet.Response.Response != Codes.Error &&
                   packet.Response.Response != Codes.FullChainNotSatisified;
        }

        return true;
    }

    public abstract bool FactoryRule(T packet);
}
