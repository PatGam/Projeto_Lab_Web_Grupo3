using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class ReclamacoesViewModel
    {
        public List <Reclamacoes> Reclamacoes { get; set; }
        public int ReclamacaoId { get; set; }
        public Paginacao Paginacao { get; set; }
        [StringLength(1000)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data de Reclamação")]
        public DateTime DataReclamacao { get; set; }
        [Display(Name = "Resposta do Operador")]
        public string Resposta { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data de Resposta")]
        public DateTime DataResposta { get; set; }

        public bool EstadoResposta { get; set; }
        [Display(Name = "Estado Resolução")]
        public bool EstadoResolução { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Data de Resolução")]
        public DateTime DataResolucao { get; set; }

        public int ClienteId { get; set; }

        public int FuncionarioId { get; set; }
        [Display(Name = "Arquivado")]
        public bool Inactivo { get; set; }
        public int ContratoId { get; set; }
        public string NifPesquisar { get; set; }
        public string NomePesquisar { get; set; }

        [ForeignKey(nameof(ClienteId))]
        [InverseProperty(nameof(Utilizadores.ReclamacoesCliente))]
        public virtual Utilizadores Cliente { get; set; }

        [ForeignKey(nameof(FuncionarioId))]
        [InverseProperty(nameof(Utilizadores.ReclamacoesFuncionario))]
        public virtual Utilizadores Funcionario { get; set; }
        [ForeignKey(nameof(ContratoId))]
        [InverseProperty("Reclamacao")]
        public virtual Contratos Contratos { get; set; }
    }
}
