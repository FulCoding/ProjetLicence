using System;
using System.Net.Mail;
using System.Net.Sockets;
using System.Net.Security;
using System.Net.WebSockets;
using System.Net.Http;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using BankApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace BankApp.Controllers
{
    [Route("[Controller]/")]
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
        
        [HttpGet("Users")]
        public async Task<ActionResult> GetUsers()
        {
            var Users= await _context.Users.Include(p=>p.Role).ToListAsync();
            return View(Users);
        }

        [HttpGet("Update")]
        public async Task<ActionResult> Update()
        {
            return View();
        }
    }
}
