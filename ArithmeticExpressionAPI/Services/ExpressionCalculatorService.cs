using ArithmeticExpressionAPI.Core;

namespace ArithmeticExpressionAPI.Services
{
    public class ExpressionCalculatorService : IExpressionCalculatorService
    {
        decimal IExpressionCalculatorService.Calculate(string expression)
        {
            var postfixExpression = ShuntingYardService.ConvertToPostfix(expression, false);
            return ShuntingYardService.Calculate(postfixExpression);
        }

        decimal IExpressionCalculatorService.CalculateAddOnly(string expression)
        {
            var postfixExpression = ShuntingYardService.ConvertToPostfix(expression, true);
            return ShuntingYardService.Calculate(postfixExpression);
        }
    }
}
