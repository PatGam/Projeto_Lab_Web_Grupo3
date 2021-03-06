using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class ServicosPacotesViewModel
    {
        //public List<ServicosPacotes> ServicosPacotes { get; set; }
        public Pacotes Pacotes { get; set; }

        public int PacoteId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(1000)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Preço")]
        [RegularExpression(@"^([0-9]*[1-9][0-9]*(\,[0-9]+)?|[0]+\,[0-9]*[1-9][0-9]*)$", ErrorMessage = "O valor tem ser superior a 0")]
        public decimal Preco { get; set; }
        public List<ServicosPacotes> ServicosPacotes { get; set; }

        public List<PromocoesPacotes> PromocoesPacotes { get; set; }
        public Paginacao Paginacao { get; set; }
        public string NomePesquisar { get; set; }
        public List<Checkbox> ListaServicos { get; set; }

        public List<Servicos> ListasServicos { get; set; }

        public List<Tipos_Sevicos> TiposServicos { get; set; }


        public int Servico1 { get; set; }

        public int Servico2 { get; set; }

        public int Servico3 { get; set; }
        public int Servico4 { get; set; }
        public int Servico5 { get; set; }

        [Display(Name = "Imagem ilustrativa")]
        public byte[] Imagem { get; set; }



    }
}
