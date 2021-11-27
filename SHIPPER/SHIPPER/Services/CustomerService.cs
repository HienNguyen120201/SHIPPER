using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SHIPPER.Data;
using SHIPPER.Data.Entities;
using SHIPPER.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SHIPPER.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly Shipper10DBContext _context;
        private string _connectionString;
        private readonly UserManager<KhachHang> _userManager;
        public CustomerService(
             Shipper10DBContext context,
             IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<List<FoodViewModel>> GetFoodAsync(int[] Category)
        {
            var food = await (from l in _context.MonAn
                               select new FoodViewModel
                               {
                                   MaMonAn=l.MaMonAn,
                                   DonGia=l.DonGia,
                                   MaNhaHang=l.MaNhaHangOffer,
                                   MoTa=l.MoTa,
                                   TenMonAn=l.TenMonAn
                               }).ToListAsync();
            return food;
        }
        public async Task InsertFoodAsync(ClaimsPrincipal user)
        {
            var customer = await _userManager.GetUserAsync(user);
            using (SqlConnection don = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("insertDonVanChuyen", don);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@diaChiGiaoHang", "Hoa Tan Tay");
                cmd.Parameters.AddWithValue("@thoiGianGiaoHang", DateTime.UtcNow);
                cmd.Parameters.AddWithValue("@thoiGianNhan", DateTime.UtcNow);
                cmd.Parameters.AddWithValue("@maTrangThaiDonHang", 2);
                cmd.Parameters.AddWithValue("@tienShip", 5000);
                cmd.Parameters.AddWithValue("@maPhuongThucThanhToan", 1);
                cmd.Parameters.AddWithValue("@maKhachHang", "1B313134-292A-40BA-9A1E-2A6F12A3BFD8");
                don.Open();
                cmd.ExecuteNonQuery();
                don.Close();
            }
        }
        public void GetKhachHang(int cmnd)
        {
            using (SqlConnection cus = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("timKhachHangUuDai", cus);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cmnd", cmnd);
                cus.Open();
                SqlDataReader customer = cmd.ExecuteReader();
                customer.ReadAsync();
                var khach = new KhachHangUuDaiViewModel();
                khach.discount = customer["discount"].ToString();
                khach.FullName = customer["Fullname"].ToString();
                khach.mota = customer["mota"].ToString();
            }
        }
        public void insertChiTietDonMonAn()
        {
            using (SqlConnection cus = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("insertChiTietDonMonAn", cus);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@a_maDonMonAn", 22);
                cmd.Parameters.AddWithValue("@a_maMonAn", 2);
                cmd.Parameters.AddWithValue("@a_soLuong", 2);
                cmd.Parameters.AddWithValue("@a_apDungUuDai", 0);
                cmd.Parameters.AddWithValue("@a_donGiaMon", 50000);
                cmd.Parameters.AddWithValue("@a_donGiaUuDai", 50000);
                cus.Open();
                cmd.ExecuteNonQuery();
                cus.Close();
            }
        }
    }
}
