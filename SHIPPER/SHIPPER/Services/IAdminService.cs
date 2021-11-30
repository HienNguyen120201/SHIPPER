using SHIPPER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHIPPER.Services
{
    public interface IAdminService
    {
        Task<List<KhachHangUuDaiViewModel>> TimUuDaiKhachHang(int cmnd);
        Task<List<KhachHangViewModel>> GetKhachHangAsync();
        void DeleteKhachHang(int cmnd);
        Task<List<ChiTietDonViewModel>> GetChiTietDonMonAnAsync();
        void DeleteChiTietDonMonAn(int maDon, int maMon);
        void UpdateChiTietDonMonAn(int maDon, int maMon, int soluong);
        void UpdateKhachHang(int cmnd, string matkhau);
        Task<List<PhuongTienViewModel>> GetPhuongTiensAsync();
        NhanVienPhuongTienViewModel GetNhanVienPhuongTien(int bienSo);
        void DeletePhuongTien(string bienso);
    }
}
