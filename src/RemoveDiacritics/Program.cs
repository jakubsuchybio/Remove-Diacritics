using System;
using System.Diagnostics;
using System.Linq;
using CommandLine;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;

namespace RemoveDiacritics
{
    public static class Program
    {
        private const string LOGGER_TEMPLATE = "{Timestamp:HH:mm:ss.fffffff zzz} [{Level:u3}] [{ThreadId}] {Message:j}{NewLine}{Exception}";

        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Is(LogEventLevel.Information)
                .Enrich.WithThreadId()
                .Enrich.WithExceptionDetails()
                .Enrich.WithDemystifiedStackTraces()
                .WriteTo.Async(x => x.Console(outputTemplate: LOGGER_TEMPLATE))
                .CreateLogger();

            return Parser.Default.ParseArguments<StdInOptions, FileNamesOptions, ContentOptions>(args)
                .MapResult(
                    (StdInOptions opts) => RunActionAndReturnExitCode(opts, RemoverStdIn.StdInDiacriticsRemover),
                    (FileNamesOptions opts) => RunActionAndReturnExitCode(opts, () => RemoverFileNames.FileNamesDiacriticsRemover(opts.Dirs)),
                    (ContentOptions opts) => RunActionAndReturnExitCode(opts, () => RemoverContent.ContentDiacriticsRemover(opts.Files.ToArray())),
                    errors => 1);
        }

        private static int RunActionAndReturnExitCode(ICommonOptions opts, Action action)
        {
            if (opts.Debug)
            {
                Debugger.Launch();
                Debugger.Break();
            }

            action();

            Log.CloseAndFlush();

            return 0;
        }
    }
}
