using ColorAnalizerCorService.ColorValidationServices;
using Franey.BPS.Net.Factories;
using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorService.UnitFactories;

public class BlueColorFactory(ILogger<BlueColorFactory> logger, Lazy<BlueUnitService> unitOfWork, GreenColorFactory next) :
    ChainFactoryUnit<ColorPacket, BlueUnitService>(logger, unitOfWork, next)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Blue;
    }
}

public class BlueColorTransientFactory(
    ILogger<BlueColorTransientFactory> logger,
    Lazy<BlueUnitTransientService> unitOfWork, GreenColorTransientFactory next) :
    ChainFactoryUnit<ColorPacket, BlueUnitTransientService>(logger, unitOfWork, next)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Blue;
    }
}

public class BlueColorScopedFactory(ILogger<BlueColorScopedFactory> logger, Lazy<BlueUnitScopedService> unitOfWork, GreenColorScopedFactory next ) :
    ChainFactoryUnit<ColorPacket, BlueUnitScopedService>(logger, unitOfWork, next)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Blue;
    }
}