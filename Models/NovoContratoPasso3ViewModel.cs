using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class NovoContratoPasso3ViewModel
    {
        public int ClienteId { get; set; }
        public Utilizadores Cliente { get; set; }


        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Início")]
        public DateTime DataInicio { get; set; }

        public int Telefone { get; set; }

        
        public string Morada { get; set; }

        
        public string CodigoPostal { get; set; }

        public int PacoteId { get; set; }

        public int PromocoesId { get; set; }


        public int DistritosId { get; set; }

        public bool UmAno { get; set; }

        public bool DoisAnos { get; set; }
    }
}
