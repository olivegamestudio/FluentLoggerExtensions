using Microsoft.Extensions.Logging;

namespace FluentLogger;

/// <summary>
/// Contains the logger and caller information.
/// </summary>
public readonly struct CallerLogContext
{
    /// <summary>
    /// The logger instance.
    /// </summary>
    public ILogger Logger { get; }

    /// <summary>
    /// The file path of the caller.
    /// </summary>
    public string? File { get; }

    /// <summary>
    /// The member name of the caller.
    /// </summary>
    public string? Member { get; }

    /// <summary>
    /// The line number of the caller.
    /// </summary>
    public int Line { get; }

    /// <summary>
    /// The constructor.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="file">The file path of the caller.</param>
    /// <param name="member">The member name of the caller.</param>
    /// <param name="line">The line number of the caller.</param>
    public CallerLogContext(ILogger logger, string? file, string? member, int line)
    {
        Logger = logger;
        File = file;
        Member = member;
        Line = line;
    }
}
