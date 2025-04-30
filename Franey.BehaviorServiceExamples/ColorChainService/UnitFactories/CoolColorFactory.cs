using ColorAnalizerCorService.ColorValidationServices;
using Franey.BPS.Net.Factories;
using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorService.UnitFactories;

public class CoolColorFactory(ILogger<CoolColorFactory> logger, Lazy<CoolUnitService> unitOfWork, NotAllColorsFactory def) :
    ChainFactoryUnit<ColorPacket, CoolUnitService>(logger, unitOfWork, def)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Temperature == Temperature.Cool;
    }
}

public class CoolColorTransientFactory(ILogger<CoolColorTransientFactory> logger, Lazy<CoolUnitTransientService> unitOfWork, NotAllColorsTransientFactory def) :
    ChainFactoryUnit<ColorPacket, CoolUnitTransientService>(logger, unitOfWork, def)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Temperature == Temperature.Cool;
    }
}
public class CoolColorScopedFactory(ILogger<CoolColorScopedFactory> logger, Lazy<CoolUnitScopedService> unitOfWork, NotAllColorsScopedFactory def) :
    ChainFactoryUnit<ColorPacket, CoolUnitScopedService>(logger, unitOfWork, def)
{
    public override bool FactoryRule(ColorPacket packet)
    {
        return packet.Temperature == Temperature.Cool;
    }
}