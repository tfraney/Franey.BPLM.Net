using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorServiceAsync.ColorValidationServices;

public class BaseRedUnitServiceAsync(ILogger<BaseRedUnitServiceAsync> logger) : BaseUnitServiceAsync(logger)
{
    protected override string Message()
    {
        return Verbiage.RedColorValidationMsg;
    }
}

public class RedUnitServiceAsync(ILogger<RedUnitServiceAsync> logger)
    : BaseRedUnitServiceAsync(logger);

public class RedUnitTransientServiceAsync(ILogger<RedUnitTransientServiceAsync> logger)
    : BaseRedUnitServiceAsync(logger);

public class RedUnitScopedServiceAsync(ILogger<RedUnitScopedServiceAsync> logger)
    : BaseRedUnitServiceAsync(logger);