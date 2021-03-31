using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class NovoContratoPasso2ViewModel
    {
        public int ClienteId { get; set; }
        public Utilizadores Cliente { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Início")]
        public DateTime DataInicio { get; set; }

        public DateTime DataFim { get; set; }

        [RegularExpression(@"(2\d{8})", ErrorMessage = "Telefone Inválido")]
        public int Telefone { get; set; }

        [Required(ErrorMessage = "Preencha a morada")]
        [StringLength(500, ErrorMessage = "A morada não pode ter mais de 500 caracteres")]
        [Display(Name = "Morada")]
        public string Morada { get; set; }

        [Required(ErrorMessage = "Preencha o código postal")]
        [RegularExpression(@"(\d{4})[-](\d{3})", ErrorMessage = "Código Postal Inválido")]
        [StringLength(8, MinimumLength = 8)]
        [Display(Name = "Código Postal")]
        public string CodigoPostal { get; set; }


        [Display(Name = "Pacote utilizado")]
        public int PacoteId { get; set; }

        public int PromocoesId { get; set; }

        [Display(Name = "Distrito")]

        public int DistritosId { get; set; }

        public bool UmAno { get; set; }

        public bool DoisAnos { get; set; }
    }
}
