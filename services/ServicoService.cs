using Despachantes.Data;
using Despachantes.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Despachantes.services
{
    public class ServicoService : IServicoService

    {
        private readonly DespachanteContext _Context;

        public ServicoService(DespachanteContext context)
        {
            _Context = context;
        }

        public async Task<IEnumerable<Servico>> GetServicos()
        {
            try
            {
                return await _Context.Servicos.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Servico> GetServicoById(int id)
        {
            var servico = await _Context.Servicos.FindAsync(id);
            return servico;
        }

        public async Task<IEnumerable<Servico>> GetServicoByNome(string Nome)
        {
           
            IEnumerable<Servico> servicos;
            if (string.IsNullOrWhiteSpace(Nome))
            {
                servicos = await _Context.Servicos.Where(n => n.Nome.Contains(Nome)).ToListAsync();
            }
            else
            {
                servicos = await GetServicos();
            }
            return servicos;
        }

        public async Task CreateServico(Servico servico)
        {
            _Context.Servicos.Add(servico);
            await _Context.SaveChangesAsync();
          
        }

        public async Task UpdateServico(Servico servico)
        {
            _Context.Entry(servico).State = EntityState.Modified;
            await _Context.SaveChangesAsync();
        }

        public async Task DeleteServico(Servico servico)
        {

            _Context.Servicos.Remove(servico);
            await _Context.SaveChangesAsync();

        }
    }
        
}
