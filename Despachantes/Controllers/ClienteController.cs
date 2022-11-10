using Despachantes.Data;
using Despachantes.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Despachantes.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ClienteController : ControllerBase
    {
        private DespachanteContext _Context;

        public ClienteController(DespachanteContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public IEnumerable<Cliente> GetCliente()
        {
            return _Context.Clientes;
        }

        [HttpPost]
        public IActionResult AddCliente([FromBody] Cliente Cliente)
        {
            _Context.Clientes.Add(Cliente);
            _Context.SaveChanges();
            return CreatedAtAction(nameof(GetClienteById), new { Id = Cliente.Id }, Cliente);
        }

        [HttpGet("{id}")]
        public IActionResult GetClienteById(int id)
        {
            Cliente Cliente = _Context.Clientes.FirstOrDefault(Cliente => Cliente.Id == id);
            if (Cliente != null)
            {
                return Ok(Cliente);
            }
            return NotFound();
        }
    }
}
