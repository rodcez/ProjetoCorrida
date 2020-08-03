using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCorrida.Models
{
    public class Corrida
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Distancia { get; set; }
        public string Percurso { get; set; }
    }
}
