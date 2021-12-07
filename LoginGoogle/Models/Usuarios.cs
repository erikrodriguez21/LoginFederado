using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace LoginGoogle.Models
{
    public class Usuarios : IdentityUser
    {      
        public string Nombre { get; set; }
        
        [Required]
        [Display(Name = "Apellido paterno")]
        public string ApellidoPaterno { get; set; }
        
        [Required]
        [Display(Name = "Apellido materno")]
        public string ApellidoMaterno { get; set; }
    }
}