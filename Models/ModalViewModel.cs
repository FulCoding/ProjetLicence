using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web;


namespace BankApp.Models
{
    public class ModalViewModel
    {
        public string ModalId { get; set; }
        public string ModalTitle { get; set; }
        public object ModalData { get; set; } // Propriété optionnelle pour des données supplémentaires
    }

}