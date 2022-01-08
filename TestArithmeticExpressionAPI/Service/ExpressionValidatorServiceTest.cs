﻿using ArithmeticExpressionAPI.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestArithmeticExpressionAPI.Service
{
    [TestClass]
    public class ExpressionValidatorServiceTest
    {
        [TestMethod]
        public void GIVEN_valid_expressions_WHEN_expressions_validated_THEN_should_return_true_for_each_expression() {
            //arrange
            string[] expressions = {
                "3 + 5 + 6 + 3",
                "5 - 2 + 4 - 3 + 2",
                "3.1 + 2 - 1",
                "-2.3 + 5",
                "2 - 1.5",
                "2003",
                "-1999",
            };
            var expressionValidator = new ExpressionValidatorService();

            //act
            var result = expressions.Select(e => new { expression = e, isValid = expressionValidator.Validate(e) });

            //assert
            foreach (var r in result)
            {
                Assert.IsTrue(r.isValid,"Failed for: "+ r.expression);
            }
        }
    }
}