using SHIPPER.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHIPPER.Services
{
    public interface IChiNhanhService
    {
        Task<bool> InsertChiNhanh(ChiNhanhViewModel chinhanh);
        Task<bool> UpdateChiNhanh(ChiNhanhViewModel chinhanh);
        Task<bool> DeleteChiNhanh(int maChiNhanh);
        Task<QuanLyChiNhanhViewModel> GetListPageChiNhanh();
        Task<QuanLyChiNhanhViewModel> GetListPageUpdateChiNhanh(int id);
        Task<List<NhanVienChiNhanhViewModel>> GetDetailChiNhanh(int id);
        Task<List<ShipperChiNhanhViewModel>> GetListShipperCN(int id);
        Task<List<ChiNhanhQLXViewModel>> GetListChiNhanhQLX(float id);
        Task<List<ShipperMaxLuongViewModel>> GetListShipperMaxLuong(int id);
        Task<List<ThongKeShipperViewModel>> GetListThongKe(int id);
    }
}
