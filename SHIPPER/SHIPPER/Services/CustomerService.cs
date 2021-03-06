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
        public CustomerService(
             Shipper10DBContext context,
             IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task<List<EditDonVanChuyenViewModel>> DinhAsync(string a, int b, int c)
        {
            List<EditDonVanChuyenViewModel> result = new List<EditDonVanChuyenViewModel>();
            using SqlConnection cus = new SqlConnection(_connectionString);
            if(a=="search")
            {
                SqlCommand cmd1 = new SqlCommand("selectDonVanChuyen1", cus)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd1.Parameters.AddWithValue("@maTrangThai", b);
                cus.Open();
                SqlDataReader data1 = cmd1.ExecuteReader();
                while (await data1.ReadAsync())
                {
                    EditDonVanChuyenViewModel monAn = new EditDonVanChuyenViewModel
                    {
                        ID = int.Parse(data1["maDon"].ToString()),
                        Add = data1["diaChiGiaoHang"].ToString(),
                        Giao = DateTime.Parse(data1["thoiGianGiaoHang"].ToString()),
                        Nhan = DateTime.Parse(data1["thoiGianNhan"].ToString()),
                        TienShip = int.Parse(data1["tienShip"].ToString()),
                        PhuongThucThanhToan = data1["phuongThucThanhToan"].ToString(),
                        TrangThai = data1["trangThai"].ToString(),
                        CCCD = data1["CCCDorVisa"].ToString(),
                        Ho = data1["ho"].ToString(),
                        TenLot = data1["tenLot"].ToString(),
                        Ten = data1["Ten"].ToString()
                    };
                    result.Add(monAn);
                }
                cus.Close();
                return result;
            }
            if(a=="q")
            {
                var data12 = await (from x in _context.DonVanChuyen
                                    where x.MaDon == c
                                    select x).FirstOrDefaultAsync();
                data12.MaTrangThaiDonHang = b;
                _context.SaveChanges();
                return new List<EditDonVanChuyenViewModel>();
            }    
            SqlCommand cmd = new SqlCommand("selectDonVanChuyen", cus)
            {
                CommandType = CommandType.StoredProcedure
            };
            cus.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (await data.ReadAsync())
            {
                EditDonVanChuyenViewModel monAn = new EditDonVanChuyenViewModel
                {
                    ID = int.Parse(data["maDon"].ToString()),
                    Add = data["diaChiGiaoHang"].ToString(),
                    Giao = DateTime.Parse(data["thoiGianGiaoHang"].ToString()),
                    Nhan = DateTime.Parse(data["thoiGianNhan"].ToString()),
                    TienShip = int.Parse(data["tienShip"].ToString()),
                    PhuongThucThanhToan = data["phuongThucThanhToan"].ToString(),
                    TrangThai = data["trangThai"].ToString(),
                    CCCD = data["CCCDorVisa"].ToString(),
                    Ho = data["ho"].ToString(),
                    TenLot = data["tenLot"].ToString(),
                    Ten = data["Ten"].ToString()
                };
                result.Add(monAn);
            }
            cus.Close();
            return result;
        }    
        public async Task<List<FoodViewModel>> GetFoodAsync()
        {
            var food = await (from l in _context.MonAn
                              where l.isActive==1
                               select new FoodViewModel
                               {
                                   ImgUrl=l.Image,
                                   MaMonAn=l.MaMonAn,
                                   DonGia=l.DonGia,
                                   MaNhaHang=l.MaNhaHangOffer,
                                   MoTa=l.MoTa,
                                   TenMonAn=l.TenMonAn
                               }).ToListAsync();
            return food;
        }
        public List<ThongTinUuDaiViewModel> GetThongTinUuDai(int id)
        {
            var list = new List<ThongTinUuDaiViewModel>();
            using (SqlConnection cus = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("thongTinUuDai", cus);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idMonAn",id);
                cus.Open();
                SqlDataReader customer = cmd.ExecuteReader();
                while (customer.Read())
                {
                    ThongTinUuDaiViewModel uuDai = new ThongTinUuDaiViewModel()
                    {
                        TenMonAn = customer["tenMonAn"].ToString(),
                        TenUuDai = customer["tenUuDai"].ToString(),
                        MoTa=customer["moTa"].ToString(),
                        Discount = double.Parse(customer["discount"].ToString()),
                        NgayHetHan = DateTime.Parse(customer["ngayHetHan"].ToString()),
                        DonGia = int.Parse(customer["donGia"].ToString()),
                        GiaUuDai = double.Parse(customer["giaDaUuDai"].ToString())
                    };
                    list.Add(uuDai);
                }
                cus.Close();
            }
            return list;
        }
        public async Task<bool> InsertFoodAsync(DonVanChuyenViewModel donVanChuyen)
        {
            var KhachHang = await (from K in _context.KhachHang
                                   where K.CccdorVisa == donVanChuyen.Cccd
                                   select K).FirstOrDefaultAsync();
            if (KhachHang == null) return false;
            var IdKhachHang = KhachHang.MaKhachHang;
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
            return true;
        }
        public void InsertKhachHang(KhachHangViewModel khachHang)
        {
            using (SqlConnection customer = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert_KhachHang", customer);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p_CCCDorVisa", khachHang.Cmnd);
                cmd.Parameters.AddWithValue("@p_ho", khachHang.Ho);
                cmd.Parameters.AddWithValue("@p_tenLot", khachHang.TenLot);
                cmd.Parameters.AddWithValue("@p_Ten", khachHang.Ten);
                cmd.Parameters.AddWithValue("@p_ngaySinh", khachHang.NgaySinh);
                cmd.Parameters.AddWithValue("@p_gioiTinh", khachHang.GioiTinh);
                cmd.Parameters.AddWithValue("@p_taiKhoan", khachHang.TaiKhoan);
                cmd.Parameters.AddWithValue("@p_matKhau", khachHang.MatKhau);
                customer.Open();
                cmd.ExecuteNonQuery();
                customer.Close();
            }
        }
        public async Task<QuanLiMonAnViewModel> QuanLiMonAnAsync(string add)
        {
            QuanLiMonAnViewModel result = new QuanLiMonAnViewModel
            {
                listMonAn = new List<MonAnViewModel>(),
                listTongSoMonAn = new List<TongSoMonAnViewModel>()
            };
            if (add==""||add== null)
            {
                var x= await (from a in _context.MonAn
                          from b in _context.NhaHang
                          where a.MaNhaHangOffer==b.MaNhaHang
                          orderby a.isActive descending,b.TenNhaHang,a.TenMonAn
                           select new MonAnViewModel
                           {
                                NameNhaHang=b.TenNhaHang,
                                NameMonAn=a.TenMonAn,
                                IdNhaHang=b.MaNhaHang,
                                IdMonAn=a.MaMonAn,
                                Url=a.Image,
                                DonGia=a.DonGia,
                                isActive=a.isActive,
                                Add=b.DiaChi
                           }).ToListAsync();
                result.listMonAn = x;
                return result;
            }
            using SqlConnection cus = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("selectMonAnThuocNhaHang", cus)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@diachi", add);
            cus.Open();
            SqlDataReader data=cmd.ExecuteReader();
            while (await data.ReadAsync())
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
            while (await data1.ReadAsync())
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
        public bool InsertMonAn(QuanLiMonAnViewModel NhaHang)
        {
            var data1 = (from b in _context.NhaHang
                         where b.MaNhaHang == NhaHang.IdNhaHang
                         select b).FirstOrDefault();
            if(data1== null) return false;
            var data = (from b in _context.MonAn
                        where b.MaNhaHangOffer == NhaHang.IdNhaHang && b.TenMonAn==NhaHang.NameMonAn
                        select b).FirstOrDefault();
            if(data!=null)
            {
                if(NhaHang.Description!=null)
                    data.MoTa = NhaHang.Description;
                data.DonGia = NhaHang.Price;
                if (NhaHang.ImgUrl != null)
                    data.Image = NhaHang.ImgUrl;
                _context.SaveChanges();
                return true;
            }    
            var monAn = new MonAn()
            {
                TenMonAn = NhaHang.NameMonAn,
                DonGia = NhaHang.Price,
                MoTa = NhaHang.Description,
                MaNhaHangOffer = NhaHang.IdNhaHang,
                Image = NhaHang.ImgUrl
            };
            _context.MonAn.Add(monAn);
            _context.SaveChanges();
            return true;
        }
    }
}
