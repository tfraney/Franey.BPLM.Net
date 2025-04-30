using ColorAnalizerCorServiceAsync.ColorValidationServices;
using Franey.BPS.Net.Factories;
using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorServiceAsync.UnitFactories;

public class BlueColorFactoryAsync(ILogger<BlueColorFactoryAsync> logger, Lazy<BlueUnitServiceAsync> unitOfWork, GreenColorFactoryAsync next) :
    ChainFactoryUnit<ColorPacket, BlueUnitServiceAsync>(logger, unitOfWork, next)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Blue;
    }
}

public class BlueColorTransientFactoryAsync(
    ILogger<BlueColorTransientFactoryAsync> logger,
    Lazy<BlueUnitTransientServiceAsync> unitOfWork, GreenColorTransientFactoryAsync next) :
    ChainFactoryUnit<ColorPacket, BlueUnitTransientServiceAsync>(logger, unitOfWork, next)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Blue;
    }
}

public class BlueColorScopedFactoryAsync(
    ILogger<BlueColorScopedFactoryAsync> logger,
    Lazy<BlueUnitScopedServiceAsync> unitOfWork, GreenColorScopedFactoryAsync next) :
    ChainFactoryUnit<ColorPacket, BlueUnitScopedServiceAsync>(logger, unitOfWork, next)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Blue;
    }
}