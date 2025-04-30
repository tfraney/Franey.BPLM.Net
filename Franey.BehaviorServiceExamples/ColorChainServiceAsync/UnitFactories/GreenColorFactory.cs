using ColorAnalizerCorServiceAsync.ColorValidationServices;
using Franey.BPS.Net.Factories;
using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorServiceAsync.UnitFactories;

public class GreenColorFactoryAsync(ILogger<GreenColorFactoryAsync> logger, Lazy<GreenUnitServiceAsync> unitOfWork, HotColorFactoryAsync next) :
    ChainFactoryUnit<ColorPacket, GreenUnitServiceAsync>(logger, unitOfWork, next)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Green;
    }
}

public class GreenColorTransientFactoryAsync(
    ILogger<GreenColorTransientFactoryAsync> logger,
    Lazy<GreenUnitTransientServiceAsync> unitOfWork, HotColorTransientFactoryAsync next)
    : ChainFactoryUnit<ColorPacket, GreenUnitTransientServiceAsync>(logger, unitOfWork, next)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Green;
    }
}

public class GreenColorScopedFactoryAsync(
    ILogger<GreenColorScopedFactoryAsync> logger,
    Lazy<GreenUnitScopedServiceAsync> unitOfWork, HotColorScopedFactoryAsync next)
    : ChainFactoryUnit<ColorPacket, GreenUnitScopedServiceAsync>(logger, unitOfWork, next)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Green;
    }
}