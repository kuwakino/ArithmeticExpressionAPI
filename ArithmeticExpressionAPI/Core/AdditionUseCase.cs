

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
            if (isValidExpression)
                result = expressCalculatorService.Calculate(inExpression);

            return result;
        }
    }
}