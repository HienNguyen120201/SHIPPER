using Microsoft.AspNetCore.Mvc;
using SHIPPER.Data;
using SHIPPER.Models;
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
        private readonly Shipper10DBContext _context;
        public AdminController(IAdminService adminService, Shipper10DBContext context)
        {
            _adminService = adminService;
            _context = context;
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
        public IActionResult UpdateKhachHang(int cmnd, string matkhau)
        {
            _adminService.UpdateKhachHang(cmnd,matkhau);
            return RedirectToAction("KhachHang", "Admin");
        }
        public async Task<IActionResult> ChiTietDonMonAn()
        {
            var chiTiet = await _adminService.GetChiTietDonMonAnAsync();
            return View(chiTiet);
        }
        public IActionResult DeleteChiTietDonMonAn(int maDon, int maMon)
        {
            _adminService.DeleteChiTietDonMonAn(maDon,maMon);
            return RedirectToAction("ChiTietDonMonAn", "Admin");
        }
        public IActionResult UpdateChiTietDonMonAn(int maDon, int maMon,int soluong)
        {
            _adminService.UpdateChiTietDonMonAn(maDon, maMon,soluong);
            return RedirectToAction("ChiTietDonMonAn", "Admin");
        }
        [HttpGet]
        public async Task<IActionResult> PhuongTien()
        {
            var phuongTien = await _adminService.GetPhuongTiensAsync();
            return View(phuongTien);
        }
        public IActionResult TimNhanVienPhuongTien(int id)
        {
            var phuongTien = (from S in _context.Shipper
                              join N in _context.NhanVien on S.MaNhanVien equals N.MaNhanVien
                              join P in _context.PhuongTien on S.BienKiemSoat equals P.BienKiemSoat
                              where S.BienKiemSoat == id.ToString()
                              select S).FirstOrDefault();
            if(phuongTien==null)
            {
                var newNhanVien = new NhanVienPhuongTienViewModel
                {
                    BienKiemSoat = id.ToString()
                };
                return View(newNhanVien);
            }    
            var nhanVien = _adminService.GetNhanVienPhuongTien(id);
            return View(nhanVien);
        }
        [HttpPost]
        public async Task<IActionResult> PhuongTien(string bienso)
        {
            var shipper = (from P in _context.Shipper
                              where P.BienKiemSoat == bienso
                              select P).FirstOrDefault();
            if(shipper!=null)
            {
                var phuongTien= await _adminService.GetPhuongTiensAsync();
                phuongTien[1].check = true;
                return View(phuongTien);
            }    
            _adminService.DeletePhuongTien(bienso);
            return RedirectToAction("PhuongTien", "Admin");
        }
        public IActionResult UpdatePhuongTien(string bienso, string gplx)
        {
            _adminService.UpdatePhuongTien(bienso, gplx);
            return RedirectToAction("PhuongTien", "Admin");
        }
        public IActionResult InsertPhuongTien(string bienso, string loai, string hinh, string giayphep)
        {
            _adminService.InsertPhuongTien(bienso, loai, hinh, giayphep);
            return RedirectToAction("PhuongTien", "Admin");
        }
    }
}
