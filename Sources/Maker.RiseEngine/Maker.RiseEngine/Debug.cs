using System;

namespace Maker.RiseEngine
{
    public enum LogType { Info, Warning, Error, Message}

    public static class Debug
    {
        public static void WriteLog(string text, LogType logMessageType, string senderName)
        {
            switch (logMessageType)
            {
                case LogType.Info:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case LogType.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogType.Error:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogType.Message:
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }            
            Console.WriteLine($"[{logMessageType.ToString()}] {senderName}: {text}");
        }
    }
}
