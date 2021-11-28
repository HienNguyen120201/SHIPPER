using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SHIPPER.Data;
using SHIPPER.Data.Entities;
using SHIPPER.Models;
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
        public CustomerService(
             Shipper10DBContext context,
             IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<List<FoodViewModel>> GetFoodAsync()
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
        public async Task InsertFoodAsync(DonVanChuyenViewModel donVanChuyen)
        {
            var IdKhachHang = await (from K in _context.KhachHang
                                   where K.CccdorVisa == donVanChuyen.Cccd
                                   select K.MaKhachHang).FirstOrDefaultAsync();
            var IdThanhtoan = await (from P in _context.PhuongThucThanhToan
                                     where P.PhuongThucThanhToan1 == donVanChuyen.PhuongThucThanhToan
                                     select P.MaPhuongThuc).FirstOrDefaultAsync();
            var DonGia = await (from M in _context.MonAn
                                where M.MaMonAn == donVanChuyen.MaMonAn
                                select M.DonGia).FirstOrDefaultAsync();
            using (SqlConnection don = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("insertDonVanChuyen", don);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@diaChiGiaoHang", donVanChuyen.DiaChiGiaoHang);
                cmd.Parameters.AddWithValue("@thoiGianGiaoHang", DateTime.UtcNow);
                cmd.Parameters.AddWithValue("@thoiGianNhan", DateTime.Now);
                cmd.Parameters.AddWithValue("@maTrangThaiDonHang", 6);
                cmd.Parameters.AddWithValue("@tienShip", 5000);
                cmd.Parameters.AddWithValue("@maPhuongThucThanhToan", 5);
                cmd.Parameters.AddWithValue("@maKhachHang", IdKhachHang);
                don.Open();
                cmd.ExecuteNonQuery();
                don.Close();
            }
            var newIdDon = await (from d in _context.DonVanChuyen
                                  where d.MaKhachHang == IdKhachHang && d.MaPhuongThucThanhToan == 5
                                  select d.MaDon).FirstOrDefaultAsync();
            var newDonMonAn = new DonMonAn
            {
                MaDon = newIdDon
            };
            _context.DonMonAn.Add(newDonMonAn);
            _context.SaveChanges();
            var donVanChuyen1 = await (from D in _context.DonVanChuyen
                                     where D.MaDon == newIdDon
                                     select D).FirstOrDefaultAsync();
            donVanChuyen1.MaPhuongThucThanhToan = IdThanhtoan;
            var donMonAn = await (from D in _context.DonMonAn
                                  where D.MaDon == newIdDon
                                  select D).FirstOrDefaultAsync();
            donMonAn.TongTienMon = donVanChuyen.SoLuong * DonGia;
            _context.SaveChanges();
            using (SqlConnection cus = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("insertChiTietDonMonAn", cus);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@a_maDonMonAn", newIdDon);
                cmd.Parameters.AddWithValue("@a_maMonAn", donVanChuyen.MaMonAn);
                cmd.Parameters.AddWithValue("@a_soLuong", donVanChuyen.SoLuong);
                cmd.Parameters.AddWithValue("@a_apDungUuDai", 0);
                cmd.Parameters.AddWithValue("@a_donGiaMon", DonGia);
                cmd.Parameters.AddWithValue("@a_donGiaUuDai", DonGia);
                cus.Open();
                cmd.ExecuteNonQuery();
                cus.Close();
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
