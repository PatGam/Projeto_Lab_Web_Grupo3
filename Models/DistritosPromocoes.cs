using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class DistritosPromocoes
    {
        [Column("Distrito_Id")]
        public int DistritosId { get; set; }
        [Column("Promocoes_Id")]
        public int PromocoesId { get; set; }

        [Key]
        [Column("Distritos_Promocoes_Id")]
        public int DistritosPromocoesId { get; set; }


        [ForeignKey(nameof(PromocoesId))]
        [InverseProperty(nameof(Promocoes.DistritosPromocoes))]
        public virtual Promocoes Promocao { get; set; }

        [ForeignKey(nameof(DistritosId))]
        [InverseProperty(nameof(Distritos.DistritosPromocoes))]
        [Display(Name = "Distritos")]
        public virtual Distritos Distrito { get; set; }
    }
}
