using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorService.ColorValidationServices;

public abstract class BaseBlueUnitService(ILogger<BaseBlueUnitService> logger) : BaseUnitService(logger)
{
    protected override string Message()
    {
        return Verbiage.BlueColorValidationMsg;
    }
}

public class BlueUnitService(ILogger<BlueUnitService> logger) :
    BaseBlueUnitService(logger);

public class BlueUnitTransientService(ILogger<BlueUnitTransientService> logger)
    : BaseBlueUnitService(logger);

public class BlueUnitScopedService(ILogger<BlueUnitScopedService> logger)
    : BaseBlueUnitService(logger);