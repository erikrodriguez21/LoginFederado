using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoginGoogle.Models
{
    public class Modulos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdModulo { get; set; }
        public string Nombre { get; set; }
    }
}