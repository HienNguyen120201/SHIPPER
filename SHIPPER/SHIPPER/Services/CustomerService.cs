using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SHIPPER.Data;
using SHIPPER.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SHIPPER.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly Shipper10DBContext _context;
        private string _connectionString;
        public CustomerService(
             Shipper10DBContext context,
             IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
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
