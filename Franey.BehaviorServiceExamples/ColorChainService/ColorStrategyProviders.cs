using ColorAnalizerCorService.UnitFactories;
using Franey.BPS.Net.Strategies;
using Franey.BPUL.Net;
using Microsoft.Extensions.Logging;

namespace ColorAnalizerCorService;

public class SingleColorStrategyProvider(
    ILogger<SingleColorStrategyProvider> logger,
    RedColorFactory red) : ChainStrategyProvider<ColorPacket>(logger, red)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.SingleChainResponsibility;
}

public class SingleColorStrategyProviderTransient(
    ILogger<SingleColorStrategyProviderTransient> logger,
    RedColorTransientFactory red
) : ChainStrategyProvider<ColorPacket>(logger, red)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.SingleChainResponsibility;
}

public class SingleColorStrategyProviderScoped(
    ILogger<SingleColorStrategyProviderScoped> logger,
    RedColorScopedFactory red) : ChainStrategyProvider<ColorPacket>(logger, red)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.SingleChainResponsibility;
}

public class AnyStrategyProvider(
    ILogger<AnyStrategyProvider> logger,
    RedColorFactory red) : ChainStrategyProvider<ColorPacket>(logger, red)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.PartialDecoratorChainResponsibility;
}

public class AnyStrategyProviderTransient(
    ILogger<AnyStrategyProviderTransient> logger,
    RedColorTransientFactory red)
    : ChainStrategyProvider<ColorPacket>(logger, red)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.PartialDecoratorChainResponsibility;
}

public class AnyStrategyProviderScoped(
    ILogger<AnyStrategyProviderScoped> logger,
    RedColorScopedFactory red)
    : ChainStrategyProvider<ColorPacket>(logger, red)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.PartialDecoratorChainResponsibility;
}


public class AllStrategyProvider(
    ILogger<AllStrategyProvider> logger,
    RedColorFactory red) : ChainStrategyProvider<ColorPacket>(logger, red)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.FullDecoratorChainResponsibility;
}

public class AllStrategyProviderTransient(
    ILogger<AllStrategyProviderTransient> logger,
    RedColorTransientFactory red)
    : ChainStrategyProvider<ColorPacket>(logger, red)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.FullDecoratorChainResponsibility;
}

public class AllStrategyProviderScoped(
    ILogger<AllStrategyProviderScoped> logger,
    RedColorScopedFactory red)
    : ChainStrategyProvider<ColorPacket>(logger, red)
{
    public override ChainStrategyMode StrategyMode => ChainStrategyMode.FullDecoratorChainResponsibility;
}