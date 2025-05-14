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


public class GreenColorFactoryConcurrent(ILogger<GreenColorFactoryConcurrent> logger, Lazy<GreenUnitServiceAsync> unitOfWork) :
    ConcurrentFactoryUnit<ColorPacket, GreenUnitServiceAsync>(logger, unitOfWork)
{
    public override int Priority => 2;

    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Green;
    }
}


public class GreenColorTransientFactoryConcurrent(
    ILogger<GreenColorTransientFactoryConcurrent> logger,
    Lazy<GreenUnitTransientServiceAsync> unitOfWork) :
    ConcurrentFactoryUnit<ColorPacket, GreenUnitTransientServiceAsync>(logger, unitOfWork)
{
    public override int Priority => 2;

    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Green;
    }
}

public class GreenColorScopedFactoryConcurrent(
    ILogger<GreenColorScopedFactoryConcurrent> logger,
    Lazy<GreenUnitScopedServiceAsync> unitOfWork) :
    ConcurrentFactoryUnit<ColorPacket, GreenUnitScopedServiceAsync>(logger, unitOfWork)
{
    public override int Priority => 2;

    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Green;
    }
}
