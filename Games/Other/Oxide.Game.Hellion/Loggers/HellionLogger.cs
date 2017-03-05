using Oxide.Core.Logging;

namespace Oxide.Game.Hellion.Loggers
{
    public class HellionLogger : Logger
    {
        public HellionLogger() : base(true)
        {
        }

        protected override void ProcessMessage(LogMessage message)
        {
            switch (message.Type)
            {
                case LogType.Info:
                    Dbg.Info(message.ConsoleMessage);
                    break;
                case LogType.Debug:
                    Dbg.Info("[Debug] " + message.ConsoleMessage);
                    break;
                case LogType.Warning:
                    Dbg.Warning(message.ConsoleMessage);
                    break;
                case LogType.Error:
                    Dbg.Error(message.ConsoleMessage);
                    break;
                case LogType.Stacktrace:
                    Dbg.Error(message.ConsoleMessage);
                    break;
            }
        }
    }
}