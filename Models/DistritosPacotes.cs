using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class DistritosPacotes
    {
        [Column("Distrito_Id")]
        public int DistritosId { get; set; }
        [Column("Pacote_Id")]
        public int PacoteId { get; set; }
        [Key]
        [Column("Distrito_Pacote_Id")]
        public int DistritosPacotesId { get; set; }


        [ForeignKey(nameof(PacoteId))]
        [InverseProperty(nameof(Pacotes.DistritosPacotes))]
        public virtual Pacotes Pacote { get; set; }

        [ForeignKey(nameof(DistritosId))]
        [InverseProperty("DistritosPacotes")]
        [Display(Name = "Distritos")]
        public virtual Distritos Distritos { get; set; }
    }
}
