using System;
using System.Collections.Generic;
using System.Text;

namespace LogServices
{
    public class ConsoleLogProvider : ILogProvider
    {
        public void LogError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] {msg}");
            Console.ResetColor();
        }
        public void LogInfo(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[INFO] {msg}");
            Console.ResetColor();
        }
    }
}
