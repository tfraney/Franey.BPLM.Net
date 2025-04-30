using Franey.BPUL.Net;
using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorServiceAsync.ColorValidationServices;

public abstract class BaseUnitServiceAsync(ILogger<BaseUnitServiceAsync> logger) : ServiceUnit<ColorPacket>(logger)
{
    protected abstract string Message();

    public override async Task<ColorPacket> ExecuteAsync(ColorPacket packet)
    {
        return await Task.Run(() =>
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

        }).ConfigureAwait(false);
    }
}