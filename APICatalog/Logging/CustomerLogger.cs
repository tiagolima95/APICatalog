
using System.ComponentModel;

namespace APICatalog.Logging
{
    public class CustomerLogger : ILogger
    {
        readonly string loggerName;
        readonly CustomLoggerProviderConfiguration loggerConfig;

        public CustomerLogger(string name, CustomLoggerProviderConfiguration config )
        {
            loggerName = name;
            loggerConfig = config;
        }

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == loggerConfig.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            string message =  $"{logLevel.ToString()} : {eventId.Id} - {formatter(state,exception)}";
            WriteTextToFile(message);
        }

        private void WriteTextToFile(string message)
        {
            string filePatch = "C:\\Users\\tiago\\Desktop\\Projetos pessoais\\Tiago_Logs.txt";

            using (StreamWriter streamWriter = new StreamWriter(filePatch, true))
            {
                try
                {
                    streamWriter.Write(message);
                    streamWriter.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
