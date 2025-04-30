using ColorAnalizerCorService.ColorValidationServices;
using Franey.BPS.Net.Factories;
using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorService.UnitFactories;

public class HotColorFactory(ILogger<HotColorFactory> logger, Lazy<HotUnitService> unitOfWork, CoolColorFactory next) :
    ChainFactoryUnit<ColorPacket, HotUnitService>(logger, unitOfWork,next)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Temperature == Temperature.Hot;
    }
}

public class HotColorTransientFactory(
    ILogger<HotColorTransientFactory> logger,
    Lazy<HotUnitTransientService> unitOfWork, CoolColorTransientFactory next)
    : ChainFactoryUnit<ColorPacket, HotUnitTransientService>(logger, unitOfWork, next)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Temperature == Temperature.Hot;
    }
}

public class HotColorScopedFactory(ILogger<HotColorScopedFactory> logger, Lazy<HotUnitScopedService> unitOfWork, CoolColorScopedFactory next)
    : ChainFactoryUnit<ColorPacket, HotUnitScopedService>(logger, unitOfWork, next)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Temperature == Temperature.Hot;
    }
}