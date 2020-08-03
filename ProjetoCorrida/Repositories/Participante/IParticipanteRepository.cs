using System;
using System.Collections.Generic;
using ProjetoCorrida.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCorrida.Repositories.Participante
{
    public interface IParticipanteRepository
    {
        Task<List<Models.Participante>> Obter();
        Task<Models.Participante> Obter(Guid id);
        Task<Models.Participante> Criar(Models.Participante participante);
        Task<Models.Participante> Atualizar(Models.Participante participante);
        Task<bool> Excluir(Guid id);
    }
}
