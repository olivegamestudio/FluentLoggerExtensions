using Microsoft.Extensions.Logging;

namespace FluentLogger;

/// <summary>
/// Contains extension methods for logging with caller context.
/// </summary>
public static class CallerLogContextExtensions
{
    /// <summary>
    /// Logs an information message including caller context (file name, member name, line number).
    /// </summary>
    /// <param name="context">The caller log context.</param>
    /// <param name="message">The message to log.</param>
    /// <param name="args">The arguments for the message.</param>
    public static void LogInformation(this CallerLogContext context, string message, params object?[] args)
    {
        string fileName = Path.GetFileName(context.File);

        try
        {
            context.Logger.LogInformation(
                "[{File}:{Member}:{Line}] " + message,
                PrependCallerArgs(fileName, context.Member, context.Line, args));
        }
        catch (Exception ex)
        {
            // Fall back to a safe message; don't rethrow
            context.Logger.LogError(
                ex,
                "[{File}:{Member}:{Line}] Logging failed for template. Template={Template}",
                fileName, context.Member, context.Line, message);
        }
    }

    /// <summary>
    /// Logs an error message including caller context (file name, member name, line number).
    /// </summary>
    /// <param name="context">The caller log context.</param>
    /// <param name="message">The message to log.</param>
    /// <param name="args">The arguments for the message.</param>
    public static void LogError(this CallerLogContext context, string message, params object?[] args)
    {
        string fileName = Path.GetFileName(context.File);

        try
        {
            context.Logger.LogError(
                "[{File}:{Member}:{Line}] " + message,
                PrependCallerArgs(fileName, context.Member, context.Line, args));
        }
        catch (Exception ex)
        {
            // Fall back to a safe message; don't rethrow
            context.Logger.LogError(
                ex,
                "[{File}:{Member}:{Line}] Logging failed for template. Template={Template}",
                fileName, context.Member, context.Line, message);
        }
    }

    /// <summary>
    /// Logs an debug message including caller context (file name, member name, line number).
    /// </summary>
    /// <param name="context">The caller log context.</param>
    /// <param name="message">The message to log.</param>
    /// <param name="args">The arguments for the message.</param>
    public static void LogDebug(this CallerLogContext context, string message, params object?[] args)
    {
        string fileName = Path.GetFileName(context.File);

        try
        {
            context.Logger.LogDebug(
                "[{File}:{Member}:{Line}] " + message,
                PrependCallerArgs(fileName, context.Member, context.Line, args));
        }
        catch (Exception ex)
        {
            // Fall back to a safe message; don't rethrow
            context.Logger.LogDebug(
                ex,
                "[{File}:{Member}:{Line}] Logging failed for template. Template={Template}",
                fileName, context.Member, context.Line, message);
        }
    }

    /// <summary>
    /// Logs an warning message including caller context (file name, member name, line number).
    /// </summary>
    /// <param name="context">The caller log context.</param>
    /// <param name="message">The message to log.</param>
    /// <param name="args">The arguments for the message.</param>
    public static void LogWarning(this CallerLogContext context, string message, params object?[] args)
    {
        string fileName = Path.GetFileName(context.File);

        try
        {
            context.Logger.LogWarning(
                "[{File}:{Member}:{Line}] " + message,
                PrependCallerArgs(fileName, context.Member, context.Line, args));
        }
        catch (Exception ex)
        {
            // Fall back to a safe message; don't rethrow
            context.Logger.LogWarning(
                ex,
                "[{File}:{Member}:{Line}] Logging failed for template. Template={Template}",
                fileName, context.Member, context.Line, message);
        }
    }

    /// <summary>
    /// Prepends caller information to the arguments array.
    /// </summary>
    /// <param name="file">The file name of the caller.</param>
    /// <param name="member">The member name of the caller.</param>
    /// <param name="line">The line number of the caller.</param>
    /// <param name="args">The original arguments array.</param>
    /// <returns>A new arguments array with caller information prepended.</returns>
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
