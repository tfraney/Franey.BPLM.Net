using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorService.ColorValidationServices;

public class BaseRedUnitService(ILogger<BaseRedUnitService> logger) : BaseUnitService(logger)
{
    protected override string Message()
    {
        return Verbiage.RedColorValidationMsg;
    }
}

public class RedUnitService(ILogger<RedUnitService> logger)
    : BaseRedUnitService(logger);

public class RedUnitTransientService(ILogger<RedUnitTransientService> logger)
    : BaseRedUnitService(logger);

public class RedUnitScopedService(ILogger<RedUnitScopedService> logger)
    : BaseRedUnitService(logger);