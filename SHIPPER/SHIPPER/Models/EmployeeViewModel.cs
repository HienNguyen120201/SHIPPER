using System;
using System.Collections.Generic;

namespace SHIPPER.Models
{
    public class EmployeeViewModel
    {
        public string FirstName {  get; set; }
        public string MiddleName {  get; set; }
        public string LastName {  get; set; }
        public int Salary {  get; set; }
        public string Account {  get; set; }
        public string Password {  get; set; }
        public string Type {  get; set; }
        public DateTime Birth {  get; set; }
        public List<EmployeesViewModel> ListEmployees {  get; set; }
    }
    public class EmployeesViewModel
    {
        //Ho,tenLot as TenLot,ten as Ten,ngayVaoLam as NgayVaoLam,luong as Luong,
        //chiSoUyTin as ChiSoUyTin, T.maDonVi as MaChiNhanh, tenChiNhanh as TenChiNhanh
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime Start { get; set; }
        public int Salary { get; set; }
        public int IdBranch {  get; set; }
        public string NameBranch {  get; set; }
        public double Prestige { get; set; }
    }
}
