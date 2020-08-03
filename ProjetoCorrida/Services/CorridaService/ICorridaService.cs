using ProjetoCorrida.Models;
using ProjetoCorrida.Dtos.Corrida;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCorrida.Services.CorridaService
{
    public interface ICorridaService
    {
        Task<ServiceResponse<List<ObterCorridaDto>>> Obter();
        Task<ServiceResponse<ObterCorridaDto>> Obter(Guid id);
        Task<ServiceResponse<ObterCorridaDto>> Criar(CriarCorridaDto criarCorrida);
        Task<ServiceResponse<ObterCorridaDto>> Atualizar(AtualizarCorridaDto atualizarCorrida);
        Task<ServiceResponse<bool>> Excluir(Guid id);
    }
}
