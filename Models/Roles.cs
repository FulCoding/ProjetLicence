using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web;


namespace BankApp.Models
{
    public class Roles
    {
        public int RolesId { get; set; }
        [StringLength(15)]
        public string RoleName { get; set; }
        [StringLength(20)]
       [Required(ErrorMessage="Veuillez entrez une description plus courte correcte")]
        public string Description { get; set; }
        
        
        
    }
}