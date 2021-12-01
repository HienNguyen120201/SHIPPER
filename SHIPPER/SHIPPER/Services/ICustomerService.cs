using SHIPPER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SHIPPER.Services
{
    public interface ICustomerService
    {
        Task<QuanLiMonAnViewModel> QuanLiMonAnAsync(string add);
        Task<List<EditDonVanChuyenViewModel>> DinhAsync(string a, int b, int c);
        public bool DeleteMonAn(QuanLiMonAnViewModel NhaHang);
        public bool ActiveMonAn(QuanLiMonAnViewModel NhaHang);
        public bool InsertMonAn(QuanLiMonAnViewModel NhaHang);
        Task<List<FoodViewModel>> GetFoodAsync();
        Task<bool> InsertFoodAsync(DonVanChuyenViewModel donVanChuyen);
        public void InsertKhachHang(KhachHangViewModel khachHang);
        public List<ThongTinUuDaiViewModel> GetThongTinUuDai(int id);
    }
}
