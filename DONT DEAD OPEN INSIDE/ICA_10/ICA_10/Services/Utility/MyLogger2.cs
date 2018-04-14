using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICA_10.Services.Utility
{
    public class MyLogger2 : ILogger
    {
        private CaptainsLogger CLogger;

        private Logger Logger;

        public Logger GetLogger()
        {
            return LogManager.GetLogger("myAppLoggerRules");
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

        public void Error(string message, string arg = null)
        {
            if (arg == null)
                GetLogger().Error(message);
            else
            {
                GetLogger().Error(message, arg);
            }
        }
    }
}