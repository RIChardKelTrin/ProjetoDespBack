using Despachantes.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Despachantes.services
{
    public interface IServicoService
    {
        Task<IEnumerable<Servico>>GetServicos();
        Task<Servico> GetServicoById(int id);
        Task<IEnumerable<Servico>> GetServicoByNome(string nome);
        Task CreateServico (Servico servico);
        Task UpdateServico(Servico servico);
        Task DeleteServico(Servico servico);
    }
}
