using Despachantes.Data;
using Despachantes.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Despachantes.Controllers
{
    [ApiController]
    [Route("[Controller]")]

    public class Cliente_ServicoController : ControllerBase
    {

        private DespachanteContext _Context;

        public Cliente_ServicoController(DespachanteContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public IEnumerable<Cliente_Servico> GetCliente_Servico()
        {
            return _Context.Clientes_Servicos;
        }

        [HttpPost]
        public IActionResult AddCliente_Servico([FromBody] Cliente_Servico Cliente_Servico)
        {
            _Context.Clientes_Servicos.Add(Cliente_Servico);
            _Context.SaveChanges();
            return CreatedAtAction(nameof(GetCliente_ServicoById), new { Id = Cliente_Servico.Id }, Cliente_Servico);
        }

        [HttpGet("{id}")]
        public IActionResult GetCliente_ServicoById(int id)
        {
            Cliente_Servico Cliente_Servico = _Context.Clientes_Servicos.FirstOrDefault(Cliente_Servico => Cliente_Servico.Id == id);
            if (Cliente_Servico != null)
            {
                return Ok(Cliente_Servico);
            }
            return NotFound();
        }


    }
}
