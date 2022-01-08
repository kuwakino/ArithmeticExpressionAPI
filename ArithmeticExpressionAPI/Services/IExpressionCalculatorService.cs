namespace ArithmeticExpressionAPI.Core
{
    public interface IExpressionCalculatorService
    {
        decimal Calculate(string expression);
        decimal CalculateAddOnly(string expression);
    }
}