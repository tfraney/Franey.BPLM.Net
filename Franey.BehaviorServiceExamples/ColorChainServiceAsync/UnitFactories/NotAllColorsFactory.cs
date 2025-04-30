using Franey.BPS.Net.Factories;
using Franey.BPUL.Net;
using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorServiceAsync.UnitFactories;

public abstract class BaseNotAllColorsFactoryAsync(ILogger<BaseNotAllColorsFactoryAsync> logger, DefaultFactoryUnit<ColorPacket, ServiceUnit<ColorPacket>> next) :
    DefaultFactoryUnit<ColorPacket, ServiceUnit<ColorPacket>>(logger, null, next)
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

public class NotAllColorsFactoryAsync(ILogger<NotAllColorsFactoryAsync> logger, NoSingleColorFactoryAsync nextdef)
    : BaseNotAllColorsFactoryAsync(logger, nextdef);

public class NotAllColorsTransientFactoryAsync(ILogger<NotAllColorsTransientFactoryAsync> logger, NoSingleColorTransientFactoryAsync nextdef)
    : BaseNotAllColorsFactoryAsync(logger, nextdef);

public class NotAllColorsScopedFactoryAsync(ILogger<NotAllColorsScopedFactoryAsync> logger, NoSingleColorScopedFactoryAsync nextdef)
    : BaseNotAllColorsFactoryAsync(logger, nextdef);
