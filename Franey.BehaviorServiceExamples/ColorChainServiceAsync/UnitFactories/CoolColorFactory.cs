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