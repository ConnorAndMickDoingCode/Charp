using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NLog;

namespace Topic4.Services.Utility
{
    public class CaptainsLogger : ILogger
    {
        private static CaptainsLogger _instance;
        private static Logger _logger;

        public static CaptainsLogger getInstace()
        {
            return _instance ?? (_instance = new CaptainsLogger());
        }

        public static Logger getLogger()
        {
            return LogManager.GetLogger("loggerRules");
        }

        public void Debug(string message, string arg = null)
        {
            if (arg == null)
                getLogger().Debug(message);
            else
            {
                getLogger().Debug(message, arg);
            }
        }

        public void Info(string message, string arg = null)
        {
            if (arg == null)
                getLogger().Info(message);
            else
            {
                getLogger().Info(message, arg);
            }
        }

        public void Warning(string message, string arg = null)
        {
            if (arg == null)
                getLogger().Warn(message);
            else
            {
                getLogger().Warn(message, arg);
            }
        }

        public void Error(string message, string arg = null)
        {
            if (arg == null)
                getLogger().Error(message);
            else
            {
                getLogger().Error(message, arg);
            }
        }
    }
}