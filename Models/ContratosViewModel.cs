using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class ContratosViewModel
    {
        public List<Contratos> Contratos { get; set; }
        public Paginacao Paginacao { get; set; }
        public string NifPesquisar { get; set; }
        public List<Promocoes> Promocoes { get; set; }
        public List<Pacotes> Pacotes { get; set; }
        public int UtilizadorId { get; set; }

        public int FuncionarioId { get; set; }

        public Utilizadores Utilizadores { get; set; }

        public bool Inactivo { get; set; }

        [Required(ErrorMessage = "Preencha a morada")]
        [StringLength(500, ErrorMessage = "A morada não pode ter mais de 500 caracteres")]
        [Display(Name = "Morada")]
        public string Morada { get; set; }

        [Required(ErrorMessage = "Preencha o código postal")]
        [Column("Codigo_Postal")]
        [RegularExpression(@"(\d{4})[-](\d{3})", ErrorMessage = "Código Postal Inválido")]
        [StringLength(8, MinimumLength = 8)]
        [Display(Name = "Código Postal")]
        public string CodigoPostal { get; set; }

        [Display(Name = "Nome do cliente")]
        public int ClienteId { get; set; }

        [Display(Name = "Pacote utilizado")]

        public int PacoteId { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [Column("Data_inicio", TypeName = "date")]
        [Display(Name = "Data de Início")]
        public DateTime DataInicio { get; set; }


        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [Column("Data_Fim", TypeName = "date")]
        [Display(Name = "Data de Fim")]
        public DateTime DataFim { get; set; }

        [Column("Telefone")]
        [RegularExpression(@"(2\d{8})", ErrorMessage = "Telefone Inválido")]
        public int Telefone { get; set; }





    }
}
