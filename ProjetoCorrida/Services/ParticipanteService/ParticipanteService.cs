using AutoMapper;
using ProjetoCorrida.Dtos.Participante;
using ProjetoCorrida.Models;
using ProjetoCorrida.Repositories.Participante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCorrida.Services.ParticipanteService
{
    public class ParticipanteService : IParticipanteService
    {
        private readonly IMapper _mapper;
        private readonly IParticipanteRepository _participanteRepository;

        public ParticipanteService(IMapper mapper, IParticipanteRepository participanteRepository)
        {
            _mapper = mapper;
            _participanteRepository = participanteRepository;
        }

        public async Task<ServiceResponse<List<ObterParticipanteDto>>> Obter()
        {
            var sr = new ServiceResponse<List<ObterParticipanteDto>>();
            try
            {
                var listaParticipante = await _participanteRepository.Obter();

                sr.Value = _mapper.Map<List<ObterParticipanteDto>>(listaParticipante);
            }
            catch (Exception ex)
            {
                sr.Sucess = false;
                sr.Messages.Add(ex.Message);
            }
            return sr;
        }

        public async Task<ServiceResponse<ObterParticipanteDto>> Obter(Guid id)
        {
            var sr = new ServiceResponse<ObterParticipanteDto>();
            try
            {
                var participante = await _participanteRepository.Obter(id);

                sr.Value = _mapper.Map<ObterParticipanteDto>(participante);
            }
            catch (Exception ex)
            {
                sr.Sucess = false;
                sr.Messages.Add(ex.Message);
            }
            return sr;
        }

        public async Task<ServiceResponse<ObterParticipanteDto>> Criar(CriarParticipanteDto criarParticipante)
        {
            var sr = new ServiceResponse<ObterParticipanteDto>();
            try
            {
                var participante = _mapper.Map<Participante>(criarParticipante);
                var response = await _participanteRepository.Criar(participante);
                sr.Value = _mapper.Map<ObterParticipanteDto>(response);
            }
            catch (Exception ex)
            {
                sr.Sucess = false;
                sr.Messages.Add(ex.Message);
            }
            return sr;
        }

        public async Task<ServiceResponse<ObterParticipanteDto>> Atualizar(AtualizarParticipanteDto atualizarParticipante)
        {
            var sr = new ServiceResponse<ObterParticipanteDto>();
            try
            {
                var obterParticipante = await Obter(atualizarParticipante.Id);
                if (!obterParticipante.Sucess)
                    throw new Exception();

                var participante = _mapper.Map<Participante>(obterParticipante.Value);
                participante.Nome = atualizarParticipante.Nome;
                participante.RG = atualizarParticipante.RG;
                participante.Email = atualizarParticipante.Email;
                participante.Sexo = atualizarParticipante.Sexo;
                participante.Telefone = atualizarParticipante.Telefone;
                participante.Endereco = atualizarParticipante.Endereco;
                participante.NumeroCamisa = atualizarParticipante.NumeroCamisa;

                var response = await _participanteRepository.Atualizar(participante);
                sr.Value = _mapper.Map<ObterParticipanteDto>(response);
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
                sr.Value = await _participanteRepository.Excluir(id);
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
