using Franey.BPS.Net.Factories;
using Franey.BPUL.Net;
using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorService.UnitFactories;

public abstract class BaseNoSingleColorFactory(ILogger<BaseNoSingleColorFactory> logger) :
    DefaultFactoryUnit<ColorPacket, ServiceUnit<ColorPacket>>(logger)
{
    public override string DefaultErrorMessage(ColorPacket packet)
    {
         return $"{packet.Code}-{packet.Name}{Verbiage.DefMsg}";
    }
}

public class NoSingleColorFactory(ILogger<NoSingleColorFactory> logger)
    : BaseNoSingleColorFactory(logger);

public class NoSingleColorTransientFactory(ILogger<NoSingleColorTransientFactory> logger)
    : BaseNoSingleColorFactory(logger);

public class NoSingleColorScopedFactory(ILogger<NoSingleColorScopedFactory> logger)
    : BaseNoSingleColorFactory(logger);
