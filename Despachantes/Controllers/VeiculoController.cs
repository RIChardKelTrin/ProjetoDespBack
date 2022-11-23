using Despachantes.Data;
using Despachantes.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Despachantes.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]

    public class VeiculoController :ControllerBase
    {

        private DespachanteContext _Context;

        public VeiculoController(DespachanteContext context)
        {
            _Context = context;
        }

        [HttpGet]   
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
        }
    }
}
