
using Franey.BPUL.Net;
using Franey.BPUL.Net.Interfaces;
using Microsoft.Extensions.Logging;

namespace Franey.BPS.Net.Factories;

public abstract class ChainFactoryUnit<T, TFunc>(ILogger logger, Lazy<TFunc> unitOfWork, IFactoryUnit<T>? nextUnit = null) :
#pragma warning disable CS9107 
    FactoryUnit<T, TFunc>(logger, Verbiage.TypeChainfactory, unitOfWork)
#pragma warning restore CS9107 
    where T : IPacket
    where TFunc :ServiceUnit<T>
{
   
    public override async Task<T> ProcessRequestAsync(T packet, ChainStrategyMode strategyMode)
    {
        if (ValidatePacketForFailure(packet) && FactoryRule(packet))
        {
            packet = await unitOfWork.Value.ExecuteAsync(packet).ConfigureAwait(false);

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
            packet.CreateResponse(false,string.Empty, Codes.FullChainNotSatisified);
        }

        packet = CheckIfDefaultBeforeCheckingNextUnit(packet, nextUnit);
        return nextUnit == null ? packet :
             await nextUnit.ProcessRequestAsync(packet, strategyMode).ConfigureAwait(false);
            

    }

    public override T ProcessRequest(T packet, ChainStrategyMode strategyMode)
    {
        if (ValidatePacketForFailure(packet) && FactoryRule(packet))
        {
            packet = unitOfWork.Value.Execute(packet);

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
        }

        packet = CheckIfDefaultBeforeCheckingNextUnit(packet, nextUnit);
        return nextUnit == null ? packet : nextUnit.ProcessRequest(packet, strategyMode);
    }
    protected override void Dispose(bool disposing)
    {
        if (DisposedValue) return;
        if (!disposing) return;
        if (unitOfWork.IsValueCreated) unitOfWork.Value.Dispose();
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