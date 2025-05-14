using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorServiceAsync.ColorValidationServices;

public abstract class BaseBlueUnitServiceAsync(ILogger<BaseBlueUnitServiceAsync> logger) : BaseUnitServiceAsync(logger)
{
    protected override string Message()
    {
        return Verbiage.BlueColorValidationMsg;
    }
}


public class BlueUnitServiceAsync(ILogger<BlueUnitServiceAsync> logger) :
    BaseBlueUnitServiceAsync(logger);

public class BlueUnitTransientServiceAsync(ILogger<BlueUnitTransientServiceAsync> logger)
    : BaseBlueUnitServiceAsync(logger);

public class BlueUnitScopedServiceAsync(ILogger<BlueUnitScopedServiceAsync> logger)
    : BaseBlueUnitServiceAsync(logger);