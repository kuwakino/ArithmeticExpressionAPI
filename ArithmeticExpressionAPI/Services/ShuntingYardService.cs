using System.Text;

namespace ArithmeticExpressionAPI.Services
{
    public static class ShuntingYardService
    {
        const string numbersChars = "0123456789.";

        public static string ConvertToPostfix(string infixExpression, bool addOnly)
        {
            string operatorsChars = "+-";
            if (addOnly)                 
                operatorsChars = "+";

            var output = new StringBuilder();
            var ops = new Stack<char>();
            var values = new Stack<int>();
            var number = string.Empty;

            var enumerableInfixTokens = new List<string>();
            foreach (char c in infixExpression)
            {
                if (operatorsChars.Contains(c))
                {
                    if (number.Length > 0)
                    {
                        enumerableInfixTokens.Add(number);
                        number = string.Empty;
                    }
                    enumerableInfixTokens.Add(c.ToString());
                }
                else if (numbersChars.Contains(c))
                {
                    number += c.ToString();
                }
                else
                {
                    throw new Exception(string.Format("Invalid character '{0}'.", c));
                }
            }

            if (number.Length > 0)
            {
                enumerableInfixTokens.Add(number);
                number = string.Empty;
            }

            foreach (string token in enumerableInfixTokens)
            {
                var isNumber = token.All(c => numbersChars.Contains(c));
                if (isNumber)
                {
                    output.Append(token + ' ');
                }
                else if (token.Length == 1)
                {
                    var c = token[0];

                    if (numbersChars.Contains(c)) // numbers
                    {
                        output.Append(c.ToString() + ' ');
                    }
                    else if (operatorsChars.Contains(c)) // operators
                    {
                        if (ops.Count > 0)
                        {
                            output.Append(ops.Pop().ToString() + ' ');
                        }
                        ops.Push(c);
                    }
                    else
                    {
                        throw new Exception(string.Format("Invalid character '{0}'.", c));
                    }
                }
                else
                {
                    output.Append(token + ' ');
                }
            }

            while (ops.Count > 0)
            {
                var o = ops.Pop();
                output.Append(o.ToString() + ' ');
            }

            return output.ToString().Trim();
        }

        public static decimal Calculate(string postfixExpression)
        {
            decimal result = 0m;

            var tokens = postfixExpression.Split(' ');
            var operands = new Stack<decimal>();
            var cInfo = new System.Globalization.CultureInfo("en-US");
            foreach (var token in tokens)
            {
                var value = 0m;
                switch (token)
                {                    
                    case "+":
                        value = PullValue(operands) + PullValue(operands);
                        break;
                    case "-":
                        value = -PullValue(operands) + PullValue(operands);
                        break;
                    default:
                        value = Convert.ToDecimal(token, cInfo);
                        break;
                }
                operands.Push(Convert.ToDecimal(value, cInfo));
                
            }
            result = operands.Pop();

            return result;
        }

        private static decimal PullValue(Stack<decimal> operands)
        {
            if (operands.Count == 0)
                return 0;
            return operands.Pop();
        }

    }
}