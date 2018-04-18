using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CLC.Services.Utility
{
    public class TheLogger : ILogger
    {

        private TheLogger logger;
        public Logger Logger;

        public Logger GetLogger()
        {
            return LogManager.GetLogger("LoggerRules");
        }

        public void Debug(string message, string arg = null)
        {
            if (arg == null)
                GetLogger().Debug(message);
            else
            {
                GetLogger().Debug(message, arg);
            }
        }

        public void Error(string message, string arg = null)
        {
            if (arg == null)
                GetLogger().Error(message);
            else
            {
                GetLogger().Error(message, arg);
            }
        }

        public void Info(string message, string arg = null)
        {
            if (arg == null)
                GetLogger().Info(message);
            else
            {
                GetLogger().Info(message, arg);
            }
        }

        public void Warning(string message, string arg = null)
        {
            if (arg == null)
                GetLogger().Warn(message);
            else
            {
                GetLogger().Warn(message, arg);
            }
        }
    }
}