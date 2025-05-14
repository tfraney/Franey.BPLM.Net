using ColorAnalizerCorServiceAsync.ColorValidationServices;
using Franey.BPS.Net.Factories;
using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorServiceAsync.UnitFactories;

public class RedColorFactoryAsync(ILogger<RedColorFactoryAsync> logger, Lazy<RedUnitServiceAsync> unitOfWork, BlueColorFactoryAsync next) :
    ChainFactoryUnit<ColorPacket, RedUnitServiceAsync>(logger, unitOfWork, next)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Red;
    }
}


public class RedColorTransientFactoryAsync(
    ILogger<RedColorTransientFactoryAsync> logger,
    Lazy<RedUnitTransientServiceAsync> unitOfWork, BlueColorTransientFactoryAsync next)
    : ChainFactoryUnit<ColorPacket, RedUnitTransientServiceAsync>(logger, unitOfWork,next)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Red;
    }
}

public class RedColorScopedFactoryAsync(
    ILogger<RedColorScopedFactoryAsync> logger,
    Lazy<RedUnitScopedServiceAsync> unitOfWork,
    BlueColorScopedFactoryAsync next)
    : ChainFactoryUnit<ColorPacket, RedUnitScopedServiceAsync>(logger, unitOfWork, next)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Red;
    }
}



public class RedColorFactoryConcurrent(ILogger<RedColorFactoryConcurrent> logger, Lazy<RedUnitServiceAsync> unitOfWork) :
    ConcurrentFactoryUnit<ColorPacket, RedUnitServiceAsync>(logger, unitOfWork)
{
    public override int Priority => 4;

    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Red;
    }
}


public class RedColorTransientFactoryConcurrent(
    ILogger<RedColorTransientFactoryConcurrent> logger,
    Lazy<RedUnitTransientServiceAsync> unitOfWork) :
    ConcurrentFactoryUnit<ColorPacket, RedUnitTransientServiceAsync>(logger, unitOfWork)
{
    public override int Priority => 4;

    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Red;
    }
}

public class RedColorScopedFactoryConcurrent(
    ILogger<RedColorScopedFactoryConcurrent> logger,
    Lazy<RedUnitScopedServiceAsync> unitOfWork) :
    ConcurrentFactoryUnit<ColorPacket, RedUnitScopedServiceAsync>(logger, unitOfWork)
{
    public override int Priority => 4;

    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Name == PrimaryColors.Red;
    }
}





