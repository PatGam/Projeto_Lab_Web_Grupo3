using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Projeto_Lab_Web_Grupo3.Models
{
    public class ServicosPacotesViewModel
    {
        //public List<ServicosPacotes> ServicosPacotes { get; set; }
        public Pacotes Pacotes { get; set; }
        public List<ServicosPacotes> ServicosPacotes { get; set; }

        public Tipos_Sevicos TiposServicos { get; set; }
        public List<PromocoesPacotes> PromocoesPacotes { get; set; }
        public Paginacao Paginacao { get; set; }
        public string NomePesquisar { get; set; }
        public List<Checkbox> ListaServicos { get; set; }

    }
}
