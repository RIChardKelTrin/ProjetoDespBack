using Despachantes.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Despachantes.Models
{
    public class Servico_Cliente
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Servico")]
        public int Fk_Servico { get; set; }

        public Servico Servico { get; set; }

        [ForeignKey("Cliente")]
        public int Fk_Cliente { get; set; }

        public Cliente Cliente  { get; set; }

        public char Situacao { get; set; }

        public DateTime DataDeEntrada { get; set; }
    }

}
