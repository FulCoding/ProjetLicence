using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BankApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace BankApp.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly Dbcontext _context;

        public AdminController(ILogger<AdminController> logger,Dbcontext context)
        {
            _logger = logger;
            _context=context;
        }

        [HttpGet("AdminHome")]
        public IActionResult AdminHome()
        {
            return View();
        }
        

    }
}
