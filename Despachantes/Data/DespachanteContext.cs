using Despachantes.Model;
using Despachantes.Models;
using Microsoft.EntityFrameworkCore;

namespace Despachantes.Data
{
    public class DespachanteContext : DbContext
    {

        public DespachanteContext(DbContextOptions<DespachanteContext> opt) : base(opt)
        { }

       
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Veiculo> Veiculos { get; set; }

        public DbSet<Servico> Servicos { get; set; }

        public DbSet<Login> Logins { get; set; }


        public DbSet<VeiculoServico> VeiculosServicos { get; set; }

        public DbSet<SituacaoSV> SituacaoSV { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            =>
            modelBuilder.Entity<SituacaoSV>()
            .HasData(
                new SituacaoSV { Id = 1, Nome = "ATIVO"},
                new SituacaoSV { Id = 2, Nome = "FINALIZADO"},
                new SituacaoSV { Id = 3, Nome = "PENDENTE"},
                new SituacaoSV { Id = 4, Nome = "CANCELADO"}
                );
    }
}
