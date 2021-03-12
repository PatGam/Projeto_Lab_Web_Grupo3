using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class PromocoesPacotesViewModel
    {
        //public List<PromocoesPacotes> PromocoesPacotes { get; set; }
        public Promocoes Promocoes { get; set; }
        public Pacotes Pacotes { get; set; }
        public List<PromocoesPacotes> PromocoesPacotes {get; set;}
        public Paginacao Paginacao { get; set; }
        public string NomePesquisar { get; set; }

        public List<Checkbox> ListaPacotes { get; set; }


        public int PromocoesId { get; set; }
        [Required ( ErrorMessage ="Tem de Preencher o nome")]
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(1000)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Tem de Preencher a data de início")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [Column("Data_inicio", TypeName = "date")]
        [Display(Name = "Data Início")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "Tem de Preencher a data de fim")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [Column("Data_fim", TypeName = "date")]
        [Display(Name = "Data de Fim")]
        public DateTime DataFim { get; set; }

        [Column("Promocao_desc", TypeName = "decimal(18, 2)")]
        [RegularExpression(@"^([0-9]*[1-9][0-9]*(\,[0-9]+)?|[0]+\,[0-9]*[1-9][0-9]*)$", ErrorMessage = "O valor tem ser superior a 0")]
        [Display(Name = "Desconto da Promoção")]
        public decimal PromocaoDesc { get; set; }

        [InverseProperty("Promocoes")]

        [Display(Name = "Inactivo")]
        public bool Inactivo { get; set; }

    }
}
