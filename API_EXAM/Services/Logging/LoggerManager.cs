using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API_EXAM.Logging
{
    public class LoggerManager : ILoggerManager
    {
        AppConfiguration config = new AppConfiguration();
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        public void LogDebug(string message)
        {
            logger.Debug(message);
        }
        public void LogError(string message)
        {
            logger.Error(message);
        }
        public void LogInfo(string message)
        {
            logger.Info(message);
        }
        public void LogWarn(string message)
        {
            logger.Warn(message);
        }

        public string GetFilePath(string key)
        {
            string path = config.DocsPath;
            if (!Directory.Exists(path + key))
            {
                Directory.CreateDirectory(path + key);
            }
            path += key + "\\";

            var year = DateTime.Now.ToString("yyyy");
            if (!Directory.Exists(path + year))
            {
                Directory.CreateDirectory(path + year);
            }
            path += year + "\\";

            return path;
        }
    }
}
