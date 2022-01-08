using ArithmeticExpressionAPI.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestArithmeticExpressionAPI.Service
{
    [TestClass]
    public class ShuntingYardServiceTest
    {
        [TestMethod]
        public void GIVEN_valid_infix_expressions_WHEN_expressions_converted_THEN_should_return_postfix_for_each_expression()
        {
            //arrange
            string[] expressions = {
                "3+5+6+3",
                "5-2+4-3+2",
                "2003",
                "-1999",
                "3.1+2-1",
                "-2.3+5",
                "2-1.5",
            };
            string[] expressionsExpected = {
                "3 5 + 6 + 3 +",
                "5 2 - 4 + 3 - 2 +",
                "2003",
                "1999 -",
                "3.1 2 + 1 -",
                "2.3 - 5 +",
                "2 1.5 -",

            };

            //act
            var result = expressions.Select(e => new { expression = e, posfix = ShuntingYardService.ConvertToPostfix(e, false) }).ToArray();

            //assert
            for (int i = 0; i < result.Count(); i++)
            {
                Assert.AreEqual(expressionsExpected[i], result[i].posfix, "Failed for: " + result[i].expression);
            }
        }

        [TestMethod]
        public void GIVEN_valid_postfix_expressions_WHEN_evaluated_THEN_should_return_the_expression_calculated()
        {
            //arrange
            string[] expressions = {
                "3 5 + 6 + 3 +",
                "5 2 - 4 + 3 - 2 +",
                "2003",
                "-1999",
                "3.1 2 + 1 -",
                "2.3 - 5 +",
                "2 1.5 -",

            };
            decimal[] expectedResults = {
                17,
                6,
                2003,
                -1999,
                4.1m,
                2.7m,
                0.5m,
            };

            //act
            var result = expressions.Select(e => new { expression = e, posfix = ShuntingYardService.Calculate(e) }).ToArray();

            //assert
            for (int i = 0; i < result.Count(); i++)
            {
                Assert.AreEqual(expectedResults[i], result[i].posfix, "Failed for: " + result[i].expression);
            }
        }
    }
}
