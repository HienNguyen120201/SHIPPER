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
        public async Task<IActionResult> Menu()
        {
            var food = await _customerService.GetFoodAsync();
            return View(food);
        }
        public async Task<IActionResult> InsertMonAn(DonVanChuyenViewModel donVanChuyen)
        {
            await _customerService.InsertFoodAsync(donVanChuyen);
            return RedirectToAction("Menu", "Home");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View(new KhachHangViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Register(KhachHangViewModel khachHang)
        {
            await _customerService.InsertKhachHang(khachHang);
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

        [HttpGet("/QuanLiMonAn")]
        public async Task<IActionResult> QuanLiMonAnAsync()
        {
            string a="";
            QuanLiMonAnViewModel data = await _customerService.QuanLiMonAnAsync(a);
            return View(data);
        }
        [HttpPost("/QuanLiMonAn")]
        public async Task<IActionResult> QuanLiMonAnAsync(QuanLiMonAnViewModel NhaHang)
        {
            if (NhaHang.Type == "search")
            {
                QuanLiMonAnViewModel data = await _customerService.QuanLiMonAnAsync(NhaHang.Add);
                data.Add=NhaHang.Add;
                return View(data);
            }
            else if(NhaHang.Type =="delete")
            {
                _customerService.DeleteMonAn(NhaHang);
                QuanLiMonAnViewModel data = await _customerService.QuanLiMonAnAsync(NhaHang.Add);
                data.Add = NhaHang.Add;
                return View(data);
            }
            else if (NhaHang.Type =="active")
            {
                _customerService.ActiveMonAn(NhaHang);
                QuanLiMonAnViewModel data = await _customerService.QuanLiMonAnAsync(NhaHang.Add);
                data.Add = NhaHang.Add;
                return View(data);
            }
            else if(NhaHang.Type == "insert")
            {
                NhaHang.Insert = !_customerService.InsertMonAn(NhaHang);
                if (NhaHang.Add == null)
                    return View(NhaHang);
                QuanLiMonAnViewModel data1 = await _customerService.QuanLiMonAnAsync(NhaHang.Add);
                data1.Add = NhaHang.Add;
                data1.Insert = NhaHang.Insert;
                return View(data1);
            }
            return View(new QuanLiMonAnViewModel());
        }
    }
}
