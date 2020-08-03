using ProjetoCorrida.Dtos.Participante;
using ProjetoCorrida.Models;
using ProjetoCorrida.Services.ParticipanteService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCorrida.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParticipanteController : ControllerBase
    {
        private readonly IParticipanteService _participanteService;

        public ParticipanteController(IParticipanteService participanteService)
        {
            _participanteService = participanteService;
        }

        [HttpGet]
        public async Task<IActionResult> Obter()
        {
            var response = await _participanteService.Obter();
            if (!response.Sucess)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Obter([FromRoute] Guid id)
        {
            var response = await _participanteService.Obter(id);
            if (!response.Sucess)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarParticipanteDto participante)
        {
            var response = await _participanteService.Criar(participante);
            if (!response.Sucess)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] AtualizarParticipanteDto participante)
        {
            var response = await _participanteService.Atualizar(participante);
            if (!response.Sucess)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Excluir([FromRoute] Guid id)
        {
            var response = await _participanteService.Excluir(id);
            if (!response.Sucess)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
