using ColorAnalizerCorServiceAsync.UnitFactories;
using Franey.BPS.Net.Strategies;
using Franey.BPUL.Net;
using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorServiceAsync;

public class SingleColorStrategyProviderAsync(
    ILogger<SingleColorStrategyProviderAsync> logger,
    RedColorFactoryAsync red) : ChainStrategyProvider<ColorPacket>(logger, red)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.SingleChainResponsibility;
}

public class SingleColorStrategyProviderTransientAsync(
    ILogger<SingleColorStrategyProviderTransientAsync> logger,
    RedColorTransientFactoryAsync red
) : ChainStrategyProvider<ColorPacket>(logger, red)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.SingleChainResponsibility;
}

public class SingleColorStrategyProviderScopedAsync(
    ILogger<SingleColorStrategyProviderScopedAsync> logger,
    RedColorScopedFactoryAsync red) : ChainStrategyProvider<ColorPacket>(logger, red)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.SingleChainResponsibility;
}

public class AnyStrategyProviderAsync(
    ILogger<AnyStrategyProviderAsync> logger,
    RedColorFactoryAsync red) : ChainStrategyProvider<ColorPacket>(logger, red)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.PartialDecoratorChainResponsibility;
}

public class AnyStrategyProviderTransientAsync(
    ILogger<AnyStrategyProviderTransientAsync> logger,
    RedColorTransientFactoryAsync red)
    : ChainStrategyProvider<ColorPacket>(logger, red)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.PartialDecoratorChainResponsibility;
}

public class AnyStrategyProviderScopedAsync(
    ILogger<AnyStrategyProviderScopedAsync> logger,
    RedColorScopedFactoryAsync red)
    : ChainStrategyProvider<ColorPacket>(logger, red)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.PartialDecoratorChainResponsibility;
}


public class AllStrategyProviderAsync(
    ILogger<AllStrategyProviderAsync> logger,
    RedColorFactoryAsync red) : ChainStrategyProvider<ColorPacket>(logger, red)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.FullDecoratorChainResponsibility;
}

public class AllStrategyProviderTransientAsync(
    ILogger<AllStrategyProviderTransientAsync> logger,
    RedColorTransientFactoryAsync red)
    : ChainStrategyProvider<ColorPacket>(logger, red)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.FullDecoratorChainResponsibility;
}

public class AllStrategyProviderScopedAsync(
    ILogger<AllStrategyProviderScopedAsync> logger,
    RedColorScopedFactoryAsync red)
    : ChainStrategyProvider<ColorPacket>(logger, red)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.FullDecoratorChainResponsibility;
}

public class SingleStrategyProviderConcurrent(
    ILogger<SingleStrategyProviderConcurrent> logger,
    BlueColorFactoryConcurrent blue,
    GreenColorFactoryConcurrent green,
    HotColorFactoryConcurrent hot,
    CoolColorFactoryConcurrent cool,
    NotAllColorsFactoryAsync notcolor,
    RedColorFactoryConcurrent red) : ConcurrentStrategyProvider<ColorPacket>(logger,notcolor, red, blue, green,hot,cool)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.SingleChainResponsibility;
}

public class SingleStrategyProviderTransientConcurrent(
    ILogger<SingleStrategyProviderTransientConcurrent> logger,
    BlueColorTransientFactoryConcurrent blue,
    GreenColorTransientFactoryConcurrent green,
    HotColorTransientFactoryConcurrent hot,
    CoolColorTransientFactoryConcurrent cool,
    NotAllColorsFactoryAsync notcolor,
    RedColorTransientFactoryConcurrent red)
    : ConcurrentStrategyProvider<ColorPacket>(logger, notcolor, red, blue, green, hot, cool)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.SingleChainResponsibility;
}

