using Despachantes.Data;
using Despachantes.Exceptions;
using Despachantes.Model;
using Despachantes.Models;
using Microsoft.EntityFrameworkCore;
using System;
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

        public async Task<IEnumerable<VeiculoServico>> GetVeiculoServicoBySituacao(string situacao)
        {
            IEnumerable<VeiculoServico> veiculoServicos;
            if (!string.IsNullOrWhiteSpace(situacao))
            {
                veiculoServicos = await _Context.VeiculosServicos.Where(vs => vs.SituacaoSV.Nome.Contains(situacao)).OrderByDescending(vs => vs.DataDeEntrada).ToListAsync();
            }
            else
            {
                veiculoServicos = await _Context.VeiculosServicos.OrderByDescending(vs => vs.DataDeEntrada).ToListAsync();
            }

            IEnumerable<Veiculo> veiculo = await _Context.Veiculos.ToListAsync();
            IEnumerable<Servico> servico = await _Context.Servicos.ToListAsync();
            IEnumerable<SituacaoSV> situacaoSV = await _Context.SituacaoSV.ToListAsync();
            IEnumerable<Cliente> cliente = await _Context.Clientes.ToListAsync();



            return veiculoServicos;
        }

        public async Task<VeiculoServico> GetVeiculoServicoById(int Id)
        {
            var VeiculoServico = await _Context.VeiculosServicos.FindAsync(Id);
            return VeiculoServico;
        }

        public async Task CreateVeiculoServico(VeiculoServico VeiculoServico)
        {
            VeiculoServico.Fk_Situacao = 1;
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
