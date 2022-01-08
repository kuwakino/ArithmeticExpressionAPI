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
            var expressValidatorService = new ExpressValidatorServiceStub();
            var expressCalculatorService = new ExpressCalculatorServiceStub();
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
    }

    internal class ExpressValidatorServiceStub : IExpressionValidatorService
    {
        private int countExecution = 0;

        public int CountValidateExecution { get => countExecution; set => countExecution = value; }

        public bool Validate(string expression)
        {
            countExecution++;
            return true;
        }
    }

    internal class ExpressCalculatorServiceStub : IExpressionCalculatorService
    {
        private int countExecution = 0;

        public int CountCalculateExecution { get => countExecution; set => countExecution = value; }

        public decimal Calculate(string expression)
        {
            countExecution++;
            return 12;
        }
    }
}