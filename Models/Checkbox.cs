﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class Checkbox
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string NomePacote { get; set; }

        public int TipoServico { get; set; }

        public string NomeTipoServico { get; set; }
        public bool Selecionado { get; set; }
    }
}
