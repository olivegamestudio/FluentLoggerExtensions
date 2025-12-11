using Microsoft.Extensions.Logging;

namespace Inspired.CoreUI;

public readonly struct CallerLogContext
{
    public ILogger Logger { get; }

    public string? File { get; }

    public string? Member { get; }

    public int Line { get; }

    public CallerLogContext(ILogger logger, string? file, string? member, int line)
    {
        Logger = logger;
        File = file;
        Member = member;
        Line = line;
    }
}
