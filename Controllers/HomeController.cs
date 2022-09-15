using LoanCalc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using LoanCalc.Helpers;

namespace LoanCalc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LoanCalc()
        {
            Loan loan = new();

            loan.PaymentAmount = 0.0m;
            loan.TotalInterest = 0.0m;
            loan.TotalCost = 0.0m;
            loan.Rate = 0.0m;
            loan.Amount = 0.0m;
            loan.Term = 60;

            return View(loan);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult LoanCalc(Loan loan)
        {
            //Calculate loan.
            var loanCalc = new LoanCalculation();

            Loan l = loanCalc.GetPayments(loan);

            return View(l);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}