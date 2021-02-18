using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class ServicosPacotesViewModel
    {
        public List<ServicosPacotes> ServicosPacotes { get; set; }
        public List<Pacotes> Pacotes { get; set; }
        public List<Servicos> Servicos { get; set; }
        public Paginacao Paginacao { get; set; }
        public string NomePesquisar { get; set; }
    }
}
