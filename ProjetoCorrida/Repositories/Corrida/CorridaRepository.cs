using Microsoft.EntityFrameworkCore;
using ProjetoCorrida.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCorrida.Repositories.Corrida
{
    public class CorridaRepository : ICorridaRepository
    {
        public async Task<List<Models.Corrida>> Obter()
        {
            using (var context = new CorridaContext())
            {
                return await context.Corridas.Select(s => s).ToListAsync();
            }
        }

        public async Task<Models.Corrida> Obter(Guid id)
        {
            using (var context = new CorridaContext())
            {
                return await context.Corridas.FirstAsync(f => f.Id == id);
            }
        }

        public async Task<Models.Corrida> Criar(Models.Corrida corrida)
        {
            using (var context = new CorridaContext())
            {
                corrida.Id = Guid.NewGuid();
                await context.Corridas.AddAsync(corrida);

                if ((await context.SaveChangesAsync()) > 0)
                    return corrida;

                return null;
            }
        }

        public async Task<Models.Corrida> Atualizar(Models.Corrida corrida)
        {
            using (var context = new CorridaContext())
            {
                context.Entry(await context.Corridas.FirstOrDefaultAsync(f => f.Id == corrida.Id)).CurrentValues.SetValues(corrida);

                if ((await context.SaveChangesAsync()) > 0)
                    return corrida;

                return null;
            }
        }

        public async Task<bool> Excluir(Guid id)
        {
            using (var context = new CorridaContext())
            {
                var corridaDb = await context.Corridas.FirstAsync(f => f.Id == id);
                context.Corridas.Remove(corridaDb);

                return (await context.SaveChangesAsync()) > 0;
            }
        }
    }
}
