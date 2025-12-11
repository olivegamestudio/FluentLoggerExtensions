using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace FluentLogger;

public static class FluentLoggerExtensions
{
    public static CallerLogContext WithCaller(this ILogger logger,
        [CallerFilePath] string? file = null, [CallerMemberName] string? member = null, [CallerLineNumber] int line = 0)
        => new(logger, file, member, line);
}
