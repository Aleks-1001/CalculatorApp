using CalculatorApp.Interfaces;

namespace CalculatorApp.Services
{
    public class Calculator : ICalculator
    {
        private readonly ILogger _logger;

        public Calculator(ILogger logger)
        {
            _logger = logger;
        }

        public double Add(double a, double b)
        {
            double result = a + b;
            _logger.Log($"Выполнено сложение: {a} + {b} = {result}");
            return result;
        }
    }
}