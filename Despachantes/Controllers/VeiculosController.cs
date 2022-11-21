using Despachantes.Data;
using Despachantes.Exceptions;
using Despachantes.Model;
using Despachantes.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Despachantes.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]

    public class VeiculoController : ControllerBase
    {
        private IVeiculoService _veiculoService;

        public VeiculoController(IVeiculoService veiculoService)
        {
            _veiculoService = veiculoService;
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Veiculo>>> GetVeiculos()
        {
            try
            {
                var veiculos = await _veiculoService.GetVeiculo();
                return Ok(veiculos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter veículos");
            }
        }

        [HttpGet("placa")]

        public async Task<ActionResult<IAsyncEnumerable<Veiculo>>> GetVeiculoByPlaca([FromQuery] string placa)
        {
            try
            {
                var veiculos = await _veiculoService.GetVeiculoByPlaca(placa);

                return Ok(veiculos);
            }
            catch
            {
                return BadRequest("Request Inválido");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Veiculo>> GetVeiculoById(int id)
        {
            try
            {
                var veiculos = await _veiculoService.GetVeiculobyId(id);

                if (veiculos == null) return NotFound($"Não existem veículos com id = {id}");

                return Ok(veiculos);
            }
            catch
            {
                return BadRequest("Request Inválido");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Veiculo>> CreateVeiculo(Veiculo veiculo)
        {
            try
            {   
                await _veiculoService.CreateVeiculo(veiculo);
                return CreatedAtAction(nameof(GetVeiculoById), new { id = veiculo.Id }, veiculo);
            }
            catch(RenavamPlacaJaExistente e)
            {
                return StatusCode(403, e.Message);
            }
            catch
            {
                return BadRequest("Request Inválido");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Veiculo>> UpdateVeiculo(int id, Veiculo veiculo)
        {
            try
            {
                if (veiculo.Id == id)
                {
                    await _veiculoService.UpdateVeiculo(veiculo);
                    return Ok(veiculo);
                }
                else
                {
                    return BadRequest("Dados inconsistentes");
                }
            }
            catch (RenavamPlacaJaExistente e)
            {
                return StatusCode(403, e.Message);
            }
            catch
            {
                return BadRequest("Request Inválido");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Veiculo>> DeleteVeiculo(int id)
        {
            try
            {
                var veiculo = await _veiculoService.GetVeiculobyId(id);

                if (veiculo == null) return NotFound($"Veiculo com o id = {id} não encontrado!");

                await _veiculoService.DeleteVeiculo(veiculo);
                return Ok($"Veiculo com o id = {id} excluído com sucesso!");
            }
            catch
            {
                return BadRequest("Request Inválido");
            }
        }

    }
}
