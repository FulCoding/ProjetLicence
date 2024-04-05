using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using BankApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BankApp.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly Dbcontext _context;
       


        public UserController(ILogger<UserController> logger, Dbcontext context)
        {
            _logger = logger;
            _context=context;
        }

        [HttpGet("Login")]
        public  ActionResult Login()
        {
            return View();
        }
        [HttpPost("Login")]
        public async  Task<ActionResult> Login( [Bind("Email,Password")] LoginModel model)
        {
            var Users= await _context.Users.Include(p=>p.Role).ToListAsync();
            bool userexist=false;
            bool useradmin=false;
            if (Users.Count!=0)
            {
                foreach (var item in Users)
                {
                    var passwordHasher = new PasswordHasher<string>();
                    var verified=passwordHasher.VerifyHashedPassword(item.UserName,item.Password, model.Password);
                    if(item.Email.Equals(model.Email)&&verified==PasswordVerificationResult.Success )
                    {
                        ViewBag.Id=item.UserId;
                        userexist=true;
                        
                    }
                    if (item.Role.RoleName.Equals("administrateur"))
                    {
                        useradmin=true;
                    }
                }
               
            }
            if (userexist==true)
            {
                return RedirectToAction("Test","Home");
            }
            else if(useradmin==true)
            {
                return RedirectToAction("AdminHome","Admin");
            }
            else{
                @ViewData["error"]="email ou mot de passe incorrect";  
                return View() ;
            }
            return View();
        }

         [HttpGet("Signup")]
        public  ActionResult Signup()
        {
            return View();
        }

        [HttpPost("Signup")]
        public async Task<ActionResult> Signup([Bind("UserId,UserName,Telephone,Email,Confirmpassword,Password")] User user)
        {
          var Users= await _context.Users.ToListAsync();
          
          User us= new User();
            if (Users.Count!=0)
            {
                foreach (var item in Users)
                {
                    var passwordHasher = new PasswordHasher<string>();
                    var verified=passwordHasher.VerifyHashedPassword(item.UserName,item.Password, user.Password);//comparaison des deux mot de passe 
                    @ViewData["pass"]=item.Password + "="+  user.Password;
                    if(item.Email.Equals(user.Email)&&verified==PasswordVerificationResult.Success)
                    {
                        @ViewData["error"]="Choisir un autre nom d'utilisateur";
                        return View() ;
                    }
                }
            }
             if (ModelState.IsValid && (user.Password.Equals(user.Confirmpassword)))
            {
                var passwordHasher = new PasswordHasher<string>();
                var hashedPassword = passwordHasher.HashPassword(user.UserName,user.Password);//hasher le mot de passe
                us.UserId=user.UserId;
                us.UserName=user.UserName;
                us.Telephone=user.Telephone;
                us.Email=user.Email;
                us.Password=hashedPassword;
                us.RolesId=1;

                _context.Users.Add(us);
                await _context.SaveChangesAsync();
                 ViewBag.IsSuccess=true;
                return RedirectToAction(nameof(Login));
            }
            //ViewData["error"]="les deux mot de passe ne corresponde pas";
            return View();
            
        }
    }
}
