using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorServiceAsync.ColorValidationServices;

public class BaseHotUnitServiceAsync(ILogger<BaseHotUnitServiceAsync> logger) : BaseUnitServiceAsync(logger)
{
    protected override string Message()
    {
        return Verbiage.HotTemperatureValidationMsg;
    }
}


public class HotUnitServiceAsync(ILogger<HotUnitServiceAsync> logger)
    : BaseHotUnitServiceAsync(logger);

public class HotUnitTransientServiceAsync(ILogger<HotUnitTransientServiceAsync> logger)
    : BaseHotUnitServiceAsync(logger);

public class HotUnitScopedServiceAsync(ILogger<HotUnitScopedServiceAsync> logger)
    : BaseHotUnitServiceAsync(logger);