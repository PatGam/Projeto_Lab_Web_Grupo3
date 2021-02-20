using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Projeto_Lab_Web_Grupo3.Models
{
    public partial class Promocoes
    {
        public Promocoes()
        {
            PromocoesPacotes = new HashSet<PromocoesPacotes>();
        }

        [Key]
        [Column("Promocoes_Id")]
        public int PromocoesId { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [StringLength(1000)]
        public string Descricao { get; set; }
        [Column("Data_inicio", TypeName = "date")]
        public DateTime DataInicio { get; set; }
        [Column("Data_fim", TypeName = "date")]
        public DateTime DataFim { get; set; }
        [Column("Promocao_desc", TypeName = "decimal(18, 2)")]
        public decimal PromocaoDesc { get; set; }

        [InverseProperty("Promocoes")]
        public virtual ICollection<PromocoesPacotes> PromocoesPacotes { get; set; }
    }
}
