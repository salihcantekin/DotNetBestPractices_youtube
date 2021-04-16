using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BP.Api.Loging
{
    public class MyCustomLoggerFactory : ILoggerProvider
    {

        public ILogger CreateLogger(string categoryName)
        {
            return new MyCustomLogger();
        }

        public void Dispose()
        {
            
        }
    }

    public class MyCustomLogger : ILogger
    {
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string logMsg = formatter(state, exception);

            logMsg = $"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}] - {logMsg}";

            Console.WriteLine(logMsg);
        }
    }
}
