using SHIPPER.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHIPPER.Services
{
    public interface IEmployeeService
    {
        public bool Insert (EmployeeViewModel employee);
        Task<EmployeeViewModel> GetNhanVienAsync(string type);
        public bool DeleteNhanVien(string Account);
        Task<List<DonKhieuNaiViewModel>> GetDonKhieunai();
    }
}
