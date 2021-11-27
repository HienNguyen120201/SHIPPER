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
        void GetKhachHang(int cmnd);
        public void insertChiTietDonMonAn();
        Task<List<FoodViewModel>> GetFoodAsync();
        Task InsertFoodAsync(DonVanChuyenViewModel donVanChuyen);
    }
}
