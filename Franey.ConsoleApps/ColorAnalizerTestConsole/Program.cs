//Franey.BPUL.NET (Franey Behavior Pattern Unit Library) 
//Franey.BehaviorPatternStrategies.NET (Behavior Pattern Strategies, Factories, and Unit Services)
//Franey.DynamicPatternInjector.NET (Behavior Pattern Library IOC Injector )

using ColorAnalizerTestConsole;

var exit = false;
try
{
    var host = Parent.CreateHostBuilder([""]).Build();

    TestChainColorsAsync? test2 = null;
    TestChainColors?  test = null;
    while (!exit)
    {
        var testMode = ' ';
        while (testMode != '1' && testMode != '2' && testMode != 'x' && testMode != 'X')
        {
            Console.Write("\nselect 1) detail logs test or   2) memory and speed test or X) exit: ");
            testMode = Console.ReadKey().KeyChar;
            exit = testMode is 'x' or 'X';
        }

        if (!exit)
        {
            var asyn = ' ';
            while (asyn != '1' && asyn != '2' && asyn != '3')
            {
                Console.Write("\nselect 1) Standard sync or   2) async/await  or  3) Async Concurrent : ");
                asyn = Console.ReadKey().KeyChar;
            }

            var dimode = ' ';

            while (dimode != '1' && dimode != '2' && dimode != '3')
            {
                Console.Write("\nselect 1) singleton or   2) scope test or   3) transient: ");
                dimode = Console.ReadKey().KeyChar;
            }

            Console.WriteLine();

            var mode = dimode - '1' + 1;
            if (asyn == '1')
                RunTests(test, host.Services, testMode, mode);
            else
                await RunTestsAsync(test2, host.Services, testMode, mode + (asyn == '3'? 3: 0)).ConfigureAwait(false);
            Console.WriteLine();
        }
        else
        {
            test?.Dispose();
            test2?.Dispose();
            exit = true;
        }
    }
}
catch (Exception x)
{
   Console.WriteLine(x.Message);
   Console.WriteLine("\n\nPlease hit any key to exit");
    Console.ReadKey();
}

return;

static async Task RunTestsAsync(TestChainColorsAsync? test, IServiceProvider host, char detailed, int dimode)
{
    test ??= new TestChainColorsAsync();
    await test.PerformTestAsync(host, detailed is '1',dimode).ConfigureAwait(false);
}

static void RunTests(TestChainColors? test, IServiceProvider host, char detailed, int dimode)
{
    test ??= new TestChainColors();
    test.PerformTest(host, detailed is '1',dimode);
}