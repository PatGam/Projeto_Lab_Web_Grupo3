using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class Top10ViewModel

    {
        public List<Contratos> Contratos { get; set; }
        public List<Utilizadores> Utilizadores { get; set; }
        public int UtilizadorId { get; set; }        
    }
}
