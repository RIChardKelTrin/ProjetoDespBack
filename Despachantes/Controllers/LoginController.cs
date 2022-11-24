using Despachantes.Data;
using Despachantes.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Despachantes.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class LoginController : ControllerBase
    {
        private DespachanteContext _Context;

        public LoginController(DespachanteContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public IEnumerable<Login> GetLogin()
        {
            return _Context.Logins;
        }

        [HttpPost]
        public IActionResult AddLogin([FromBody] Login Login)
        {
            _Context.Logins.Add(Login);
            _Context.SaveChanges();
            return CreatedAtAction(nameof(GetLoginById), new { Id = Login.Id }, Login);
        }

        [HttpGet("{id}/{usuario}/{senha}")]
        public IActionResult GetLoginById(int id, string usuario, int senha)
        {
            try
            {
                Login Login = _Context.Logins.FirstOrDefault(Login => Login.Id == id & Login.Usuario == usuario & Login.Senha == senha);
            if (Login != null)
            {
                return Ok(Login);
            }
            return NotFound();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
