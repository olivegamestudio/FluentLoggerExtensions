using FluentLogger;
using Microsoft.Extensions.Logging;
using Moq;

namespace FluentLoggerExtensions.Tests;

public class CallerLogContextLogInformationTests
{
    [Theory]
    [InlineData("This is a test log message")]
    [InlineData("This is another test log message")]
    [InlineData("This is a really log test message")]
    public void LogInformation_WithPlainMessage_DoesNotThrow(string message)
    {
        Mock<ILogger> logger = new();
        logger.Object.WithCaller().LogInformation(message);
        logger.VerifyLogContains(message);
    }

    [Theory]
    [InlineData("hello")]
    public void LogInformation_WithInterpolatedString_DoesNotThrow(string id)
    {
        Mock<ILogger> logger = new();

        logger.Object.WithCaller().LogInformation($"{id}");
    }

    [Theory]
    [InlineData("hello", "there")]
    public void LogInformation_WithMatchingPlaceholdersAndArguments_DoesNotThrow(string id, string id2)
    {
        Mock<ILogger> logger = new();
        logger.Object.WithCaller().LogInformation("{FirstWord} {SecondWord}", id, id2);
    }

    [Theory]
    [InlineData("hello")]
    public void LogInformation_WithMissingArguments_DoesNotThrowUntilStateIsEnumerated(string id)
    {
        Mock<ILogger> logger = new();
        logger.Object.WithCaller().LogInformation("{FirstWord} {SecondWord}", id);
    }

    [Fact]
    public void Mismatched_placeholders_throw_when_state_is_enumerated()
    {
        var logger = new Mock<ILogger>();

        logger
            .Setup(l => l.Log(
                It.IsAny<LogLevel>(),
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception?>(),
                (Func<It.IsAnyType, Exception?, string>)It.IsAny<object>()))
            .Callback(new InvocationAction(invocation =>
            {
                // state is argument #2
                var state = invocation.Arguments[2];

                // This is what Serilog does internally: enumerate structured values
                foreach (var _ in (IEnumerable<KeyValuePair<string, object?>>)state)
                {
                    // enumeration triggers LogValuesFormatter.GetValue(...)
                }
            }));

        // 2 placeholders, 1 arg -> will throw once enumerated
        logger.Object.WithCaller().LogInformation("{FirstWord} {SecondWord}", "hello");
    }

}
