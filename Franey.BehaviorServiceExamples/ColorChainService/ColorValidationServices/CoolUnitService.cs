using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorService.ColorValidationServices;

public class BaseCoolUnitService(ILogger<BaseCoolUnitService> logger) : BaseUnitService(logger)
{
    protected override string Message()
    {
        return Verbiage.CoolTemperatureValidationMsg;
    }
}

public class CoolUnitService(ILogger<CoolUnitService> logger)
    : BaseCoolUnitService(logger);

public class CoolUnitTransientService(ILogger<CoolUnitTransientService> logger)
    : BaseCoolUnitService(logger);

public class CoolUnitScopedService(ILogger<CoolUnitScopedService> logger)
    : BaseCoolUnitService(logger);