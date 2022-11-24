using Despachantes.Data;
using Despachantes.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Despachantes.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
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

            var Clientes = GetCliente();

            var ValidaCpf = Clientes.Where(C => C.Cpf == Cliente.Cpf).ToList();
            try
            {
                if (ValidaCpf.Count <= 0)
                {
                    _Context.Clientes.Add(Cliente);
                    _Context.SaveChanges();
                        return CreatedAtAction(nameof(GetClienteById), new { Id = Cliente.Id }, Cliente);
                }

                else
                {
                    return StatusCode(403);
                }
            }
            catch
            {
                return BadRequest("Erro ao cadastrar");
            }

        }

        [HttpGet("cpf")]
        public IActionResult GetClienteByCpf([FromQuery] string Cpf)
        {
            try
            {
                var cliente = _Context.Clientes.Where(c => c.Cpf.Contains(Cpf));

                if(cliente != null)
                {
                    return Ok(cliente);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return BadRequest("Erro ao consultar por Cpf");
            }
            
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetClienteById(int id)
        {
            IEnumerable<Cliente> Cliente = await _Context.Clientes.Where(Cliente => Cliente.Id == id).ToListAsync();
            if (Cliente == null)
            {
                return NotFound();

            }
            return Ok(Cliente);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var DeletCliente = await _Context.Clientes.FindAsync(id);
            if (DeletCliente == null)
            {
                return NotFound();
            }

            _Context.Clientes.Remove(DeletCliente);
            await _Context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, Cliente cliente)
        {

            var Clientes = await _Context.Clientes.Where(C => C.Cpf == cliente.Cpf && C.Id != cliente.Id).ToListAsync();

            try
            {
                if (Clientes.Count <= 0)
                {
                   _Context.Entry(cliente).State = EntityState.Modified;
                   await _Context.SaveChangesAsync();
                    return Ok(cliente);
                }
                else
                {
                    return StatusCode(403);
                }
            }
            catch
            {
                return BadRequest("Erro ao editar CLiente");
            }
        }

        private bool ClienteExists(int id)
        {
            throw new NotImplementedException();
        }
    }
}