using Franey.BPUL.Net;
using Franey.BPUL.Net.Interfaces;
using Microsoft.Extensions.Logging;

namespace Franey.BPS.Net.Strategies;

public abstract class ConcurrentStrategyProvider<T>(ILogger logger, IDefaultFactoryUnit<T> defaultFactory, params IFactoryUnit<T>[] startingFactories)
    : BaseStrategyProvider<T>(logger, Verbiage.TypeConcurrenttrategy)
    where T : IPacket
{
 public override T ExecuteStrategy(T packet)
    {
        using var t =  ExecuteStrategyAsync(packet).AsTask();
        return t.GetAwaiter().GetResult();
    }

    public override async ValueTask<T> ExecuteStrategyAsync(T packet)
    {
        var noset = false;


        var p = packet;
        var res = await Task.WhenAll(startingFactories.Select(x => x.ProcessRequestAsync(p, StrategyMode))).ConfigureAwait(false);

        res = [.. res.Where(r => r.Response != null).OrderByDescending(r => r.Priority)];

        try
        {
            if (StrategyMode == ChainStrategyMode.FullDecoratorChainResponsibility &&
                res.Length < startingFactories.Length)
            {
                packet.CreateResponse(false, string.Empty, Codes.FullChainNotSatisified);
                noset = true;
            }
            else
            {
                var newres = res.FirstOrDefault();
                if (newres?.Response != null && newres.Priority >= 0)
                {
                    if (StrategyMode == ChainStrategyMode.SingleChainResponsibility)
                    {
                        return newres;

                    }

                    var message = newres.Response?.Message ?? string.Empty;
                    for (var i = 1; i < res.Length; i++)
                    {
                        {
                            if (res[i].Response == null) continue;
                            var message2 = res[i].Response?.Message ?? string.Empty;

                            if (!string.IsNullOrWhiteSpace(message2))
                                message = string.Concat(message, Verbiage.Eol, message2);
                        }
                    }

                    newres.CreateResponse(true, message, Codes.Ok);
                    return newres;
                }
                else if (newres?.Response != null)
                {
                    return newres;
                }
            }
        }
        catch (Exception ex)
        {
            packet.CreateResponse(false, string.Empty, Codes.Error, ex.Message);
            return packet;
        }

        packet =  noset || packet.Response == null ? await defaultFactory.ProcessRequestAsync(packet, StrategyMode).ConfigureAwait(false) : packet;

        if (packet.Response != null) return packet; 

        LogWarning(Verbiage.ResponseNotimplemented);
        packet.CreateResponse(false, string.Empty, Codes.Warning, Verbiage.ResponseNotimplemented);
        return packet;
    }

    protected override void Dispose(bool disposing)
    {
        if (DisposedValue) return;
        if (!disposing) return;
        foreach (var s in startingFactories)
        {
            s.Dispose();
        } 
        
        base.Dispose(disposing);
    }
}