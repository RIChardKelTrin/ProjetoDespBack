using Despachantes.Model;
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

        public DbSet<Cliente_Servico> Clientes_Servicos { get; set; }

    }
}
