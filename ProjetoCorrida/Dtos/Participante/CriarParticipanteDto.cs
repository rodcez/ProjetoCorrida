﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoCorrida.Dtos.Participante
{
    public class CriarParticipanteDto
    {
        public string Nome { get; set; }
        public string RG { get; set; }
        public string Email { get; set; }
        public string Sexo { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public string NumeroCamisa { get; set; }
    }
}
