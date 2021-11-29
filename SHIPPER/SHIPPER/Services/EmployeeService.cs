using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SHIPPER.Data;
using SHIPPER.Models;
using System;
using System.Collections.Generic;
using System.Data;

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
        public EmployeeViewModel GetNhanVien(string type)
        {
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
            while (data.Read())
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
                    Prestige = double.Parse(data["ChiSoUyTin"].ToString())
                };
                result.ListEmployees.Add(nhanVien);
            }
            cus.Close();
            return result;
        }
    }
}
