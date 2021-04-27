using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FinanceSamples.Models;
using FinanceSamples.Calculations;

namespace FinanceSamples.Controllers
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

        public IActionResult FinanceSamples()
        {
            return View();
        }

        public IActionResult Credit()
        {
            CreditData data = new CreditData();
            return View(data);
        }

        [HttpPost]
        public IActionResult Credit(CreditData data)
        {
            Calculate.Credit(data);
            return View(data);
        }

        public IActionResult Deposit()
        {
            DepositData data = new DepositData();
            return View(data);
        }

        [HttpPost]
        public IActionResult Deposit(DepositData data)
        {
            Calculate.Deposit(data);
            return View(data);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
