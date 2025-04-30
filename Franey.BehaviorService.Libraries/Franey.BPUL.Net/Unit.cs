using Microsoft.Extensions.Logging;

namespace Franey.BPUL.Net;

public interface IUnit : IDisposable;
public abstract class Unit : IDisposable
{
    protected bool DisposedValue;

    protected Unit(ILogger logger, string unitType)
    {
        Logger = logger;
        UnitType = unitType;
        LogInstance(true);
    }

    protected string UnitType { get; }

    protected ILogger Logger { get; }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(true);
        GC.SuppressFinalize(this);
    }


    protected void LogWarning(string warning)
    {
        if (Logger.IsEnabled(LogLevel.Warning)) Logger.LogWarning(Verbiage.Entitydesc, UnitType, warning);
    }

    protected void LogError(string error)
    {
        if (Logger.IsEnabled(LogLevel.Error)) Logger.LogError(Verbiage.Entitydesc, UnitType, error);
    }

    protected void LogInstance(bool isInit)
    {
        if (Logger.IsEnabled(LogLevel.Trace))
            Logger.LogTrace(Verbiage.Entitydesc, UnitType, isInit ? Verbiage.Init : Verbiage.Dispose);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (DisposedValue) return;
        if (disposing) LogInstance(false);
        DisposedValue = true;
    }
}