using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class HomeGestaoViewModel
    {

        public List<Utilizadores> Utilizadores { get; set; }


        public List<Promocoes> Promocoes { get; set; }

        public List<Servicos> Servicos { get; set; }

        public List<ServicosPacotes> ServicosPacotes { get; set; }

        public List<PromocoesPacotes> PromocoesPacotes { get; set; }

        public List<Pacotes> Pacotes { get; set; }

        public List<Contratos> Contratos { get; set; }

    }
}
