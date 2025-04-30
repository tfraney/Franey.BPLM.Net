using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorService.ColorValidationServices;

public class BaseHotUnitService(ILogger<BaseHotUnitService> logger) : BaseUnitService(logger)
{
    protected override string Message()
    {
        return Verbiage.HotTemperatureValidationMsg;
    }
}

public class HotUnitService(ILogger<HotUnitService> logger)
    : BaseHotUnitService(logger);

public class HotUnitTransientService(ILogger<HotUnitTransientService> logger)
    : BaseHotUnitService(logger);

public class HotUnitScopedService(ILogger<HotUnitScopedService> logger)
    : BaseHotUnitService(logger);