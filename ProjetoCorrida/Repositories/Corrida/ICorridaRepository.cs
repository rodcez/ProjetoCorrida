using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCorrida.Repositories.Corrida
{
    public interface ICorridaRepository
    {
        Task<List<Models.Corrida>> Obter();
        Task<Models.Corrida> Obter(Guid id);
        Task<Models.Corrida> Criar(Models.Corrida corrida);
        Task<Models.Corrida> Atualizar(Models.Corrida corrida);
        Task<bool> Excluir(Guid id);
    }
}
