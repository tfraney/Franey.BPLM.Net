using Franey.BPUL.Net;
using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorService.ColorValidationServices;

public abstract class BaseUnitService(ILogger<BaseUnitService> logger) : ServiceUnit<ColorPacket>(logger)
{
    protected abstract string Message();

    public override ColorPacket Execute(ColorPacket packet)
    {
      
        if (packet.Response == null)
        {
            var msg = $"{Message()}{packet.Code}{Verbiage.Comma}{packet.Name}{Verbiage.Eol}";
            packet.CreateResponse(true, msg, Codes.Ok);
        }
        else
            packet.Response.Message =
                $"{packet.Response.Message}{Message()}{packet.Code}{Verbiage.Comma}{packet.Name}{Verbiage.Eol}";
        return packet;
    }
}