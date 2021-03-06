﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class PromocoesViewModel
    {
        public List<Promocoes> Promocoes { get; set; }
        public Paginacao Paginacao { get; set; }
        public string NomePesquisar { get; set; }

        public List<Checkbox> ListaDistritosCentro { get; set; }
        public List<Checkbox> ListaDistritosNorte { get; set; }

        public List<Checkbox> ListaDistritosSul { get; set; }

        public List<Checkbox> ListaDistritosIlhas { get; set; }
    }
}
