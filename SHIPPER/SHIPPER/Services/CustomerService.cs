using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SHIPPER.Data;
using SHIPPER.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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
            using SqlConnection cus = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("insertChiTietDonMonAn", cus)
            {
                CommandType = CommandType.StoredProcedure
            };
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
        public QuanLiMonAnViewModel QuanLiMonAn(string add)
        {
            QuanLiMonAnViewModel result = new QuanLiMonAnViewModel();
            result.listMonAn = new List<MonAnViewModel>();
            result.listTongSoMonAn=new List<TongSoMonAnViewModel>();
            using SqlConnection cus = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("selectMonAnThuocNhaHang", cus)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@diachi", add);
            cus.Open();
            SqlDataReader data=cmd.ExecuteReader();
            while (data.Read())
            {
                MonAnViewModel monAn = new MonAnViewModel
                {
                    NameNhaHang = data["tenNhaHang"].ToString(),
                    NameMonAn = data["tenMonAn"].ToString(),
                    IdNhaHang = int.Parse(data["maNhaHang"].ToString()),
                    IdMonAn = int.Parse(data["maMonAn"].ToString()),
                    Url = data["image"].ToString(),
                    DonGia = int.Parse(data["donGia"].ToString()),
                    isActive = int.Parse(data["isActive"].ToString()),
                    Add = add
                };
                result.listMonAn.Add(monAn);
            }
            cus.Close();
            SqlCommand cmd1 = new SqlCommand("tongSoMonAnofNhaHang", cus)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd1.Parameters.AddWithValue("@diachi1", add);
            cus.Open();
            SqlDataReader data1 = cmd1.ExecuteReader();
            while (data1.Read())
            {
                TongSoMonAnViewModel count = new TongSoMonAnViewModel
                {
                    TongSoMonAn = data1["tongSoMonAn"].ToString(),
                    NameNhaHang = data1["tenNhaHang"].ToString()
                };
                result.listTongSoMonAn.Add(count);
            }
            cus.Close();
            return result;
        }
        public bool DeleteMonAn(QuanLiMonAnViewModel NhaHang)
        {
            var monAn = (from b in _context.MonAn
                         where b.MaMonAn== NhaHang.IdMonAn && b.MaNhaHangOffer == NhaHang.IdNhaHang
                         select b).FirstOrDefault();
            if(monAn == null) return  false;
            monAn.isActive = 0;
            _context.SaveChanges();
            return true;
        }
        public bool ActiveMonAn(QuanLiMonAnViewModel NhaHang)
        {
            var monAn = (from b in _context.MonAn
                         where b.MaMonAn == NhaHang.IdMonAn && b.MaNhaHangOffer == NhaHang.IdNhaHang
                         select b).FirstOrDefault();
            if (monAn == null) return false;
            monAn.isActive = 1;
            _context.SaveChanges();
            return true;
        }
        public bool UpdateMonAn(QuanLiMonAnViewModel NhaHang)
        {
            
            return true;
        }
    }
}
