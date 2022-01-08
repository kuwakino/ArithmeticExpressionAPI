using ArithmeticExpressionAPI.Core;

namespace ArithmeticExpressionAPI.Services
{
    public class ExpressionCalculatorService : IExpressionCalculatorService
    {
        public decimal Calculate(string expression)
        {
            var postfixExpression = ShuntingYardService.ConvertToPostfix(expression,false);
            return ShuntingYardService.Calculate(postfixExpression);
        }

        public decimal CalculateAddOnly(string expression)
        {
            var postfixExpression = ShuntingYardService.ConvertToPostfix(expression, true);
            return ShuntingYardService.Calculate(postfixExpression);
        }
    }
}
