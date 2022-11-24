using Despachantes.Model;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Despachantes.Models
{
    public class VeiculoServico
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Servico")]
        public int Fk_Servico { get; set; }

        public Servico Servico { get; set; }

        [ForeignKey("Veiculo")]
        public int Fk_Veiculo { get; set; }

        public Veiculo Veiculo  { get; set; }

        [ForeignKey("SituacaoSV")]
        public int Fk_Situacao { get; set; }

        public SituacaoSV SituacaoSV { get; set; }

        public DateTime DataDeEntrada { get; set; }
    }

}
