using Despachantes.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Despachantes.Services
{
    public interface IVeiculoService
    {
        Task<IEnumerable<Veiculo>> GetVeiculo();
        Task<Veiculo> GetVeiculobyId(int id);
        Task<IEnumerable<Veiculo>> GetVeiculoByPlaca(string placa); 
        Task CreateVeiculo(Veiculo veiculo);
        Task UpdateVeiculo(Veiculo veiculo);
        Task DeleteVeiculo(Veiculo veiculo);

    }
}
