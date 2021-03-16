using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class Reclamacoes
    {
        [Key]
        [Column("Reclamacao_Id")]
        public int ReclamacaoId { get; set; }

        [StringLength(1000)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Recalamação")]
        public DateTime DataReclamacao { get; set; }

        [Display(Name = "Resposta do Operador")]
        public string Resposta { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Resposta")]
        public DateTime DataResposta { get; set; }

        public bool EstadoResposta { get; set; }

        public bool EstadoResolução { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Resolução")]
        public DateTime DataResolucao { get; set; }

        public int ClienteId { get; set; }

        public int FuncionarioId { get; set; }


        [ForeignKey(nameof(ClienteId))]
        [InverseProperty(nameof(Utilizadores.ReclamacoesCliente))]
        public virtual Utilizadores Cliente { get; set; }

        [ForeignKey(nameof(FuncionarioId))]
        [InverseProperty(nameof(Utilizadores.ReclamacoesFuncionario))]
        public virtual Utilizadores Funcionario { get; set; }


    }
}
