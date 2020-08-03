using Microsoft.AspNetCore.Mvc;
using ProjetoCorrida.Dtos.Corrida;
using ProjetoCorrida.Services.CorridaService;
using System;
using System.Threading.Tasks;

namespace ProjetoCorrida.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CorridaController : ControllerBase
    {
        private readonly ICorridaService _corridaService;

        public CorridaController(ICorridaService corridaService)
        {
            _corridaService = corridaService;
        }

        [HttpGet]
        public async Task<IActionResult> Obter()
        {
            var response = await _corridaService.Obter();
            if (!response.Sucess)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Obter([FromRoute] Guid id)
        {
            var response = await _corridaService.Obter(id);
            if (!response.Sucess)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarCorridaDto corrida)
        {
            var response = await _corridaService.Criar(corrida);
            if (!response.Sucess)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarCorridaDto corrida)
        {
            var response = await _corridaService.Atualizar(corrida);
            if (!response.Sucess)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Excluir([FromRoute] Guid id)
        {
            var response = await _corridaService.Excluir(id);
            if (!response.Sucess)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
