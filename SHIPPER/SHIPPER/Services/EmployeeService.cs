using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
    public class EmployeeService:IEmployeeService
    {
        private readonly Shipper10DBContext _context;
        private string _connectionString;
        public EmployeeService(Shipper10DBContext context,IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public bool Insert(EmployeeViewModel employee)
        {
            //@ho nvarchar(20),@tenLot nvarchar(20) = '',@ten nvarchar(20), @luong decimal,
            // @taiKhoan nvarchar(50) = '', @matKhau nvarchar(50) = '',@loaiNhanVien nvarchar(20)= '',
            //@chiSoUyTin decimal(2, 1) = 5.0,@ngaySinh Date
            using SqlConnection cus = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("insertNhanVien", cus)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@ho", employee.FirstName);
            cmd.Parameters.AddWithValue("@tenLot", employee.MiddleName);
            cmd.Parameters.AddWithValue("@ten", employee.LastName);
            cmd.Parameters.AddWithValue("@luong", employee.Salary);
            cmd.Parameters.AddWithValue("@taiKhoan", employee.Account);
            cmd.Parameters.AddWithValue("@matKhau", employee.Password);
            cmd.Parameters.AddWithValue("@loaiNhanVien", employee.Type);
            cmd.Parameters.AddWithValue("@chiSoUyTin", default);
            cmd.Parameters.AddWithValue("@ngaySinh", employee.Birth);
            cus.Open();
            cmd.ExecuteNonQuery();
            cus.Close();
            return true;
        }
        public async Task<EmployeeViewModel> GetNhanVienAsync(string type)
        {
            if(type=="" || type==null)
            {
                var a = await (from b in _context.NhanVien
                               from c in _context.ChiNhanh
                               from d in _context.NhanVienChiNhanh
                               where b.MaNhanVien == d.MaNhanVien && c.MaDonVi == d.MaDonVi
                               orderby b.LoaiNhanVien, b.Ho, b.TenLot, b.Ten
                               select new EmployeesViewModel()
                               {
                                   FirstName = b.Ho,
                                   MiddleName = b.TenLot,
                                   LastName = b.Ten,
                                   Start = DateTime.Parse(b.NgayVaoLam.ToString()),
                                   Salary = int.Parse(b.Luong.ToString()),
                                   IdBranch = c.MaDonVi,
                                   NameBranch = c.TenChiNhanh,
                                   Prestige = double.Parse(b.ChiSoUyTin.ToString()),
                                   Account = b.TaiKhoan,
                                   Type = b.LoaiNhanVien,
                                   isActice = Convert.ToInt32(b.IsActive)
                               }).ToListAsync();
                EmployeeViewModel result1 = new EmployeeViewModel
                {
                    ListEmployees = new List<EmployeesViewModel>()
                };
                foreach (var data2 in a)
                {
                    if(data2.isActice==1)
                    {
                        result1.ListEmployees.Add(data2);
                    }    
                }    
                return result1;

            }    
            EmployeeViewModel result = new EmployeeViewModel
            {
                ListEmployees = new List<EmployeesViewModel>()
            };
            using SqlConnection cus = new SqlConnection(_connectionString);
            SqlCommand cmd = new SqlCommand("Tim_ThongTinNhanVienTheoLoai", cus)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.AddWithValue("@type", type);
            cus.Open();
            SqlDataReader data = cmd.ExecuteReader();
            while (await data.ReadAsync())
            {
                EmployeesViewModel nhanVien = new EmployeesViewModel
                {
                    FirstName = data["Ho"].ToString(),
                    MiddleName = data["TenLot"].ToString(),
                    LastName = data["Ten"].ToString(),
                    IdBranch = int.Parse(data["MaChiNhanh"].ToString()),
                    NameBranch = data["TenChiNhanh"].ToString(),
                    Salary = int.Parse(data["Luong"].ToString()),
                    Start = DateTime.Parse(data["NgayVaoLam"].ToString()),
                    Prestige = double.Parse(data["ChiSoUyTin"].ToString()),
                    Account= data["TaiKhoan"].ToString(),
                    Type= data["ChucVu"].ToString(),
                    isActice = Convert.ToInt32(data["isActive"])
                };
                if (nhanVien.isActice == 1)
                    result.ListEmployees.Add(nhanVien);
            }
            cus.Close();
            return result;
        }
        public bool DeleteNhanVien(string Account)
        {
            var data= (from a in _context.NhanVien
                      join b in _context.ChiNhanh on a.MaNhanVien equals b.MaNvquanLy
                      where a.TaiKhoan==Account
                      select b).ToList();
            if (data != null)
            {
                foreach(var a in data)
                {
                    a.MaNvquanLy = null;
                }    
            }
            var data1=(from a in _context.NhanVien
                       where a.TaiKhoan == Account
                       select a).FirstOrDefault();
            data1.IsActive = false;
            _context.SaveChanges();
            return true;
        }
    }
}
