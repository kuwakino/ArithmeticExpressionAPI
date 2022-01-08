namespace ArithmeticExpressionAPI.Core
{
    public interface IExpressionCalculatorService
    {
        decimal Calculate(string expression);
    }
}