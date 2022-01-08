using ArithmeticExpressionAPI.Services;
using System.Text.RegularExpressions;

namespace ArithmeticExpressionAPI.Service
{
    public class ExpressionValidatorService : IExpressionValidatorService
    {
        const string infixExpressionRegex = @"^[+-]?([0-9]+\.?[0-9]*|\.[0-9]+)+([+-]([0-9]+\.?[0-9]*|\.[0-9]+)+)*$";
        const string infixExpressionAddOnlyRegex = @"^[+]?([0-9]+\.?[0-9]*|\.[0-9]+)+([+]([0-9]+\.?[0-9]*|\.[0-9]+)+)*$";

        public ExpressionValidatorService()
        {            
        }

        public bool ValidateAddOnly(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))            
                return false;
            
            var result = false;
            var exp = removeWhiteSpaces(expression);

            var regexInfixAddOnlyExpression = new Regex(infixExpressionAddOnlyRegex);
            result = isRegexMatch(regexInfixAddOnlyExpression, exp);

            return result;
        }

        public bool Validate(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))            
                return false;
            
            var result = false;
            string exp = removeWhiteSpaces(expression);

            var regexInfixExpression = new Regex(infixExpressionRegex);
            result = isRegexMatch(regexInfixExpression, exp);

            return result;
        }

        private static string removeWhiteSpaces(string expression)
        {
            return Regex.Replace(expression, @"\s+", "");
        }

        private bool isRegexMatch(Regex regex, string exp)
        {
            return regex.Match(exp).Success;
        }
    }
}