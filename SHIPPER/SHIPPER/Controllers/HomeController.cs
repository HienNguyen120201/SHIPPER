using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SHIPPER.Data;
using SHIPPER.Models;
using SHIPPER.Services;

namespace SHIPPER.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<HomeController> _logger;
        private readonly ICustomerService _customerService;
        private readonly Shipper10DBContext _context;
        public HomeController(ILogger<HomeController> logger, ICustomerService customerService, Shipper10DBContext context,IEmployeeService employeeService)
        {
            _logger = logger;
            _customerService = customerService;
            _context = context;
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<IActionResult> Menu()
        {
            var food = await _customerService.GetFoodAsync();
            return View(food);
        }
        public  ActionResult GetUuDai(int id)
        {
            var uuDai = _customerService.GetThongTinUuDai(id);
            return View(uuDai);
        }
        [HttpPost]
        public async Task<IActionResult> Menu(FoodViewModel food)
        {
            var check = await _customerService.InsertFoodAsync(food.DonVanChuyen);
            if(check == false)
            {
                var food1 = await _customerService.GetFoodAsync();
                food1[1].check = true;
                return View(food1);
            }    
            return RedirectToAction("Menu", "Home");
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View(new KhachHangViewModel());
        }
        [HttpPost]
        public IActionResult Register(KhachHangViewModel khachHang)
        {
            if (!ModelState.IsValid)
            {
                return View(khachHang);
            }
            var cmnd = (from K in _context.KhachHang
                        where K.CccdorVisa == khachHang.Cmnd
                        select K).FirstOrDefault();
            var tenTaiKhoan = (from K in _context.KhachHang
                               where K.TaiKhoan == khachHang.TaiKhoan
                               select K).FirstOrDefault();
            if (cmnd!=null || tenTaiKhoan!=null)
            {
                khachHang.ErrorMessage = "Tài khoản đã tồn tại";
                return View(khachHang);
            }    
            _customerService.InsertKhachHang(khachHang);
            return RedirectToAction("Index", "Home");
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
        public async Task<ActionResult> dinh()
        {
            string a = "";
            var donVanChuyen = await _customerService.DinhAsync(a,0,0);
            return View(donVanChuyen);
        }
        [HttpPost]
        public async Task<ActionResult> dinh(EditDonVanChuyenViewModel e)
        {
            if(e.Action=="search")
            {
                if (e.maTrangThai == 7)
                {
                    e.maTrangThai = 0;
                    e.Action = "";
                }
                var donVanChuyen1 = await _customerService.DinhAsync(e.Action, e.maTrangThai,0);
                return View(donVanChuyen1);
            }    
            if(e.Action=="q")
            {
                await _customerService.DinhAsync(e.Action, e.maTrangThai, e.ID);
                e.Action = "search";
            }
            
            var donVanChuyen = await _customerService.DinhAsync(e.Action, e.maTrangThai,0);
            return View(donVanChuyen);
        }
    }
}
