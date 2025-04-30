using Franey.BPS.Net.Factories;
using Franey.BPUL.Net;
using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorServiceAsync.UnitFactories;

public abstract class BaseNoSingleColorFactoryAsync(ILogger<BaseNoSingleColorFactoryAsync> logger) :
    DefaultFactoryUnit<ColorPacket, ServiceUnit<ColorPacket>>(logger)
{
    public override string DefaultErrorMessage(ColorPacket packet)
    {
        return $"{packet.Code}-{packet.Name}{Verbiage.DefMsg}";
    }
}

public class NoSingleColorFactoryAsync(ILogger<NoSingleColorFactoryAsync> logger)
    : BaseNoSingleColorFactoryAsync(logger);

public class NoSingleColorTransientFactoryAsync(ILogger<NoSingleColorTransientFactoryAsync> logger)
    : BaseNoSingleColorFactoryAsync(logger);

public class NoSingleColorScopedFactoryAsync(ILogger<NoSingleColorScopedFactoryAsync> logger)
    : BaseNoSingleColorFactoryAsync(logger);
