

using ArithmeticExpressionAPI.Core;
using ArithmeticExpressionAPI.Services;

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
            var isValidExpression = expressValidatorService.Validate(inExpression);
            result = CalculateExpression(inExpression, isValidExpression);

            return result;
        }

        public decimal ExecuteAddOnly(string inExpression)
        {
            var result = 0m;
            var isValidExpression = expressValidatorService.ValidateAddOnly(inExpression);
            result = CalculateExpression(inExpression, isValidExpression);

            return result;
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