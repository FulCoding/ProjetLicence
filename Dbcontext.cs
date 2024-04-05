using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using BankApp.Models;
namespace BankApp
{
    public class Dbcontext:DbContext
    {
        public DbSet<User> Users{get;set;}
        public DbSet<Roles> Roles{get;set;}

        public Dbcontext(DbContextOptions<Dbcontext> options):base(options)
        {

        }
    }
}