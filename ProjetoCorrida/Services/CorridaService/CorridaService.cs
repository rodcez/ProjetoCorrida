using AutoMapper;
using ProjetoCorrida.Models;
using ProjetoCorrida.Dtos.Corrida;
using ProjetoCorrida.Models;
using ProjetoCorrida.Repositories.Corrida;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCorrida.Services.CorridaService
{
    public class CorridaService : ICorridaService
    {
        private readonly IMapper _mapper;
        private readonly ICorridaRepository _corridaRepository;

        public CorridaService(IMapper mapper, ICorridaRepository corridaRepository)
        {
            _mapper = mapper;
            _corridaRepository = corridaRepository;
        }

        public async Task<ServiceResponse<List<ObterCorridaDto>>> Obter()
        {
            var sr = new ServiceResponse<List<ObterCorridaDto>>();
            try
            {
                var listaCorrida = await _corridaRepository.Obter();

                sr.Value = _mapper.Map<List<ObterCorridaDto>>(listaCorrida);
            }
            catch (Exception ex)
            {
                sr.Sucess = false;
                sr.Messages.Add(ex.Message);
            }
            return sr;
        }

        public async Task<ServiceResponse<ObterCorridaDto>> Obter(Guid id)
        {
            var sr = new ServiceResponse<ObterCorridaDto>();
            try
            {
                var corrida = await _corridaRepository.Obter(id);

                sr.Value = _mapper.Map<ObterCorridaDto>(corrida);
            }
            catch (Exception ex)
            {
                sr.Sucess = false;
                sr.Messages.Add(ex.Message);
            }
            return sr;
        }

        public async Task<ServiceResponse<ObterCorridaDto>> Criar(CriarCorridaDto criarCorrida)
        {
            var sr = new ServiceResponse<ObterCorridaDto>();
            try
            {
                var corrida = _mapper.Map<Corrida>(criarCorrida);
                var response = await _corridaRepository.Criar(corrida);
                sr.Value = _mapper.Map<ObterCorridaDto>(response);
            }
            catch (Exception ex)
            {
                sr.Sucess = false;
                sr.Messages.Add(ex.Message);
            }
            return sr;
        }

        public async Task<ServiceResponse<ObterCorridaDto>> Atualizar(AtualizarCorridaDto atualizarCorrida)
        {
            var sr = new ServiceResponse<ObterCorridaDto>();
            try
            {
                var obterCorrida = await Obter(atualizarCorrida.Id);
                if (!obterCorrida.Sucess)
                    throw new Exception();

                var corrida = _mapper.Map<Corrida>(obterCorrida.Value);
                corrida.Nome = atualizarCorrida.Nome;
                corrida.Distancia = atualizarCorrida.Distancia;
                corrida.Percurso = atualizarCorrida.Percurso;

                var response = await _corridaRepository.Atualizar(corrida);
                sr.Value = _mapper.Map<ObterCorridaDto>(response);
            }
            catch (Exception ex)
            {
                sr.Sucess = false;
                sr.Messages.Add(ex.Message);
            }
            return sr;
        }

        public async Task<ServiceResponse<bool>> Excluir(Guid id)
        {
            var sr = new ServiceResponse<bool>();
            try
            {
                sr.Value = await _corridaRepository.Excluir(id);
            }
            catch (Exception ex)
            {
                sr.Sucess = false;
                sr.Messages.Add(ex.Message);
            }
            return sr;
        }
    }
}
