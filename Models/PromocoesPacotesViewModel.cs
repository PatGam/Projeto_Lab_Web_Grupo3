﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class PromocoesPacotesViewModel
    {
        public List<PromocoesPacotes> PromocoesPacotes { get; set; }
        public Paginacao Paginacao { get; set; }
        public string NomePesquisar { get; set; }
    }
}
