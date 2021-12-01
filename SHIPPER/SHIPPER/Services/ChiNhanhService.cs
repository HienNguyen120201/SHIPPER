using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SHIPPER.Data;
using SHIPPER.Data.Entities;
using SHIPPER.Models;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace SHIPPER.Services
{
    public class ChiNhanhService:IChiNhanhService
    {
        private readonly Shipper10DBContext _context;
        private string _connectionString;
        public ChiNhanhService(
             Shipper10DBContext context,
             IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<bool> InsertChiNhanh(ChiNhanhViewModel chinhanh)
        {
             await using (SqlConnection customer = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert_Chinhanh", customer);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@tenchinhanh", chinhanh.TenChiNhanh);
                cmd.Parameters.AddWithValue("@masothue", chinhanh.MaSoThue);
                cmd.Parameters.AddWithValue("@diachi", chinhanh.DiaChi);
                cmd.Parameters.AddWithValue("@maNVQuanLy", chinhanh.MaNhanVienQuanLy);
                cmd.Parameters.AddWithValue("@maChiNhanhCha", chinhanh.MaChiNhanhCha);
                customer.Open();
                cmd.ExecuteNonQuery();
                customer.Close();
            }
            return true;
        }
        public async Task<bool> UpdateChiNhanh(ChiNhanhViewModel chinhanh)
        {
            var objmaquanly = await (from f in _context.QuanLi
                               where f.MaNhanVien == chinhanh.MaNhanVienQuanLy
                               select f
                               ).FirstOrDefaultAsync();
            var objNhanvienChiNhanh = await (from f in _context.NhanVienChiNhanh
                                             where f.MaNhanVien == chinhanh.MaNhanVienQuanLy
                                             select f
                                             ).FirstOrDefaultAsync();
            var nVCN = new NhanVienChiNhanh();
            nVCN.MaNhanVien = chinhanh.MaNhanVienQuanLy;
            nVCN.MaDonVi = chinhanh.MaChiNhanh;
            var qLi = new QuanLi();
            qLi.MaNhanVien = chinhanh.MaNhanVienQuanLy;

            if (objNhanvienChiNhanh == null)
                _context.NhanVienChiNhanh.Add(nVCN);
            if (objmaquanly == null)
                _context.QuanLi.Add(qLi);
            var objchiNhanh = (from f in _context.ChiNhanh
                            where f.MaDonVi == chinhanh.MaChiNhanh
                            select f
                            ).FirstOrDefault();
            objchiNhanh.MaDonVi = chinhanh.MaChiNhanh;
            objchiNhanh.MaNvquanLy = chinhanh.MaNhanVienQuanLy;
            objchiNhanh.MaSoThue = chinhanh.MaSoThue;
            objchiNhanh.TenChiNhanh = chinhanh.TenChiNhanh;
            objchiNhanh.MaChiNhanhCha = chinhanh.MaChiNhanhCha;
            objchiNhanh.IsACtive = chinhanh.TrangThai;
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteChiNhanh(int maChiNhanh)
        {
            var objchiNhanh = (from f in _context.ChiNhanh
                               where f.MaDonVi == maChiNhanh
                               select f
                           ).FirstOrDefault();
            _context.Remove(objchiNhanh);
            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<QuanLyChiNhanhViewModel> GetListPageChiNhanh()
        {
            QuanLyChiNhanhViewModel pageChiNhanh = new QuanLyChiNhanhViewModel();
            pageChiNhanh.ListChiNhanh = new List<ChiNhanhViewModel>();
            pageChiNhanh.ListQuanLy = new List<QuanLyViewModel>();
            var query = from f in _context.NhanVien
                        where f.LoaiNhanVien =="Quan ly" && f.IsActive == true
                        select f;
            var queryMqlQL = from f in _context.QuanLi
                        select f;
            var listMqlinTableQL = queryMqlQL.Select(x => x.MaNhanVien).ToList();
            var listmaql = query.Select(x => x.MaNhanVien).ToList();
            var listQlnowork = listmaql.Except(listMqlinTableQL).ToList();
            if (listQlnowork.Count() > 0)
            {
                query = from f in query
                        where listQlnowork.Contains(f.MaNhanVien)
                        select f;

                foreach (var row in query)
                {
                    pageChiNhanh.ListQuanLy.Add(new QuanLyViewModel
                    {
                        MaNhanVienQuanLy = row.MaNhanVien,
                        HoVaTen = row.Ho + ' ' + row.TenLot + ' ' + row.Ten,
                        Luong = (int)row.Luong,
                        NgaySinh = (System.DateTime)row.NgaySinh,
                        LoaiNhanVien = row.LoaiNhanVien
                    });
                }
            }
            pageChiNhanh.ListChiNhanh = await (
                                            from f in _context.ChiNhanh
                                            select new ChiNhanhViewModel
                                            {
                                                MaChiNhanh = f.MaDonVi,
                                                TenChiNhanh = f.TenChiNhanh,
                                                MaSoThue = (int)f.MaSoThue,
                                                DiaChi = f.DiaChi,
                                                MaNhanVienQuanLy = (System.Guid)f.MaNvquanLy,
                                                MaChiNhanhCha = (int)f.MaChiNhanhCha,
                                                SoLuongNhanVien= (int)f.SoLuongNhanVien,
                                                TrangThai = (bool)f.IsACtive,
                                            }
                                            ).ToListAsync();
            return pageChiNhanh;
        }
        public async Task<QuanLyChiNhanhViewModel> GetListPageUpdateChiNhanh(int id)
        {
            QuanLyChiNhanhViewModel pageUpdateChiNhanh = new QuanLyChiNhanhViewModel();
            pageUpdateChiNhanh.ListChiNhanh = new List<ChiNhanhViewModel>();
            pageUpdateChiNhanh.ListQuanLy = new List<QuanLyViewModel>();
            pageUpdateChiNhanh.ChiNhanh = new ChiNhanhViewModel();
            var query = from f in _context.NhanVien
                        where f.LoaiNhanVien == "Quan ly" && f.IsActive == true
                        select f;
            var queryMqlQL = from f in _context.QuanLi
                             select f;
            var listMqlinTableQL = queryMqlQL.Select(x => x.MaNhanVien).ToList();
            var listmaql = query.Select(x => x.MaNhanVien).ToList();
            var listQlnowork = listmaql.Except(listMqlinTableQL).ToList();
            if (listQlnowork.Count() > 0)
            {
                query = (from f in query
                        where listQlnowork.Contains(f.MaNhanVien)
                        select f).OrderByDescending(c=>c.Luong);
            }
            foreach (var row in query)
            {
                pageUpdateChiNhanh.ListQuanLy.Add(new QuanLyViewModel
                {
                    MaNhanVienQuanLy = row.MaNhanVien,
                    HoVaTen = row.Ho + ' ' + row.TenLot + ' ' + row.Ten,
                    Luong = (int)row.Luong,
                    NgaySinh = (System.DateTime)row.NgaySinh,
                    LoaiNhanVien = row.LoaiNhanVien
                });
            }
            pageUpdateChiNhanh.ChiNhanh = await (from f in _context.ChiNhanh
                                                 where f.MaDonVi == id
                                                 select new ChiNhanhViewModel()
                                                 {
                                                     MaChiNhanh=f.MaDonVi,
                                                     TenChiNhanh = f.TenChiNhanh,
                                                     MaSoThue = (int)f.MaSoThue,
                                                     DiaChi = f.DiaChi,
                                                     MaNhanVienQuanLy = (System.Guid)f.MaNvquanLy,
                                                     MaChiNhanhCha = (int)f.MaChiNhanhCha,
                                                     TrangThai = (bool)f.IsACtive
                                                 }
                                                 ).FirstOrDefaultAsync();

            return pageUpdateChiNhanh;
        }
    }
}
