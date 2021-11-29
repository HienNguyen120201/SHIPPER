using Microsoft.AspNetCore.Mvc;
using SHIPPER.Models;
using SHIPPER.Services;
using System;

namespace SHIPPER.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public IActionResult Insert()
        {
            EmployeeViewModel employee=_employeeService.GetNhanVien("Shipper");
            return View(employee);
        }
    }
}
