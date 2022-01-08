namespace ArithmeticExpressionAPI.Services
{
    public interface IExpressionValidatorService
    {
        bool Validate(string expression);
        bool ValidateAddOnly(string expression);
    }
}