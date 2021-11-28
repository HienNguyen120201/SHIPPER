using Microsoft.AspNetCore.Mvc;
using SHIPPER.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHIPPER.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public async Task<IActionResult> KhachHang()
        {
            var khachHang =await _adminService.GetKhachHangAsync();
            return View(khachHang);
        }
        public async Task<IActionResult> KhachHangUuDai(int cmnd)
        {
            var khachHang = await _adminService.TimUuDaiKhachHang(cmnd);
            return View(khachHang);
        }
        public IActionResult DeleteKhachHang(int cmnd)
        {
            _adminService.DeleteKhachHang(cmnd);
            return RedirectToAction("KhachHang","Admin");
        }
        public async Task<IActionResult> ChiTietDonMonAn()
        {
            var chiTiet = await _adminService.GetChiTietDonMonAnAsync();
            return View(chiTiet);
        }
        public IActionResult DeleteChiTietDonMonAn(int maDon, int maMon)
        {
            _adminService.DeleteChiTietDonMonAn(maDon,maMon);
            return RedirectToAction("ChiTietMonAn", "Admin");
        }
        public IActionResult UpdateChiTietDonMonAn(int maDon, int maMon)
        {
            _adminService.UpdateChiTietDonMonAn(maDon, maMon);
            return RedirectToAction("KhachHang", "Admin");
        }
    }
}
