

using ArithmeticExpressionAPI.Core;
using ArithmeticExpressionAPI.Services;
using System.Text.RegularExpressions;

namespace ArithmeticExpressionAPI.UseCases
{
    public class AdditionUseCase
    {
        private IExpressionValidatorService expressValidatorService;
        private IExpressionCalculatorService expressCalculatorService;

        public AdditionUseCase(IExpressionValidatorService expressValidatorService, IExpressionCalculatorService expressCalculatorService)
        {
            this.expressValidatorService = expressValidatorService;
            this.expressCalculatorService = expressCalculatorService;
        }

        public decimal Execute(string inExpression)
        {
            var result = 0m;
            var expression = RemoveWhiteSpaces(inExpression);
            var isValidExpression = expressValidatorService.Validate(expression);
            result = CalculateExpression(expression, isValidExpression);

            return result;
        }

        public decimal ExecuteAddOnly(string inExpression)
        {
            var result = 0m;
            var expression = RemoveWhiteSpaces(inExpression);
            var isValidExpression = expressValidatorService.ValidateAddOnly(expression);
            result = CalculateExpression(expression, isValidExpression);

            return result;
        }

        private static string RemoveWhiteSpaces(string expression)
        {
            return Regex.Replace(expression, @"\s+", "");
        }

        private decimal CalculateExpression(string inExpression, bool isValidExpression)
        {
            var result = 0m;

            if (isValidExpression)
                result = expressCalculatorService.Calculate(inExpression);
            else
                throw new Exception("Invalid expression. Use infix notatation - operators are written between the operands (numbers) they operate on, e.g. 2 + 3 + 5.");
            return result;
        }
    }
}