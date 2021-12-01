using Microsoft.AspNetCore.Mvc;
using SHIPPER.Models;
using SHIPPER.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHIPPER.Controllers
{
    public class ChiNhanhController : Controller
    {
        private readonly IChiNhanhService _chinhanhService;
        public ChiNhanhController(IChiNhanhService chinhanhService)
        {
            _chinhanhService = chinhanhService;
        }
        [HttpGet]
        public async Task<IActionResult> AddChiNhanh()
        {
            QuanLyChiNhanhViewModel result= await _chinhanhService.GetListPageChiNhanh();
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> AddChiNhanh(QuanLyChiNhanhViewModel qlchinhanhVM)
        {
            if (!ModelState.IsValid)
            {
                QuanLyChiNhanhViewModel result = await _chinhanhService.GetListPageChiNhanh();
                qlchinhanhVM.ListChiNhanh = result.ListChiNhanh;
                qlchinhanhVM.ListQuanLy = result.ListQuanLy;
                return View(qlchinhanhVM);
            }
             await _chinhanhService.InsertChiNhanh(qlchinhanhVM.ChiNhanh);
            return RedirectToAction("AddChiNhanh", "ChiNhanh");
        }


        public IActionResult SubmitChiNhanh(ChiNhanhViewModel chinhanhVM )
        {
            if (!ModelState.IsValid)
            {
                return View(chinhanhVM);
            }
            _chinhanhService.InsertChiNhanh(chinhanhVM);
            return RedirectToAction("AddChiNhanh","ChiNhanh");
        }
        public IActionResult ChitietChiNhanh()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateChiNhanh(int id)
        {
            QuanLyChiNhanhViewModel result = await _chinhanhService.GetListPageUpdateChiNhanh(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateChiNhanh(QuanLyChiNhanhViewModel qlchinhanhVM)
        {
            if (!ModelState.IsValid)
            {
                return View(qlchinhanhVM);
            }
           await _chinhanhService.UpdateChiNhanh(qlchinhanhVM.ChiNhanh);
            return RedirectToAction("AddChiNhanh", "ChiNhanh");
        }
        public async Task<IActionResult> DeleteChiNhanh(int idChiNhanh)
        {
            await _chinhanhService.DeleteChiNhanh(idChiNhanh);
            return RedirectToAction("AddChiNhanh", "ChiNhanh");
        }

    }
}
