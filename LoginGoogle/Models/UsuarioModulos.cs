using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginGoogle.Models
{
    public class UsuarioModulos
    {
        [Key]
        public int Id { get; set; }
        public string IdUsuario { get; set; }       

        public int IdModulo { get; set; }
        [ForeignKey("IdModulo")]
        public Modulos Modulos { get; set; }
    }
}