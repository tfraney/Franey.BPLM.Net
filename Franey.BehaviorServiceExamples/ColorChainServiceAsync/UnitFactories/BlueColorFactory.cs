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


public class BlueColorFactoryConcurrent(ILogger<BlueColorFactoryConcurrent> logger, Lazy<BlueUnitServiceAsync> unitOfWork) :
    ConcurrentFactoryUnit<ColorPacket, BlueUnitServiceAsync>(logger, unitOfWork)
{
    public override int Priority => 3;

    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Blue;
    }
}


public class BlueColorTransientFactoryConcurrent(
    ILogger<BlueColorTransientFactoryConcurrent> logger,
    Lazy<BlueUnitTransientServiceAsync> unitOfWork) :
    ConcurrentFactoryUnit<ColorPacket, BlueUnitTransientServiceAsync>(logger, unitOfWork)
{
    public override int Priority => 3;

    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Blue;
    }
}

public class BlueColorScopedFactoryConcurrent(
    ILogger<BlueColorScopedFactoryConcurrent> logger,
    Lazy<BlueUnitScopedServiceAsync> unitOfWork) :
    ConcurrentFactoryUnit<ColorPacket, BlueUnitScopedServiceAsync>(logger, unitOfWork)
{
    public override int Priority => 3;

    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Blue;
    }
}



