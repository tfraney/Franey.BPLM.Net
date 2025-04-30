using Franey.BPS.Net.Factories;
using Franey.BPUL.Net;
using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorService.UnitFactories;

public abstract class BaseNotAllColorsFactory(ILogger<BaseNotAllColorsFactory> logger, DefaultFactoryUnit<ColorPacket, ServiceUnit<ColorPacket>> next) :
    DefaultFactoryUnit<ColorPacket, ServiceUnit<ColorPacket>>(logger,null, next)
{
    public override string DefaultErrorMessage(ColorPacket packet)
    {
         return $"{packet.Code}-{packet.Name} {Verbiage.NotAllMsg}";
    }

    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Response is { Response: Codes.FullChainNotSatisified, Message: "" };
    }
}

public class NotAllColorsFactory(ILogger<NotAllColorsFactory> logger, NoSingleColorFactory nextdef)
    : BaseNotAllColorsFactory(logger, nextdef);

public class NotAllColorsTransientFactory(ILogger<NotAllColorsTransientFactory> logger, NoSingleColorTransientFactory nextdef)
    : BaseNotAllColorsFactory(logger, nextdef);

public class NotAllColorsScopedFactory(ILogger<NotAllColorsScopedFactory> logger, NoSingleColorScopedFactory nextdef)
    : BaseNotAllColorsFactory(logger, nextdef);
