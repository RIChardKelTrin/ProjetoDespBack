using Despachantes.Model;
using Despachantes.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Despachantes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicosController : ControllerBase
    {
        private IServicoService _servicoService;

        public ServicosController(IServicoService servicoService)
        {
            _servicoService = servicoService;
        }
        [HttpGet]
        public async Task<ActionResult <IAsyncEnumerable<Servico>>> GetServicos()
        {
            try {
                var servicos = await _servicoService.GetServicos();
                return Ok(servicos);
            } 
            catch {
                //return BadRequest("Rrequest Invalido")
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Servicos");
            }
        }



        [HttpGet("ServicosPorNome")]
        public async Task<ActionResult<IAsyncEnumerable<Servico>>> 
            GetServicosByNames([FromQuery] string nome )
        {
            try
            {
                var servicos = await _servicoService.GetServicoByNome(nome);
                if (servicos.Count() == 0)
                {
                    return NotFound($"Servico Não encontrado {nome}");
                }
                return Ok(servicos);
            }
            catch
            {
                return BadRequest("Rrequest Invalido");
               

            }

        }



        [HttpGet("{id:int}", Name = "GetServicos")]
        public async Task<ActionResult<Servico>> GetServicos(int id)
        {
            try
            {
                var servico = await _servicoService.GetServicoById(id);

                if (servico == null) return NotFound($"Não existe servico com esse id ={id}");

                    return Ok(servico);
                
              
            }
            catch
            {
                return BadRequest("Rrequest Invalido");

            }

        }

        [HttpPost]

        public async Task<ActionResult> Create(Servico servico)
        {
            try { 
             await _servicoService.CreateServico(servico);
                return CreatedAtRoute(nameof(GetServicos), new {id= servico.Id},servico);
               
            }

            catch {
                return BadRequest("Rrequest Invalido");
            }
          
        }


        [HttpPut("{id:int}")]
    
    public async Task<ActionResult> EditServico(int id, [FromBody] Servico servico)
        {
            try
            {
                if(servico.Id == id)
                {
                    await _servicoService.UpdateServico(servico);
                    return Ok($"Servico com id {id} Foi atualizado");
                }
                else{
                    return BadRequest("Dados inconsistente");
                }
                
            }

            catch
            {
                return BadRequest("Rrequest Invalido");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Servico>> DeleteServico(int id)
        {
            try
            {
                var veiculo = await _servicoService.GetServicoById(id);

                if (veiculo == null) return NotFound($"Servico com o id = {id} não encontrado!");

                await _servicoService.DeleteServico(veiculo);
                return Ok($"Servico com o id = {id} excluído com sucesso!");
            }
            catch
            {
                return BadRequest("Request Inválido");
            }
        }


    }

}
