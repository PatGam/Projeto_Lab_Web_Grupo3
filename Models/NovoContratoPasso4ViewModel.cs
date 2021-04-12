using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class NovoContratoPasso4ViewModel
    {
        [Display(Name = "Nome do cliente")]
        public int ClienteId { get; set; }

        public int UtilizadorId { get; set; }

        public Utilizadores Cliente { get; set; }

        [Display(Name = "Data de Início")]
        public DateTime DataInicio { get; set; }

        [Display(Name = "Data de Fim")]
        public DateTime DataFim { get; set; }

        public int Telefone { get; set; }

        
        public string Morada { get; set; }

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
