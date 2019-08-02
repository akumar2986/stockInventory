
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock.Web.Utility
{
    public interface ILog
    {
        void Information(string message);
        void Warning(string message);
        void Debug(string message);
        void Error(string message);
        void LogInformation(EventId eventId, string message, params object[] args);
    }
    public class Log: ILog
    {
        private static Microsoft.Extensions.Logging.ILogger logger;
        
        public Log(ILoggerFactory loggerFactory)
        {
            logger = loggerFactory.CreateLogger<Log>();
        }

        public void Information(string message)
        {
            logger.LogInformation(message);
        }

        public void Warning(string message)
        {
            logger.LogWarning(message);
        }

        public void Debug(string message)
        {
            logger.LogDebug(message);
        }

        public void Error(string message)
        {
            logger.LogError(message);
        }

        public void LogInformation(EventId eventId, string message, params object[] args)
        {
            logger.LogInformation(eventId, message);
        }
    }
}
