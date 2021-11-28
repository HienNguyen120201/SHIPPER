using Microsoft.Extensions.Configuration;
using SHIPPER.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SHIPPER.Services
{
    public class AdminService
    {
        private readonly Shipper10DBContext _context;
        private string _connectionString;
        public AdminService(
             Shipper10DBContext context,
             IConfiguration configuration)
        {
            _context = context;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

    }
}
