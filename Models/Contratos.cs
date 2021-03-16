using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Projeto_Lab_Web_Grupo3.ModeloER;
#nullable disable
namespace Projeto_Lab_Web_Grupo3.Models
{
    public partial class Contratos
    {
        [Key]
        [Column("Contrato_Id")]
        public int ContratoId { get; set; }

        public int UtilizadorId { get; set; }
        public Utilizadores Utilizadores { get; set; }


        [Display(Name = "Nome do cliente")]
        public int ClienteId { get; set; }

        [Display(Name = "Funcionário responsável")]
        public int FuncionarioId { get; set; }

        [Display(Name = "Pacote utilizado")]

        public int PacoteId { get; set; }

        public Pacotes Pacotes { get; set; }

        public string NomePacote { get; set; }


        [Display(Name = "Promoção aplicada")]
        public int PromocoesId { get; set; }

        public Promocoes Promocoes { get; set; }


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
        [Column("Preco_pacote", TypeName = "decimal(18, 2)")]
        //[RegularExpression(@"^([0-9]*[1-9][0-9]*(\,[0-9]+)?|[0]+\,[0-9]*[1-9][0-9]*)$", ErrorMessage = "O valor tem ser superior a 0")]
        [Display(Name = "Preço do Pacote")]
        public decimal PrecoPacote { get; set; }
        [Column("Promocao_desc", TypeName = "decimal(18, 2)")]
        //[RegularExpression(@"^([0-9]*[1-9][0-9]*(\,[0-9]+)?|[0]+\,[0-9]*[1-9][0-9]*)$", ErrorMessage = "O valor tem ser superior a 0")]
        [Display(Name = "Desconto da Promoção")]
        public decimal PromocaoDesc { get; set; }
        [Column("Preco_Final", TypeName = "decimal(18, 2)")]
        //[RegularExpression(@"^([0-9]*[1-9][0-9]*(\,[0-9]+)?|[0]+\,[0-9]*[1-9][0-9]*)$", ErrorMessage = "O valor tem ser superior a 0")]
        [Display(Name = "Preço Final")]
        public decimal PrecoFinal { get; set; }

        [Display(Name = "Inactivo")]
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

        public virtual ICollection<ServicosContratos> ServicosContratos { get; set; }

        public int DistritosId { get; set; }
        public Distritos Distritos { get; set; }
        //[ForeignKey(nameof(ClienteId))]
        //[InverseProperty(nameof(Clientes.Contratos))]
        //public virtual Clientes Cliente { get; set; }
        //[ForeignKey(nameof(FuncionarioId))]
        //[InverseProperty(nameof(Funcionarios.Contratos))]
        //public virtual Funcionarios Funcionario { get; set; }
        //[ForeignKey(nameof(PromocoesPacotes))]
        //[InverseProperty("Contratos")]
        //public virtual PromocoesPacotes PromocoesPacotesNavigation { get; set; }
    }
}