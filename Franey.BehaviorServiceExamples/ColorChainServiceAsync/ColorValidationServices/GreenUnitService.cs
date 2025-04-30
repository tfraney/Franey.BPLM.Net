using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorServiceAsync.ColorValidationServices;

public class BaseGreenUnitServiceAsync(ILogger<BaseGreenUnitServiceAsync> logger) : BaseUnitServiceAsync(logger)
{
    protected override string Message()
    {
        return Verbiage.GreenColorValidationMsg;
    }
}

public class GreenUnitServiceAsync(ILogger<GreenUnitServiceAsync> logger)
    : BaseGreenUnitServiceAsync(logger);

public class GreenUnitTransientServiceAsync(ILogger<GreenUnitTransientServiceAsync> logger)
    : BaseGreenUnitServiceAsync(logger);

public class GreenUnitScopedServiceAsync(ILogger<GreenUnitScopedServiceAsync> logger)
    : BaseGreenUnitServiceAsync(logger);