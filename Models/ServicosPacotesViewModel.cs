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

        public int PacoteId { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public decimal Preco { get; set; }
        public List<ServicosPacotes> ServicosPacotes { get; set; }

        public Tipos_Sevicos TiposServicos { get; set; }
        public List<PromocoesPacotes> PromocoesPacotes { get; set; }
        public Paginacao Paginacao { get; set; }
        public string NomePesquisar { get; set; }
        public List<Checkbox> ListaServicos { get; set; }

        public List<Servicos> ListasServicos { get; set; }

        public int Servico1 { get; set; }

        public int Servico2 { get; set; }

        public int Servico3 { get; set; }
        public int Servico4 { get; set; }
        public int Servico5 { get; set; }



    }
}
