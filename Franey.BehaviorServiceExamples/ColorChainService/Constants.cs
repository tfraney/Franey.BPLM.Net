namespace ColorAnalizerCorService;

public enum PrimaryColors
{
    Red,
    Blue,
    Green,
    Yellow
}

public enum Temperature
{
    Cool,
    Hot,
    Warm
}

public enum Code
{
    A1,
    A2,
    A3,
    A4
}

public static class Verbiage
{
    public const string Comma = @",";
    public const string Eol = "]\n";
    public const string DefMsg = " did not get approved in any color services..";
    public const string NotAllMsg = "must be approved by every validation services.";

    public const string HotTemperatureValidationMsg = "Hot Temperature Validation Service has Approved Request [";
    public const string CoolTemperatureValidationMsg = "Cool Temperature Validation Service has Approved Request [";
    public const string GreenColorValidationMsg = "Green Color Validation Service has Approved Request [";
    public const string BlueColorValidationMsg = "Blue Color Validation Service has Approved Request [";
    public const string RedColorValidationMsg = "Red Color Validation Service has Approved Request [";
    
}