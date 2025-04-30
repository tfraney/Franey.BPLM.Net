using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorServiceAsync.ColorValidationServices;

public class BaseCoolUnitServiceAsync(ILogger<BaseCoolUnitServiceAsync> logger) : BaseUnitServiceAsync(logger)
{
    protected override string Message()
    {
        return Verbiage.CoolTemperatureValidationMsg;
    }
}

public class CoolUnitServiceAsync(ILogger<CoolUnitServiceAsync> logger)
    : BaseCoolUnitServiceAsync(logger);

public class CoolUnitTransientServiceAsync(ILogger<CoolUnitTransientServiceAsync> logger)
    : BaseCoolUnitServiceAsync(logger);

public class CoolUnitScopedServiceAsync(ILogger<CoolUnitScopedServiceAsync> logger)
    : BaseCoolUnitServiceAsync(logger);