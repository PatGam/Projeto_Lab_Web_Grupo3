using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Projeto_Lab_Web_Grupo3.Models;

#nullable disable

namespace Projeto_Lab_Web_Grupo3.Models
{
    public partial class Promocoes
    {
        public Promocoes()
        {
            PromocoesPacotes = new HashSet<PromocoesPacotes>();
            DistritosPromocoes = new HashSet<DistritosPromocoes>();

        }

        [Key]
        [Column("Promocoes_Id")]
        public int PromocoesId { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

    
        [StringLength(1000)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [Column("Data_inicio", TypeName = "date")]
        [Display(Name = "Data Início")]
        public DateTime DataInicio { get; set; }

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
        public virtual ICollection<PromocoesPacotes> PromocoesPacotes { get; set; }

        public virtual ICollection<DistritosPromocoes> DistritosPromocoes { get; set; }


        public virtual ICollection<Contratos> Contratos { get; set; }

        [Display(Name = "Inactivo")]
        public bool Inactivo { get; set; }
    }
}
