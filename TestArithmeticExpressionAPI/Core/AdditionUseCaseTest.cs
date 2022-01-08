using ArithmeticExpressionAPI.Core;
using ArithmeticExpressionAPI.Services;
using ArithmeticExpressionAPI.UseCases;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestArithmeticExpressionAPI.Core
{
    [TestClass]
    public class AdditionUseCaseTest
    {
        [TestMethod]
        public void GIVEN_a_valid_addition_expression_WHEN_calculate_is_called_THEN_should_return_the_sum_of_the_values()
        {
            //arrange
            var expressValidatorService = new ExpressionValidatorServiceStub();
            var expressCalculatorService = new ExpressionCalculatorServiceStub();
            var useCase = new AdditionUseCase(expressValidatorService, expressCalculatorService);

            var inExpression = "3+2+5+2";
            var expectedAddition = 12m;

            //act
            var actualAddition = useCase.Execute(inExpression);

            //assert
            Assert.AreEqual(1, expressValidatorService.CountValidateExecution);
            Assert.AreEqual(1, expressCalculatorService.CountCalculateExecution);
            Assert.AreEqual(expectedAddition, actualAddition);
        }

        [TestMethod]
        public void GIVEN_an_invalid_expression_WHEN_calculate_is_called_THEN_should_return_error()
        {
            //arrange
            var expressValidatorService = new ExpressionValidatorServiceStub();
            var expressCalculatorService = new ExpressionCalculatorServiceStub();
            var useCase = new AdditionUseCase(expressValidatorService, expressCalculatorService);

            var inExpression = "3+2+5+2+3-3";
            var expectedExceptionMessage = "Invalid expression. Use infix notatation - operators are written between the operands (numbers) they operate on, e.g. 2 + 3 + 5.";

            //act
            var actualExceptionMessage = string.Empty;
            try
            {
                var actualAddition = useCase.ExecuteAddOnly(inExpression);
            } catch (Exception ex)
            {
                actualExceptionMessage = ex.Message;
            }
            //assert
            Assert.AreEqual(1, expressValidatorService.CountValidateAddOnlyExecution);            
            Assert.AreEqual(expectedExceptionMessage, actualExceptionMessage);
        }
    }

    internal class ExpressionValidatorServiceStub : IExpressionValidatorService
    {
        private int countExecution = 0;
        private int countAddOnlyExecution = 0;

        public int CountValidateExecution { get => countExecution; set => countExecution = value; }
        public int CountValidateAddOnlyExecution { get => countAddOnlyExecution; set => countAddOnlyExecution = value; }

        public bool Validate(string expression)
        {
            countExecution++;
            return true;
        }

        public bool ValidateAddOnly(string expression)
        {
            countAddOnlyExecution++;
            return false;
        }
    }

    internal class ExpressionCalculatorServiceStub : IExpressionCalculatorService
    {
        private int countExecution = 0;

        public int CountCalculateExecution { get => countExecution; set => countExecution = value; }

        public decimal Calculate(string expression)
        {
            countExecution++;
            return 12;
        }

        public decimal CalculateAddOnly(string expression)
        {
            throw new NotImplementedException();
        }
    }
}