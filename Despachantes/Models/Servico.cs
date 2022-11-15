using System;
using System.ComponentModel.DataAnnotations;

namespace Despachantes.Model
{
    public class Servico
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public double Valor { get; set; }
        [Required]
        public DateTime DataDeEntrada { get; set; }


    }
}
