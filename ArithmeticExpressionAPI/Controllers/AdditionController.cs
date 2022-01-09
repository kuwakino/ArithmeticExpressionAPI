using ArithmeticExpressionAPI.Service;
using ArithmeticExpressionAPI.Services;
using ArithmeticExpressionAPI.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace ArithmeticExpressionAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class AdditionController : Controller
    {
        private ExpressionValidatorService validatorService;
        private ExpressionCalculatorService calculatorService;

        public AdditionController()
        {
            validatorService = new ExpressionValidatorService();
            calculatorService = new ExpressionCalculatorService();
        }

        /// <summary>
        /// Evaluate the arithmetimetic expression. Accepts only addition (+) and subtraction (-) operations.
        /// </summary>
        /// <param name="expression">examples: 3 + 5 + 6 + 3; 5 - 2 + 4 - 3 + 2;</param>
        /// <returns>The calculation of the expression.</returns>
        [HttpPost("/calculate")]
        public decimal Calculate(string expression)
        {
            var usecase = new AdditionUseCase(validatorService, calculatorService);
            return usecase.Execute(expression);
        }
        /// <summary>
        /// Evaluate the arithmetimetic expression. Accepts only addition (+) operations.
        /// </summary>
        /// <param name="expression">examples: 3 + 5 + 6 + 3; 3.1 + 2;</param>
        /// <returns>The calculation of the expression.</returns>
        [HttpPost("/addtiononly")]
        public decimal AddtionOnly(string expression)
        {
            var usecase = new AdditionUseCase(validatorService, calculatorService);
            return usecase.ExecuteAddOnly(expression);
        }
    }
}
