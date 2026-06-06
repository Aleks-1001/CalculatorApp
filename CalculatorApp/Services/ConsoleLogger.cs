using System;
using CalculatorApp.Interfaces;

namespace CalculatorApp.Services
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"[LOG] {DateTime.Now}: {message}");
            Console.ResetColor();
        }

        public void LogError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] {DateTime.Now}: {error}");
            Console.ResetColor();
        }
    }
}