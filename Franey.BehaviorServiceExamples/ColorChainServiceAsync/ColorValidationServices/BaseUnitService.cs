using System.Security.Cryptography.X509Certificates;
using Franey.BPUL.Net;
using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorServiceAsync.ColorValidationServices;

public abstract class BaseUnitServiceAsync(ILogger<BaseUnitServiceAsync> logger) : ServiceUnit<ColorPacket>(logger)
{
    protected abstract string Message();

    public override async Task<ColorPacket> ExecuteAsync(ColorPacket packet)
    {
        await Task.Delay(20).ConfigureAwait(false);
        var a = await Task.Run(() =>
        {
            var x = 0;
            for (var g = 0; g <= 300; g++)
            {
                x = new Random(4).Next(g);
            }

            return x;
        }).ConfigureAwait(false); 
  
        
        var msg = $"{Message()}{packet.Code}-{a}: {Verbiage.Comma}{packet.Name}{Verbiage.Eol}";
        if (packet.Response == null)
        {
            packet.CreateResponse(true, msg, Codes.Ok);
        }
        else packet.Response.Message = msg;

        return packet;


    }
}