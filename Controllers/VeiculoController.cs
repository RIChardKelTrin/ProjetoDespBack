using Despachantes.Data;
using Despachantes.Model;
using Despachantes.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Despachantes.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class VeiculoController :ControllerBase
    {

       // private DespachanteContext _Context;

        /*public VeiculoController(DespachanteContext context)
        {
            _Context = context;
        }*/

        private IServicoService _servicoService;

        public VeiculoController(IServicoService servicoService)
        {
            _servicoService = servicoService;   
        }

        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Servico>>> GetServicos()
        {
            try
            {
                var servicos = await _servicoService.GetServicos();
                return Ok(servicos);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter servicos");
            }
        }

        /*[HttpGet]   
        public IEnumerable<Veiculo> GetVeiculo()
        {
            return _Context.Veiculos;
        }

        [HttpPost]
        public IActionResult AddVeiculo([FromBody] Veiculo Veiculo)
        {
            _Context.Veiculos.Add(Veiculo);
            _Context.SaveChanges();
            return CreatedAtAction(nameof(GetVeiculoById), new { Id = Veiculo.Id }, Veiculo);
        }

        [HttpGet("{id}")]
        public IActionResult GetVeiculoById(int id)
        {
            Veiculo Veiculo = _Context.Veiculos.FirstOrDefault(Veiculo => Veiculo.Id == id);
            if (Veiculo != null)
            {
                return Ok(Veiculo);
            }
            return NotFound();
        }*/
    }
}
