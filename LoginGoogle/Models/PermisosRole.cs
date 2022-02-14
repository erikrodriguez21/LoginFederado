using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginGoogle.Models
{
    public class PermisosRole
    {
        [Key]
        public int IdPermisosRole{ get; set; }        

        public virtual string IdRole { get; set; }
        [ForeignKey("IdRole")]
        public virtual IdentityRole Roles { get; set; }

        public int IdPermiso { get; set; }
        [ForeignKey("IdPermiso")] 
        public Permisos Permisos { get; set; }

        public int IdModulo { get; set; }
        [ForeignKey("IdModulo")]
        public Modulos Modulos { get; set; }

    }
}