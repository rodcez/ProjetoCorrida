using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCorrida.Dtos.Corrida
{
    public class AtualizarCorridaDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Distancia { get; set; }
        public string Percurso { get; set; }
    }
}
