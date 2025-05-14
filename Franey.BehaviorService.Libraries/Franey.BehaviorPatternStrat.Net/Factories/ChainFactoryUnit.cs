
using Franey.BPUL.Net;
using Franey.BPUL.Net.Interfaces;
using Microsoft.Extensions.Logging;

namespace Franey.BPS.Net.Factories;

public abstract class ChainFactoryUnit<T, TFunc>(ILogger logger, Lazy<TFunc> unitOfWork, IFactoryUnit<T>? nextUnit = null) :
#pragma warning disable CS9107 
    BaseFactoryUnit<T, TFunc>(logger, Verbiage.TypeChainfactory, unitOfWork), IFactoryUnit<T>
#pragma warning restore CS9107 
    where T : IPacket
    where TFunc :ServiceUnit<T>
{
    public override int Priority => 0;

    public async Task<T> ProcessRequestAsync(T packet, ChainStrategyMode strategyMode)
    {
        if (ValidatePacketForFailure(packet) && FactoryRule(packet))
        {
            
            packet = UnitOfWork != null ? await UnitOfWork.Value.ExecuteAsync(packet).ConfigureAwait(false) : packet;

            if (packet.Response == null)
            {
                LogWarning(Verbiage.ResponseNotimplemented);
                packet.CreateResponse(false, string.Empty, Codes.Warning, Verbiage.ResponseNotimplemented);
                return packet;
            }

            if (strategyMode == ChainStrategyMode.SingleChainResponsibility)
                return packet;
        }
        else if (strategyMode == ChainStrategyMode.FullDecoratorChainResponsibility &&
                 ValidatePacketForFailure(packet))
        {
            packet.CreateResponse(false, string.Empty, Codes.FullChainNotSatisified);
            return packet;
        }

        packet = CheckIfDefaultBeforeCheckingNextUnit(packet, nextUnit);

        if (packet.Response?.Error == Codes.Error) return packet;

        
        packet = nextUnit == null
            ? packet
            : await nextUnit.ProcessRequestAsync(packet, strategyMode).ConfigureAwait(false);
        
        return packet;

    }
    public T ProcessRequest(T packet, ChainStrategyMode strategyMode)
    {
        if (ValidatePacketForFailure(packet) && FactoryRule(packet))
        {
            packet = UnitOfWork != null? UnitOfWork.Value.Execute(packet) : packet;

            if (packet.Response == null)
            {
                LogWarning(Verbiage.ResponseNotimplemented);
                packet.CreateResponse(false, string.Empty, Codes.Warning, Verbiage.ResponseNotimplemented);
                return packet;
            }

            if (strategyMode == ChainStrategyMode.SingleChainResponsibility) 
                return packet;
        }
        else if (strategyMode == ChainStrategyMode.FullDecoratorChainResponsibility &&
                 ValidatePacketForFailure(packet))
        {
            packet.CreateResponse(false, string.Empty, Codes.FullChainNotSatisified);
            return packet;
        }

        packet = CheckIfDefaultBeforeCheckingNextUnit(packet, nextUnit);

        if (packet.Response?.Error == Codes.Error) return packet;

  
        packet =  nextUnit == null ? packet :
            nextUnit.ProcessRequest(packet, strategyMode);
       
        return packet;
    }
    protected override void Dispose(bool disposing)
    {
        if (DisposedValue) return;
        if (!disposing) return;
        if (UnitOfWork?.IsValueCreated??false) unitOfWork.Value.Dispose();
        nextUnit?.Dispose();
        base.Dispose(disposing);
    }

    protected T CheckIfDefaultBeforeCheckingNextUnit(T packet, IFactoryUnit<T>? unit)
    {
        if (unit == null)
        {
            packet.CreateResponse(false,Verbiage.NoDefaultFactory, Codes.Error);
        }

        return packet;
    }
}