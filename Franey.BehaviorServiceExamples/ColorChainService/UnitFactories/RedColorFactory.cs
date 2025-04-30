using ColorAnalizerCorService.ColorValidationServices;
using Franey.BPS.Net.Factories;
using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorService.UnitFactories;

public class RedColorFactory(ILogger<RedColorFactory> logger, Lazy<RedUnitService> unitOfWork, BlueColorFactory next) :
    ChainFactoryUnit<ColorPacket, RedUnitService>(logger, unitOfWork, next)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Red;
    }
}

public class RedColorTransientFactory(
    ILogger<RedColorTransientFactory> logger,
    Lazy<RedUnitTransientService> unitOfWork, BlueColorTransientFactory next)
    : ChainFactoryUnit<ColorPacket, RedUnitTransientService>(logger, unitOfWork, next)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Red;
    }
}

public class RedColorScopedFactory(ILogger<RedColorScopedFactory> logger, Lazy<RedUnitScopedService> unitOfWork, BlueColorScopedFactory next)
    : ChainFactoryUnit<ColorPacket, RedUnitScopedService>(logger, unitOfWork, next)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Red;
    }
}