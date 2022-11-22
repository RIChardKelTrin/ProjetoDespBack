using Despachantes.Model;
using Despachantes.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Despachantes.Services
{
    public interface IVeiculoServicoService
    {

        Task<IEnumerable<VeiculoServico>> GetVeiculoServico();
        Task<VeiculoServico> GetVeiculoServicoById(int id);
        Task<IEnumerable<VeiculoServico>> GetVeiculoServicoBySituacao(int situacao);
        Task CreateVeiculoServico(VeiculoServico veiculoServico);
        Task UpdateVeiculoServico(VeiculoServico veiculoServico);
        Task DeleteVeiculoServico(VeiculoServico veiculoServico);

     

}
}
