using Despachantes.Exceptions;
using Despachantes.Model;
using Despachantes.Models;
using Despachantes.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Despachantes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoServicoController : ControllerBase
    {
        
        private IVeiculoServicoService _veiculoServicoService;

        public VeiculoServicoController(IVeiculoServicoService veiculoService)
        {
            _veiculoServicoService = veiculoService;
        }

        [HttpGet]   
        public async Task<ActionResult<IAsyncEnumerable<VeiculoService>>> getVeiculoServico()
        {
            try
            {
                var veiculosServico = await _veiculoServicoService.GetVeiculoServico();
                return Ok(veiculosServico);
            }
            catch
            {
                return BadRequest("Erro ao consultar");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<VeiculoServico>> GetVeiculoServicoById(int id)
        {
            try
            {
                var veiculosServico = await _veiculoServicoService.GetVeiculoServicoById(id);

                return Ok(veiculosServico);
            }
            catch
            {
                return BadRequest("Request Inválido");
            }
        }

        [HttpGet("situacao")]
        public async Task<ActionResult<VeiculoServico>> GetVeiculoServicoBySituacao([FromQuery] string nomeSituacao)
        {
            try
            {
                var veiculosServico = await _veiculoServicoService.GetVeiculoServicoBySituacao(nomeSituacao);

                if (veiculosServico == null) return NotFound($"Não existem SV com id = {nomeSituacao}");

               return Ok(veiculosServico);
            }
            catch
            {
                return BadRequest("Request Inválido");
            }
        }

        [HttpPost]
        public async Task<ActionResult<VeiculoServico>> CreateVeiculoServico(VeiculoServico veiculoServico)
        {
            try
            {
                veiculoServico.DataDeEntrada = DateTime.Now;
                veiculoServico.Fk_Situacao = 1;
                await _veiculoServicoService.CreateVeiculoServico(veiculoServico);
                return CreatedAtAction(nameof(getVeiculoServico), new { id = veiculoServico.Id }, veiculoServico);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return BadRequest("Request Inválido");
            }
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<VeiculoService>> AlteraSituacaoVeiculoServico(int id, VeiculoServico veiculoServico)
        {
            try
            {
                if(id == veiculoServico.Id)
                {
                    await _veiculoServicoService.UpdateVeiculoServico(veiculoServico);
                    return Ok(veiculoServico);
                }
                else
                {
                    return BadRequest("Id não encontrado!");
                }

            }
            catch
            {
                return BadRequest("Erro ao trocar de situação!");
            }

        }
    }
}
