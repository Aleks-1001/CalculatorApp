using System;
using CalculatorApp.Interfaces;
using CalculatorApp.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Настройка DI контейнера
            var serviceProvider = ConfigureServices();

            // Получение экземпляра калькулятора через DI
            var calculator = serviceProvider.GetService<ICalculator>();

            Console.WriteLine("=== Мини-калькулятор ===");

            double num1 = GetNumberFromUser("Введите первое число: ");
            double num2 = GetNumberFromUser("Введите второе число: ");

            double result = calculator.Add(num1, num2);
            Console.WriteLine($"Результат: {num1} + {num2} = {result}");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        private static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            // Регистрация зависимостей
            services.AddSingleton<ILogger, ConsoleLogger>();
            services.AddTransient<ICalculator, Calculator>();

            return services.BuildServiceProvider();
        }

        private static double GetNumberFromUser(string prompt)
        {
            while (true)
            {
                try
                {
                    Console.Write(prompt);
                    string input = Console.ReadLine();
                    return double.Parse(input);
                }
                catch (FormatException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка: Введите корректное число! ({ex.Message})");
                    Console.ResetColor();
                }
                catch (OverflowException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ошибка: Число слишком большое или маленькое! ({ex.Message})");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Неизвестная ошибка: {ex.Message}");
                    Console.ResetColor();
                }
                finally
                {
                    
                }
            }
        }
    }
}