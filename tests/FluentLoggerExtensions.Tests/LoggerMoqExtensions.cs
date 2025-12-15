using Microsoft.Extensions.Logging;
using Moq;

namespace FluentLoggerExtensions.Tests;

public static class LoggerMoqExtensions
{
    public static void VerifyLogContains(this Mock<ILogger> logger, string message, LogLevel level = LogLevel.Information, Times? times = null)
    {
        logger.Verify(x =>
                x.Log(
                    level,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) =>
                        v.ToString()!.Contains(message)
                    ),
                    It.IsAny<Exception>(),
                    It.IsAny<Func<It.IsAnyType, Exception?, string>>()),
            Times.Once);
    }
}
