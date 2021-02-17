using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Projeto_Lab_Web_Grupo3.Models
{
    public partial class Contratos
    {
        [Key]
        [Column("Contrato_Id")]
        public int ContratoId { get; set; }
        [Column("Cliente_Id")]
        public int ClienteId { get; set; }
        [Column("Funcionario_Id")]
        public int FuncionarioId { get; set; }
        [Column("Data_inicio", TypeName = "date")]
        public DateTime DataInicio { get; set; }
        [Column("Preco_Final", TypeName = "decimal(18, 2)")]
        [RegularExpression(@"^([0-9]*[1-9][0-9]*(\,[0-9]+)?|[0]+\,[0-9]*[1-9][0-9]*)$", ErrorMessage = "O valor tem ser superior a 0")]
        public decimal PrecoFinal { get; set; }
        [Column("Data_Fim", TypeName = "date")]
        public DateTime DataFim { get; set; }
        [Column("Promocoes_Pacotes")]
        public int PromocoesPacotes { get; set; }
        [Column("Preco_pacote", TypeName = "decimal(18, 2)")]
        [RegularExpression(@"^([0-9]*[1-9][0-9]*(\,[0-9]+)?|[0]+\,[0-9]*[1-9][0-9]*)$", ErrorMessage = "O valor tem ser superior a 0")]
        public decimal PrecoPacote { get; set; }
        [Column("Promocao_desc", TypeName = "decimal(18, 2)")]
        [RegularExpression(@"^([0-9]*[1-9][0-9]*(\,[0-9]+)?|[0]+\,[0-9]*[1-9][0-9]*)$", ErrorMessage = "O valor tem ser superior a 0")]
        public decimal PromocaoDesc { get; set; }
        [Required]
        [Column("Nome_Cliente")]
        [StringLength(100)]
        public string NomeCliente { get; set; }
        [Required]
        [Column("Nome_Funcionario")]
        [StringLength(100)]
        public string NomeFuncionario { get; set; }
        [Column("Telefone")]
        [RegularExpression(@"(2\d{8})", ErrorMessage = "Telefone Inválido")]
        public int Telefone { get; set; }

        [ForeignKey(nameof(ClienteId))]
        [InverseProperty(nameof(Clientes.Contratos))]
        public virtual Clientes Cliente { get; set; }
        [ForeignKey(nameof(FuncionarioId))]
        [InverseProperty(nameof(Funcionarios.Contratos))]
        public virtual Funcionarios Funcionario { get; set; }
        [ForeignKey(nameof(PromocoesPacotes))]
        [InverseProperty("Contratos")]
        public virtual PromocoesPacotes PromocoesPacotesNavigation { get; set; }
    }
}
