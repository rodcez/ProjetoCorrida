using ProjetoCorrida.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCorrida.Repositories.Participante
{
    public class ParticipanteRepository : IParticipanteRepository
    {
        public async Task<List<Models.Participante>> Obter()
        {
            using (var context = new CorridaContext())
            {
                return await context.Participantes.Select(s => s).ToListAsync();
            }
        }

        public async Task<Models.Participante> Obter(Guid id)
        {
            using (var context = new CorridaContext())
            {
                return await context.Participantes.FirstAsync(f => f.Id == id);
            }
        }

        public async Task<Models.Participante> Criar(Models.Participante participante)
        {
            using (var context = new CorridaContext())
            {
                participante.Id = Guid.NewGuid();
                await context.Participantes.AddAsync(participante);

                if((await context.SaveChangesAsync()) > 0)
                    return participante;

                return null;
            }
        }

        public async Task<Models.Participante> Atualizar(Models.Participante participante)
        {
            using (var context = new CorridaContext())
            {
                context.Entry(await context.Participantes.FirstOrDefaultAsync(f => f.Id == participante.Id)).CurrentValues.SetValues(participante);

                if ((await context.SaveChangesAsync()) > 0)
                    return participante;

                return null;
            }
        }

        public async Task<bool> Excluir(Guid id)
        {
            using (var context = new CorridaContext())
            {
                var participanteDb = await context.Participantes.FirstAsync(f => f.Id == id);
                context.Participantes.Remove(participanteDb);

                return (await context.SaveChangesAsync()) > 0;
            }
        }
    }
}
