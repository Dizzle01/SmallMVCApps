using LoanCalculator.Helpers;
using LoanCalculator.Models;
using Microsoft.AspNetCore.Mvc;

namespace SmallMVCApps.Controllers
{
    public class LoanController : Controller
    {
        [HttpGet]
        public IActionResult Calculate()
        {
            Loan loan = new();

            loan.Payment = 0.0m;
            loan.TotalInterest = 0.0m;
            loan.TotalCost = 0.0m;
            loan.Rate = 3m;
            loan.Amount = 150000m;
            loan.Term = 60;

            return View(loan);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Calculate(Loan loan)
        {
            //Calculate the Loan
            var loanHelper = new LoanHelper();

            Loan newLoan = loanHelper.GetPayments(loan);

            return View(newLoan);
        }
    }
}
