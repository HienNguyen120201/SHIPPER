using Microsoft.AspNetCore.Mvc;
using SHIPPER.Models;
using SHIPPER.Services;
using System;
using System.Threading.Tasks;

namespace SHIPPER.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<IActionResult> InsertAsync()
        {
            string a="";
            EmployeeViewModel employee=await _employeeService.GetNhanVienAsync(a);
            return View(employee);
        }
        [HttpPost]
        public async Task<IActionResult> InsertAsync(EmployeeViewModel e)
        {
            if (e.Action == "search")
            {
                EmployeeViewModel employee = await _employeeService.GetNhanVienAsync(e.Type);
                employee.Type = e.Type;
                return View(employee);
            }
            else if (e.Action =="delete")
            {
                _employeeService.DeleteNhanVien(e.Account);
                EmployeeViewModel employee = await _employeeService.GetNhanVienAsync(e.Type);
                employee.Type = e.Type;
                return View(employee);
            }
            else if(e.Action =="insert")
            {
                _employeeService.Insert(e);
                EmployeeViewModel employee = await _employeeService.GetNhanVienAsync(e.Type);
                employee.Type = e.Type;
                return View(employee);
            }    
            
            return View(new EmployeeViewModel());
        }
        public async Task<IActionResult> GetListKhieuNai()
        {
            var list = await _employeeService.GetDonKhieunai();
            return View(list);
        }    
    }
}
