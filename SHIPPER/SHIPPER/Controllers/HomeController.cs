using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SHIPPER.Models;
using SHIPPER.Services;

namespace SHIPPER.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerService _customerService;
        public HomeController(ILogger<HomeController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }
        public async Task<IActionResult> Menu(int[] Category)
        {
            var food = await _customerService.GetFoodAsync(Category);
            return View(food);
        }
        public IActionResult InsertProduct()
        {
            _customerService.InsertFoodAsync(User);
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Index()
        {
            return View();
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
