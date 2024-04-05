
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace BankApp.Models
{
    public class User {
       public int UserId { get; set; }
        [StringLength(60)]
       [Required(ErrorMessage="Veuillez entrez un nom d'utilisateur correcte")]
       public string UserName { get; set; }
        [StringLength(20)]
       [Required(ErrorMessage="Veuillez entrez un numero de téléphone correcte")]
       public string Telephone { get; set; }
        [StringLength(30)]
       [Required(ErrorMessage="Veuillez entrez un email correcte")]
       public string Email { get; set; }
        [NotMapped]
       public string Confirmpassword { get; set; }
       [StringLength(8)]
       [Required(ErrorMessage="le mot de passe doit avoir  8 caratères contenant des lettres,chiffre et symbole ")]
       public string Password { get; set; }
       
       public int RolesId { get; set; }
       public Roles Role { get; set; }
       
       
       
       
       
       
    }
}