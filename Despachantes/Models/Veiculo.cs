using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;

namespace Despachantes.Model
{
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }

        [Required, MinLength(5, ErrorMessage = " Marca/Modelo do veículo deve ter no mínimo 5 caracteres")]
        public string MarcaModelo { get; set; }
            
        [StringLength(7,MinimumLength = 7, ErrorMessage = "A placa do veículo deve ter no min/max 7 caracteres")]
        public string Placa { get; set; }

        [Required]
        [MaxLength(9, ErrorMessage = "O ano de fabricação/modelo deve ter no máximo 9 caracteres")]
        public string Ano { get; set; }

        [Required]
        public string Cor { get; set; }

        [Required]
        [MaxLength(11, ErrorMessage = "Não é permitido mais de 11 caracteres para o Renavam") ]
        public string Renavam { get; set; }

        [ForeignKey("Cliente")]
        public int Fk_Cliente { get; set; }

        public Cliente Cliente { get; set; }


    }
}
