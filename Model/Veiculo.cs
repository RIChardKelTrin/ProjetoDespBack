using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Despachantes.Model
{
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Tipo { get; set; }

        public string Placa { get; set; }

        [ForeignKey("Cliente")]
        public int Fk_Cliente { get; set; }

        public Cliente Cliente { get; set; }


    }
}
