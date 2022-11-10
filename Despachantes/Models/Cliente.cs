using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;

namespace Despachantes.Model
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        [MinLength(11), MaxLength(11), Required(ErrorMessage = "O Cpf é obrigatório")]
        public string Cpf { get; set; }
    }
}
