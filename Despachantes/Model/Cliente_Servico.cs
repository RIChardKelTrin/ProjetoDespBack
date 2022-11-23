using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Despachantes.Model
{
    public class Cliente_Servico
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Cliente")]
        public int Fk_Cliente{ get; set; }
        public int Cliente { get; set; }

        [ForeignKey("Servico")]
        public int Fk_Servico { get; set; }
        public Servico Servico { get; set; }

    }
}
