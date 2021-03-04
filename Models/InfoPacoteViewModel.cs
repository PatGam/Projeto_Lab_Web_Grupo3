using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class InfoPacoteViewModel

    {
        public Pacotes Pacote { get; set; }

        public List<Servicos> Servicos { get; set; }


        public List<Promocoes> Promocoes { get; set; }

    }
}
