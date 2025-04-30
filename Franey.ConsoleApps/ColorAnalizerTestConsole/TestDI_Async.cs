using ColorAnalizerCorServiceAsync;
using Franey.BPUL.Net.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ColorAnalizerTestConsole;

public class TestChainColorsAsync : IDisposable
{
    private const string RESULT = "\n\nResults: {0} - {1} \n\n";
    private const string NA = @"N/A";
    private bool _disposedValue;

    private SingleColorStrategyProviderAsync? _singlestrategy = null;
    private AnyStrategyProviderAsync? _anystrategy = null;
    private AllStrategyProviderAsync? _allstrategy = null;

    private List<ColorPacket> Requests { get; } =
    [
        new()
        {
            Code = Code.A1, Name = PrimaryColors.Blue, Temperature = Temperature.Cool
        },
        new()
        {
            Code = Code.A2, Name = PrimaryColors.Red, Temperature = Temperature.Hot
        },
        new()
        {
            Code = Code.A3, Name = PrimaryColors.Green, Temperature = Temperature.Cool
        },
        new()
        {
            Code = Code.A4, Name = PrimaryColors.Yellow, Temperature = Temperature.Warm
        }
    ];

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public async Task PerformTestAsync(IServiceProvider hostProvider, bool detail, char dimode)
    {
        switch (dimode)
        {
            case '1':
            {
                _singlestrategy ??= hostProvider.GetRequiredService<SingleColorStrategyProviderAsync>();
                _anystrategy ??= hostProvider.GetRequiredService<AnyStrategyProviderAsync>();
                _allstrategy ??= hostProvider.GetRequiredService<AllStrategyProviderAsync>();
                await ExecuteTests(detail, _singlestrategy, _anystrategy, _allstrategy).ConfigureAwait(false);
                break;
            }
            case '2':
            {
                using var singlestrategy = hostProvider.GetRequiredService<SingleColorStrategyProviderScopedAsync>();
                using var anystrategy = hostProvider.GetRequiredService<AnyStrategyProviderScopedAsync>();
                using var allstrategy = hostProvider.GetRequiredService<AllStrategyProviderScopedAsync>();
                await ExecuteTests(detail, singlestrategy, anystrategy, allstrategy).ConfigureAwait(false);
                break;
            }
            default:
            {
                using var singlestrategy = hostProvider.GetRequiredService<SingleColorStrategyProviderTransientAsync>();
                using var anystrategy = hostProvider.GetRequiredService<AnyStrategyProviderTransientAsync>();
                using var allstrategy = hostProvider.GetRequiredService<AllStrategyProviderTransientAsync>();
                await ExecuteTests(detail, singlestrategy, anystrategy, allstrategy).ConfigureAwait(false);
                break;
            }
        }
    }

    private async Task ExecuteTests(bool detail, IStrategyProvider<ColorPacket> singlestrategy,
        IStrategyProvider<ColorPacket> anystrategy, IStrategyProvider<ColorPacket> allstrategy)
    {
        if (detail)
        {
            var start = DateTime.Now;
            Console.WriteLine(@"Test Async Colors (text)");

            await TestColorAsync(singlestrategy, @"Testing (Async) with Single (First Matched) color in chain rule.",
                false).ConfigureAwait(false);
            await TestColorAsync(anystrategy, @"Testing  (Async) with Any Matching color in chain rule.", false)
                .ConfigureAwait(false);
            await TestColorAsync(allstrategy, @"Testing (Async) with All Matching colors in chain rule.", false)
                .ConfigureAwait(false);
            Console.WriteLine($"Completed {DateTime.Now.Subtract(start).TotalSeconds} seconds");
        }
        else
        {
            Console.WriteLine(@"Test  Async Colors (silent memory test)");

            for (var gg = 0; gg <= 49; gg++)
            {
                var start = DateTime.Now;
                for (var g = 0; g <= 299; g++)
                {
                    await TestColorAsync(singlestrategy, string.Empty, true).ConfigureAwait(false);
                    await TestColorAsync(anystrategy, string.Empty, true).ConfigureAwait(false);
                    await TestColorAsync(allstrategy, string.Empty, true).ConfigureAwait(false);
                }

                Console.WriteLine($"Completed {gg + 1} - {DateTime.Now.Subtract(start).TotalSeconds} seconds");
                await Task.Delay(200).ConfigureAwait(false);
            }
        }
    }


    private async Task TestColorAsync(IStrategyProvider<ColorPacket> strategy, string test, bool silent)
    {
        if (!string.IsNullOrEmpty(test)) Console.WriteLine(test);

        foreach (var r in Requests)
        {
            var newMessage = await strategy
                .ExecuteStrategyAsync(new ColorPacket { Code = r.Code, Name = r.Name, Temperature = r.Temperature })
                .ConfigureAwait(false);
            var resp = (ColorResponse?)newMessage.Response;

            if (!silent)
                Console.WriteLine(RESULT, resp?.Response ?? string.Empty,
                    resp?.Message ?? resp?.Error ?? string.Empty);
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposedValue) return;

        if (disposing)
        {
            Requests.Clear();
            _allstrategy?.Dispose();
            _anystrategy?.Dispose();
            _singlestrategy?.Dispose();

        }
        _disposedValue = true;
    }
}