public class SingleStrategyProviderScopedConcurrent(
    ILogger<SingleStrategyProviderScopedConcurrent> logger,
    BlueColorScopedFactoryConcurrent blue,
    GreenColorScopedFactoryConcurrent green,
    HotColorScopedFactoryConcurrent hot,
    CoolColorScopedFactoryConcurrent cool,
    NotAllColorsFactoryAsync notcolor,
    RedColorScopedFactoryConcurrent red)
    : ConcurrentStrategyProvider<ColorPacket>(logger, notcolor, red, blue, green, hot, cool)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.SingleChainResponsibility;
}


public class AnyStrategyProviderConcurrent(
    ILogger<AnyStrategyProviderConcurrent> logger,
    BlueColorFactoryConcurrent blue,
    GreenColorFactoryConcurrent green,
    HotColorFactoryConcurrent hot,
    CoolColorFactoryConcurrent cool,
    NotAllColorsFactoryAsync notcolor,
    RedColorFactoryConcurrent red) : ConcurrentStrategyProvider<ColorPacket>(logger, notcolor, red, blue, green, hot, cool)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.PartialDecoratorChainResponsibility;
}

public class AnyStrategyProviderTransientConcurrent(
    ILogger<AnyStrategyProviderTransientConcurrent> logger,
    BlueColorTransientFactoryConcurrent blue,
    GreenColorTransientFactoryConcurrent green,
    HotColorTransientFactoryConcurrent hot,
    CoolColorTransientFactoryConcurrent cool,
    NotAllColorsFactoryAsync notcolor,
    RedColorTransientFactoryConcurrent red)
    : ConcurrentStrategyProvider<ColorPacket>(logger, notcolor, red, blue, green, hot, cool)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.PartialDecoratorChainResponsibility;
}

public class AnyStrategyProviderScopedConcurrent(
    ILogger<AnyStrategyProviderScopedConcurrent> logger,
    BlueColorScopedFactoryConcurrent blue,
    GreenColorScopedFactoryConcurrent green,
    HotColorScopedFactoryConcurrent hot,
    CoolColorScopedFactoryConcurrent cool,
    NotAllColorsFactoryAsync notcolor,
    RedColorScopedFactoryConcurrent red)
    : ConcurrentStrategyProvider<ColorPacket>(logger, notcolor, red, blue, green, hot, cool)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.PartialDecoratorChainResponsibility;
}

public class AllStrategyProviderConcurrent(
    ILogger<AllStrategyProviderConcurrent> logger,
    BlueColorFactoryConcurrent blue,
    GreenColorFactoryConcurrent green,
    HotColorFactoryConcurrent hot,
    CoolColorFactoryConcurrent cool,
    NotAllColorsFactoryAsync notcolor,
    RedColorFactoryConcurrent red) : ConcurrentStrategyProvider<ColorPacket>(logger, notcolor, red, blue, green, hot, cool)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.FullDecoratorChainResponsibility;
}

public class AllStrategyProviderTransientConcurrent(
    ILogger<AllStrategyProviderTransientConcurrent> logger,
    BlueColorTransientFactoryConcurrent blue,
    GreenColorTransientFactoryConcurrent green,
    HotColorTransientFactoryConcurrent hot,
    CoolColorTransientFactoryConcurrent cool,
    NotAllColorsFactoryAsync notcolor,
    RedColorTransientFactoryConcurrent red)
    : ConcurrentStrategyProvider<ColorPacket>(logger, notcolor, red, blue, green, hot, cool)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.FullDecoratorChainResponsibility;
}

public class AllStrategyProviderScopedConcurrent(
    ILogger<AllStrategyProviderScopedConcurrent> logger,
    BlueColorScopedFactoryConcurrent blue,
    GreenColorScopedFactoryConcurrent green,
    HotColorScopedFactoryConcurrent hot,
    CoolColorScopedFactoryConcurrent cool,
    NotAllColorsFactoryAsync notcolor,
    RedColorScopedFactoryConcurrent red)
    : ConcurrentStrategyProvider<ColorPacket>(logger, notcolor, red, blue, green, hot, cool)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.FullDecoratorChainResponsibility;
}