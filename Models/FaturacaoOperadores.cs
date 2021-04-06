using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class FaturacaoOperadores
    {
        [Key]
        [Column("Faturacao_Operadores")]
        public int FaturacaoOperadoresId { get; set; }

        //Operador
        public int UtilizadorId { get; set; }
        public Utilizadores Utilizadores { get; set; }

        public int Mes { get; set; }

        public string NomeMes { get; set; }

        public decimal TotalFaturacao { get; set; }


    }
}
