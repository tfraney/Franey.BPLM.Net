using Franey.BPUL.Net.Interfaces;
using Microsoft.Extensions.Logging;

namespace Franey.BPUL.Net;

public abstract class ServiceUnit<T>(ILogger logger) : Unit(logger, Verbiage.TypeUow) where T : IPacket
{
    public virtual T Execute(T packet)
    {
        throw new NotImplementedException();
    }

    public virtual Task<T> ExecuteAsync(T packet)
    {
        throw new NotImplementedException();
    }
}