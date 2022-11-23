using System;
using System.ComponentModel.DataAnnotations;

namespace Despachantes.Model
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Cpf é obrigatório")]
        [StringLength(11)]
        [MinLength(11)]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "O RG é obrigatório")]
        [MinLength(2)]
        public string Rg { get; set; }
        [Required(ErrorMessage = "O Endereço é obrigatório")]
        [MinLength(4)]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "O Telefone é obrigatório")]
        [MinLength(11)]
        public string Telefone { get; set; }
     
    }
}
