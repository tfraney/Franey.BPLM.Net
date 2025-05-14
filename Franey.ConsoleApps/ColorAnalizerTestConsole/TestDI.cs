using ColorAnalizerCorService;
using Franey.BPUL.Net.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace ColorAnalizerTestConsole;

public class TestChainColors : IDisposable
{
    private const string RESULT = "\n\nResults: {0} - {1} \n\n";
    private const string NA = @"N/A";
    private bool _disposedValue;


    private SingleColorStrategyProvider? _singlestrategy = null;
    private AnyStrategyProvider? _anystrategy = null;
    private AllStrategyProvider? _allstrategy = null;

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

    public void PerformTest(IServiceProvider hostProvider, bool detail, int dimode)
    {
        switch (dimode)
        {
            case 1:
            {
                //set up for singleton
                _singlestrategy ??= hostProvider.GetRequiredService<SingleColorStrategyProvider>();
                _anystrategy ??= hostProvider.GetRequiredService<AnyStrategyProvider>();
                _allstrategy ??= hostProvider.GetRequiredService<AllStrategyProvider>();

                ExecuteTests(detail, _singlestrategy, _anystrategy, _allstrategy);
                break;
            }
            case 2:
            {
                using var singlestrategy = hostProvider.GetRequiredService<SingleColorStrategyProviderScoped>();
                using var anystrategy = hostProvider.GetRequiredService<AnyStrategyProviderScoped>();
                using var allstrategy = hostProvider.GetRequiredService<AllStrategyProviderScoped>();
                ExecuteTests(detail, singlestrategy, anystrategy, allstrategy);

                break;
            }
            default:
            {
                using var singlestrategy = hostProvider.GetRequiredService<SingleColorStrategyProviderTransient>();
                using var anystrategy = hostProvider.GetRequiredService<AnyStrategyProviderTransient>();
                using var allstrategy = hostProvider.GetRequiredService<AllStrategyProviderTransient>();
                ExecuteTests(detail, singlestrategy, anystrategy, allstrategy);

                break;
            }
        }
    }

    private void ExecuteTests(bool detail, IStrategyProvider<ColorPacket> singlestrategy,
        IStrategyProvider<ColorPacket> anystrategy, IStrategyProvider<ColorPacket> allstrategy)
    {
        if (detail)
        {
            var start = DateTime.Now;
            Console.WriteLine(@"Test Standard Colors (text)");

            TestColor(singlestrategy, @"Testing with a Single (First Matched) color in chain rule.", false);
            TestColor(anystrategy, @"Testing with Any Matching color in chain rule.", false);
            TestColor(allstrategy, @"Testing with All Matching colors in chain rule.", false);
            Console.WriteLine($"Completed {DateTime.Now.Subtract(start).TotalSeconds} seconds");
        }
        else
        {
            Console.WriteLine(@"Test Standard Colors (silent memory test)");

            for (var gg = 0; gg <= 29; gg++)
            {
                var start = DateTime.Now;
                for (var g = 0; g <= 3; g++)
                {
                    TestColor(singlestrategy, string.Empty, true);
                    TestColor(anystrategy, string.Empty, true);
                    TestColor(allstrategy, string.Empty, true);
                }

                Console.WriteLine($"Completed {gg + 1} - {DateTime.Now.Subtract(start).TotalSeconds} seconds");
                Task.Delay(400).Wait();
            }
        }
    }

    private void TestColor(IStrategyProvider<ColorPacket> strategy, string test, bool silent)

    {
        if (!string.IsNullOrEmpty(test)) Console.WriteLine(test);

        foreach (var r in Requests)
        {
            var newMessage = strategy.ExecuteStrategy(new ColorPacket
                { Code = r.Code, Name = r.Name, Temperature = r.Temperature });
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
            _allstrategy?.Dispose();
            _anystrategy?.Dispose();
            _singlestrategy?.Dispose();
            Requests.Clear();
        }
        _disposedValue = true;
    }
}