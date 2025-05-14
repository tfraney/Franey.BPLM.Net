using ColorAnalizerCorServiceAsync.ColorValidationServices;
using Franey.BPS.Net.Factories;
using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorServiceAsync.UnitFactories;

public class CoolColorFactoryAsync(ILogger<CoolColorFactoryAsync> logger, Lazy<CoolUnitServiceAsync> unitOfWork, NotAllColorsFactoryAsync def) :
    ChainFactoryUnit<ColorPacket, CoolUnitServiceAsync>(logger, unitOfWork,def)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Temperature ==  Temperature.Cool ;
    }
}


public class CoolColorTransientFactoryAsync(
    ILogger<CoolColorTransientFactoryAsync> logger,
    Lazy<CoolUnitTransientServiceAsync> unitOfWork, NotAllColorsTransientFactoryAsync def) :
    ChainFactoryUnit<ColorPacket, CoolUnitTransientServiceAsync>(logger, unitOfWork, def)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Temperature == Temperature.Cool;
    }
}

public class CoolColorScopedFactoryAsync(
    ILogger<CoolColorScopedFactoryAsync> logger,
    Lazy<CoolUnitScopedServiceAsync> unitOfWork, NotAllColorsScopedFactoryAsync def) :
    ChainFactoryUnit<ColorPacket, CoolUnitScopedServiceAsync>(logger, unitOfWork, def)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Temperature == Temperature.Cool;
    }
}


public class CoolColorFactoryConcurrent(ILogger<CoolColorFactoryConcurrent> logger, Lazy<CoolUnitServiceAsync> unitOfWork) :
    ConcurrentFactoryUnit<ColorPacket, CoolUnitServiceAsync>(logger, unitOfWork)
{
    public override int Priority => 0;

    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Temperature == Temperature.Cool;
    }
}


public class CoolColorTransientFactoryConcurrent(
    ILogger<CoolColorTransientFactoryConcurrent> logger,
    Lazy<CoolUnitTransientServiceAsync> unitOfWork) :
    ConcurrentFactoryUnit<ColorPacket, CoolUnitTransientServiceAsync>(logger, unitOfWork)
{
    public override int Priority => 0;

    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Temperature == Temperature.Cool;
    }
}

public class CoolColorScopedFactoryConcurrent(
    ILogger<CoolColorScopedFactoryConcurrent> logger,
    Lazy<CoolUnitScopedServiceAsync> unitOfWork) :
    ConcurrentFactoryUnit<ColorPacket, CoolUnitScopedServiceAsync>(logger, unitOfWork)
{
    public override int Priority => 0;

    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Temperature == Temperature.Cool;
    }
}