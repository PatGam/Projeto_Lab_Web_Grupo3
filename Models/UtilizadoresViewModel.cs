using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class UtilizadoresViewModel
    {
        public List<Utilizadores> Utilizador { get; set; }
        public Paginacao Paginacao { get; set; }
        public string nifPesquisa { get; set; }
    }
}
