using Microsoft.Extensions.Logging;

namespace FluentLogger;

public static class CallerLogContextExtensions
{
    public static void LogInformation(this CallerLogContext context, string message, params object?[] args)
    {
        string fileName = Path.GetFileName(context.File);
        context.Logger.LogInformation("[{File}:{Member}:{Line}] " + message, PrependCallerArgs(fileName, context.Member, context.Line, args));
    }

    public static void LogError(this CallerLogContext context, string message, params object?[] args)
    {
        string fileName = Path.GetFileName(context.File);
        context.Logger.LogError("[{File}:{Member}:{Line}] " + message, PrependCallerArgs(fileName, context.Member, context.Line, args));
    }

    public static void LogDebug(this CallerLogContext context, string message, params object?[] args)
    {
        string fileName = Path.GetFileName(context.File);
        context.Logger.LogDebug("[{File}:{Member}:{Line}] " + message, PrependCallerArgs(fileName, context.Member, context.Line, args));
    }

    public static void LogWarning(this CallerLogContext ctx, string message, params object?[] args)
    {
        string fileName = Path.GetFileName(ctx.File);
        ctx.Logger.LogWarning("[{File}:{Member}:{Line}] " + message, PrependCallerArgs(fileName, ctx.Member, ctx.Line, args));
    }

    static object?[] PrependCallerArgs(string file, string? member, int line, object?[] args)
    {
        object?[] finalArgs = new object?[args.Length + 3];
        finalArgs[0] = file;
        finalArgs[1] = member;
        finalArgs[2] = line;
        Array.Copy(args, 0, finalArgs, 3, args.Length);
        return finalArgs;
    }
}
