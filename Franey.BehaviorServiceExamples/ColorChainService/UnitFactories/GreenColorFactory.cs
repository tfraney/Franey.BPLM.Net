using ColorAnalizerCorService.ColorValidationServices;
using Franey.BPS.Net.Factories;
using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorService.UnitFactories;

public class GreenColorFactory(ILogger<GreenColorFactory> logger, Lazy<GreenUnitService> unitOfWork, HotColorFactory next) :
    ChainFactoryUnit<ColorPacket, GreenUnitService>(logger, unitOfWork,next)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Green;
    }
}

public class GreenColorTransientFactory(
    ILogger<GreenColorTransientFactory> logger,
    Lazy<GreenUnitTransientService> unitOfWork, HotColorTransientFactory next)
    : ChainFactoryUnit<ColorPacket, GreenUnitTransientService>(logger, unitOfWork, next)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Green;
    }
}

public class GreenColorScopedFactory(ILogger<GreenColorScopedFactory> logger, Lazy<GreenUnitScopedService> unitOfWork, HotColorScopedFactory next)
    : ChainFactoryUnit<ColorPacket, GreenUnitScopedService>(logger, unitOfWork, next)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Green;
    }
}