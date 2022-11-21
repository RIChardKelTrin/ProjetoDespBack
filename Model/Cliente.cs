using System;
using System.ComponentModel.DataAnnotations;

namespace Despachantes.Model
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        [Required(ErrorMessage = "O Cpf é obrigatório")]
        [StringLength(11)]
        [MinLength(11)]
        public string Cpf { get; set; }

        public DateTime Nascimento { get; set; }
    }
}
