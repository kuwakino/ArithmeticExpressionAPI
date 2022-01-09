

using ArithmeticExpressionAPI.Core;
using ArithmeticExpressionAPI.Services;
using System.Text.RegularExpressions;

namespace ArithmeticExpressionAPI.UseCases
{
    public class AdditionUseCase
    { 
        private enum Action
        {
            AddAndSub,
            AddOnly,
        }

        private IExpressionValidatorService expressValidatorService;
        private IExpressionCalculatorService expressCalculatorService;

        public AdditionUseCase(IExpressionValidatorService expressValidatorService, IExpressionCalculatorService expressCalculatorService)
        {
            this.expressValidatorService = expressValidatorService;
            this.expressCalculatorService = expressCalculatorService;
        }

        public decimal Execute(string inExpression) => ActionHandler(Action.AddAndSub, inExpression);

        public decimal ExecuteAddOnly(string inExpression) => ActionHandler(Action.AddOnly, inExpression);

        private decimal ActionHandler(Action action, string inExpression)
        {
            var result = 0m;
            var expression = RemoveWhiteSpaces(inExpression);

            bool isValidExpression = IsValidExpression(action, expression);

            result = CalculateExpression(expression, isValidExpression);

            return result;
        }

        private static string RemoveWhiteSpaces(string expression) => Regex.Replace(expression, @"\s+", "");

        private bool IsValidExpression(Action action, string expression)
        {
            var isValidExpression = false;
            switch (action)
            {
                case Action.AddOnly:
                    isValidExpression = expressValidatorService.ValidateAddOnly(expression);
                    break;
                default:
                    isValidExpression = expressValidatorService.Validate(expression);
                    break;
            }

            return isValidExpression;
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