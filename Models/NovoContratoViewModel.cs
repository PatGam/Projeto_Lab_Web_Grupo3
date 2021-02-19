using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class NovoContratoViewModel
    {
        public Contratos Contratos { get; set; }
        //public List<Pacotes> Pacotes { get; set; }

        public Pacotes Pacotes { get; set; }
        public List<Promocoes> Promocoes { get; set; }
        public List<PromocoesPacotes> PromocoesPacotes { get; set; }
    }
}
