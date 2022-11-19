using Despachantes.Data;
using Despachantes.Exceptions;
using Despachantes.Model;
using Despachantes.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Despachantes.Services
{
    public class VeiculoServicoService : IVeiculoServicoService
    {
        private readonly DespachanteContext _Context;

        public VeiculoServicoService(DespachanteContext Context)
        {
            _Context = Context;
        }

        public async Task<IEnumerable<VeiculoServico>> GetVeiculoServico()
        {
            try
            {
                return await _Context.VeiculosServicos.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<VeiculoServico>> GetVeiculoServicoBySituacao(int situacao)
        {
            IEnumerable<VeiculoServico> veiculoServicos;
            if (situacao != 0)
            {
                veiculoServicos = await _Context.VeiculosServicos.Where(vs => vs.Fk_Situacao == situacao).ToListAsync();
            }
            else
            {
                veiculoServicos = await GetVeiculoServico();
            }

            return veiculoServicos;
        }

        public async Task<VeiculoServico> GetVeiculoServicoById(int Id)
        {
            var VeiculoServico = await _Context.VeiculosServicos.FindAsync(Id);
            return VeiculoServico;
        }

        public async Task CreateVeiculoServico(VeiculoServico VeiculoServico)
        {
            _Context.VeiculosServicos.Add(VeiculoServico);
            await _Context.SaveChangesAsync();
        }

        public async Task UpdateVeiculoServico(VeiculoServico VeiculoServico)
        {
            _Context.Entry(VeiculoServico).State = EntityState.Modified;
             await _Context.SaveChangesAsync();
        }
           
        public async Task DeleteVeiculoServico(VeiculoServico VeiculoServico)
        {
            _Context.VeiculosServicos.Remove(VeiculoServico);
            await _Context.SaveChangesAsync();
        }
    }
}
