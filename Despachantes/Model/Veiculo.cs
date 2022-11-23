using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Despachantes.Model
{
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O Placa é obrigatório")]
        [StringLength(7)]
        [MinLength(7)]
        public string Placa { get; set; }
        [Required(ErrorMessage = "O Renavam é obrigatório")]
        [MinLength(6)]
        public int Renavam { get; set; }
        [Required(ErrorMessage = "O Chassi é obrigatório")]
        [MinLength(3)]
        public string Chassi { get; set; }
        [Required(ErrorMessage = "O Modelo é obrigatório")]
        [MinLength(2)]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "O Ano/Ano é obrigatório")]
        [MinLength(9)]
        [StringLength(9)]
        public string Ano { get; set; }
        [Required(ErrorMessage = "O Cor é obrigatório")]
        [MinLength(2)]
        public string Cor { get; set; }



        [ForeignKey("Cliente")]
        public int Fk_Cliente { get; set; }

        public Cliente Cliente { get; set; }


    }
}
