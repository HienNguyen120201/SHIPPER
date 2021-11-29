using SHIPPER.Models;

namespace SHIPPER.Services
{
    public interface IEmployeeService
    {
        public bool Insert (EmployeeViewModel employee);
        public EmployeeViewModel GetNhanVien(string type);
    }
}
