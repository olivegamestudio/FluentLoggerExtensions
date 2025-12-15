using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace FluentLogger;

public static class FluentLoggerExtensions
{
    /// <summary>
    /// Wraps the given ILogger with caller information.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="file">The file path of the caller.</param>
    /// <param name="member">The member name of the caller.</param>
    /// <param name="line">The line number of the caller.</param>
    /// <returns>A context object containing the logger and caller information.</returns>
    public static CallerLogContext WithCaller(this ILogger logger,
        [CallerFilePath] string? file = null,
        [CallerMemberName] string? member = null,
        [CallerLineNumber] int line = 0)
        => new(logger, file, member, line);
}
