using Franey.BPUL.Net;
using Franey.BPUL.Net.Interfaces;
using Microsoft.Extensions.Logging;


namespace Franey.BPS.Net.Factories;


public abstract class DefaultFactoryUnit<T, TFunc>(ILogger logger, Lazy<TFunc>? unitOfWork = null, IFactoryUnit<T>? nextDefaultUnit = null) :
    BaseFactoryUnit<T, TFunc>(logger, Verbiage.TypeDefchainfactory, unitOfWork), IDefaultFactoryUnit<T>
    where T : IPacket
    where TFunc : ServiceUnit<T>
{
    public override int Priority => -1;
    public abstract string DefaultErrorMessage(T packet);

    public override bool FactoryRule(T packet) => true;

    public T ProcessRequest(T packet, ChainStrategyMode strategyMode)
    {
        if (packet.Response == null ||
            (!ValidatePacketForFailure(packet) &&
             strategyMode == ChainStrategyMode.FullDecoratorChainResponsibility))
        {
            if (FactoryRule(packet))
            {
                packet.Response = null;
                if (UnitOfWork?.Value != null)
                    packet = UnitOfWork.Value.Execute(packet);
                else ProcessMessage(packet);
            }
        }
        if (packet.Response != null) return packet;

        if (nextDefaultUnit != null) packet = nextDefaultUnit.ProcessRequest(packet, strategyMode);
        else if (packet.Response == null || packet.Response.Response == Codes.FullChainNotSatisified)
        {
            LogError(Verbiage.ResponseNodefault);
            packet.CreateResponse(false, string.Empty, Verbiage.ResponseNodefault, Codes.Error);
        }
        return packet;
    }

    public async Task<T> ProcessRequestAsync(T packet, ChainStrategyMode strategyMode)
    {
        
        if (packet.Response == null ||
            (!ValidatePacketForFailure(packet) &&
             strategyMode == ChainStrategyMode.FullDecoratorChainResponsibility))
        {
            if (FactoryRule(packet))
            {
                packet.Response = null;
                if (UnitOfWork?.Value != null)
                    packet = await UnitOfWork.Value.ExecuteAsync(packet);
                else ProcessMessage(packet);
            }
        }
        if (packet.Response != null) return packet;

        if (nextDefaultUnit != null) packet = await nextDefaultUnit.ProcessRequestAsync(packet, strategyMode);
        else if (packet.Response == null || packet.Response.Response == Codes.FullChainNotSatisified)
        {
            LogError(Verbiage.ResponseNodefault);
            packet.CreateResponse(false, string.Empty, Verbiage.ResponseNodefault, Codes.Error);
        }
        return packet;
    }

    protected  T ProcessMessage(T packet)
    {
        var msg = DefaultErrorMessage(packet);
        if (!string.IsNullOrEmpty(msg)) packet.CreateResponse(false, msg, Codes.Error , string.Empty); 
        return packet;
    }

    protected override void Dispose(bool disposing)
    {
        if (DisposedValue) return;
        if (!disposing) return;
        if (UnitOfWork?.IsValueCreated ?? false) UnitOfWork.Value.Dispose();
        nextDefaultUnit?.Dispose();
        base.Dispose(disposing);
    }
}