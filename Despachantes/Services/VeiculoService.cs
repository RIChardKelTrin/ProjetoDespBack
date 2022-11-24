using Despachantes.Data;
using Despachantes.Exceptions;
using Despachantes.Model;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Despachantes.Services
{
    public class VeiculoService : IVeiculoService
    {

        private readonly DespachanteContext _Context;

        public VeiculoService(DespachanteContext Context)
        {
            _Context = Context;
        }

        public async Task<IEnumerable<Veiculo>> GetVeiculo()
        {
            try
            {
                return await _Context.Veiculos.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Veiculo>> GetVeiculoByPlaca(string Placa)
        {
            IEnumerable<Veiculo> Veiculos;
            if (!string.IsNullOrWhiteSpace(Placa))
            {
                Veiculos = await _Context.Veiculos.Where(v => v.Placa.Contains(Placa)).ToListAsync();
            }
            else
            {
                Veiculos = await GetVeiculo();
            }

            return Veiculos;
        }

        public async Task<Veiculo> GetVeiculobyId(int Id)
        {
            var Veiculo = await _Context.Veiculos.FindAsync(Id); 
            return Veiculo;
        }

        public async Task CreateVeiculo(Veiculo Veiculo)
        {
            var veiculos = await _Context.Veiculos.Where(v => v.Placa == Veiculo.Placa || v.Renavam == Veiculo.Renavam).ToListAsync();
            if (veiculos.Count <= 0) 
            { 
                _Context.Veiculos.Add(Veiculo);
                await _Context.SaveChangesAsync();
            }
            else
            {
                throw new RenavamPlacaJaExistente("Renavam/Placa ja existente");
            }

        }

        public async Task UpdateVeiculo(Veiculo Veiculo)
        {
            var veiculos = await _Context.Veiculos.Where(v => (v.Placa == Veiculo.Placa || v.Renavam == Veiculo.Renavam) && v.Id != Veiculo.Id).ToListAsync();

            if (veiculos.Count <= 0)
            {
                _Context.Entry(Veiculo).State = EntityState.Modified;
                await _Context.SaveChangesAsync();
            }
            else
            {
                throw new RenavamPlacaJaExistente("Renavam/Placa ja existente");
            }
        }

        public async Task DeleteVeiculo(Veiculo Veiculo)
        {
            _Context.Veiculos.Remove(Veiculo);
            await _Context.SaveChangesAsync();
        }
    }
}
