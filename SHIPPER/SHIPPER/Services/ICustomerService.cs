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
        public QuanLiMonAnViewModel QuanLiMonAn(string add);
        public bool DeleteMonAn(QuanLiMonAnViewModel NhaHang);
        public bool UpdateMonAn(QuanLiMonAnViewModel NhaHang);
        public bool ActiveMonAn(QuanLiMonAnViewModel NhaHang);
        Task<List<FoodViewModel>> GetFoodAsync();
        Task InsertFoodAsync(DonVanChuyenViewModel donVanChuyen);
        Task InsertKhachHang(KhachHangViewModel khachHang);
    }
}
