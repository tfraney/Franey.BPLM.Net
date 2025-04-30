using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorService.ColorValidationServices;

public class BaseGreenUnitService(ILogger<BaseGreenUnitService> logger) : BaseUnitService(logger)
{
    protected override string Message()
    {
        return Verbiage.GreenColorValidationMsg;
    }
}

public class GreenUnitService(ILogger<GreenUnitService> logger)
    : BaseGreenUnitService(logger);

public class GreenUnitTransientService(ILogger<GreenUnitTransientService> logger)
    : BaseGreenUnitService(logger);

public class GreenUnitScopedService(ILogger<GreenUnitScopedService> logger)
    : BaseGreenUnitService(logger);