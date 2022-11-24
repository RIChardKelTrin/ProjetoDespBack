using System.ComponentModel.DataAnnotations;

namespace Despachantes.Models
{
    public class SituacaoSV
    {
        [Key]
        public int Id { get; set; }

        [StringLength(40), MinLength(4)] 
        public string Nome { get; set; }


    }
}
