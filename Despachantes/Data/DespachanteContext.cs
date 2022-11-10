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

    }
}
