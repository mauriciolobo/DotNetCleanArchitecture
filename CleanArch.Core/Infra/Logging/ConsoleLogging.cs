using System;
using Microsoft.Extensions.Logging;

namespace CleanArch.Core.Infra.Logging
{
    public class ConsoleLogging : ILogger
    {
        private readonly LogLevel _logLevel;

        public ConsoleLogging(LogLevel logLevel)
        {
            _logLevel = logLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            Console.WriteLine($"[{logLevel}]({eventId}) - {formatter.Invoke(state, exception)}");
        }

        public bool IsEnabled(LogLevel logLevel) => logLevel == _logLevel;

        public IDisposable BeginScope<TState>(TState state) => default;
    }
}