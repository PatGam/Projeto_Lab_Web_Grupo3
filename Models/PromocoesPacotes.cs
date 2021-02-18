using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Projeto_Lab_Web_Grupo3.Models
{
    [Table("Promocoes_Pacotes")]
    public partial class PromocoesPacotes
    {
        public PromocoesPacotes()
        {
            Contratos = new HashSet<Contratos>();
        }

        [Column("Pacote_Id")]
        public int PacoteId { get; set; }
        [Column("Promocoes_Id")]
        public int PromocoesId { get; set; }
        [Key]
        [Column("Promocoes_Pacotes_Id")]
        public int PromocoesPacotesId { get; set; }
        [Required]
        [Column("Nome_Pacote")]
        [StringLength(100)]
        [Display(Name = "Nome do Pacote")]
        public string NomePacote { get; set; }
        [Required]
        [Column("Nome_Promocoes")]
        [StringLength(100)]
        [Display(Name = "Nome da Promoção")]
        public string NomePromocoes { get; set; }

        [ForeignKey(nameof(PacoteId))]
        [InverseProperty(nameof(Pacotes.PromocoesPacotes))]
        public virtual Pacotes Pacote { get; set; }
        [ForeignKey(nameof(PromocoesId))]
        [InverseProperty("PromocoesPacotes")]
        [Display(Name = "Promoções")]
        public virtual Promocoes Promocoes { get; set; }
        [InverseProperty("PromocoesPacotesNavigation")]
        public virtual ICollection<Contratos> Contratos { get; set; }
    }
}
