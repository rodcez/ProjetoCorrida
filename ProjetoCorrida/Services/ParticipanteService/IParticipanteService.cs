using ProjetoCorrida.Dtos.Participante;
using ProjetoCorrida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCorrida.Services.ParticipanteService
{
    public interface IParticipanteService
    {
        Task<ServiceResponse<List<ObterParticipanteDto>>> Obter();
        Task<ServiceResponse<ObterParticipanteDto>> Obter(Guid id);
        Task<ServiceResponse<ObterParticipanteDto>> Criar(CriarParticipanteDto participante);
        Task<ServiceResponse<ObterParticipanteDto>> Atualizar(AtualizarParticipanteDto participante);
        Task<ServiceResponse<bool>> Excluir(Guid id);
    }
}
