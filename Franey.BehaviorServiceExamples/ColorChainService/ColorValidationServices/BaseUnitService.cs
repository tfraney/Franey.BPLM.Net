using Franey.BPUL.Net;
using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorService.ColorValidationServices;

public abstract class BaseUnitService(ILogger<BaseUnitService> logger) : ServiceUnit<ColorPacket>(logger)
{
    protected abstract string Message();

    public override ColorPacket Execute(ColorPacket packet)
    {
        Task.Delay(20).Wait();
        var a = 0;
        for (var g = 0; g <= 300; g++)
        {
            a = new Random(4).Next(g);
        }




        var msg = $"{Message()}{packet.Code}-{a}:{Verbiage.Comma}{packet.Name}{Verbiage.Eol}";
        if (packet.Response == null)
        {
            packet.CreateResponse(true, msg, Codes.Ok);
        }
        else
            packet.Response.Message =
                $"{packet.Response.Message}{msg}";

        return packet;
    }
}