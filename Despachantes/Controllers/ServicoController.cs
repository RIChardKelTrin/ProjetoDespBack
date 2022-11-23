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

    public class ServicoController :ControllerBase
    {

        private DespachanteContext _Context;

        public ServicoController(DespachanteContext context)
        {
            _Context = context;
        }

        [HttpGet]   
        public IEnumerable<Servico> GetServico()
        {
            return _Context.Servicos;
        }

        [HttpPost]
        public IActionResult AddServico([FromBody] Servico Servico)
        {
            _Context.Servicos.Add(Servico);
            _Context.SaveChanges();
            return CreatedAtAction(nameof(GetServicoById), new { Id = Servico.Id }, Servico);
        }

        [HttpGet("{id}")]
        public IActionResult GetServicoById(int id)
        {
            Servico Servico = _Context.Servicos.FirstOrDefault(Servico => Servico.Id == id);
            if (Servico != null)
            {
                return Ok(Servico);
            }
            return NotFound();
        }
    }
}
