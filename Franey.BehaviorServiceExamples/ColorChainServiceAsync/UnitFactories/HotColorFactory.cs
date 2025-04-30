using ColorAnalizerCorServiceAsync.ColorValidationServices;
using Franey.BPS.Net.Factories;
using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorServiceAsync.UnitFactories;

public class HotColorFactoryAsync(ILogger<HotColorFactoryAsync> logger, Lazy<HotUnitServiceAsync> unitOfWork, CoolColorFactoryAsync next) :
    ChainFactoryUnit<ColorPacket, HotUnitServiceAsync>(logger, unitOfWork, next)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Temperature == Temperature.Hot;
    }
}

public class HotColorTransientFactoryAsync(
    ILogger<HotColorTransientFactoryAsync> logger,
    Lazy<HotUnitTransientServiceAsync> unitOfWork, CoolColorTransientFactoryAsync next)
    : ChainFactoryUnit<ColorPacket, HotUnitTransientServiceAsync>(logger, unitOfWork, next)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Temperature == Temperature.Hot;
    }
}

public class HotColorScopedFactoryAsync(
    ILogger<HotColorScopedFactoryAsync> logger,
    Lazy<HotUnitScopedServiceAsync> unitOfWork, CoolColorScopedFactoryAsync next)
    : ChainFactoryUnit<ColorPacket, HotUnitScopedServiceAsync>(logger, unitOfWork, next)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Temperature == Temperature.Hot;
    }
}