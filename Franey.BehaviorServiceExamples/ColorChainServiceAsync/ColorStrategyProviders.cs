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