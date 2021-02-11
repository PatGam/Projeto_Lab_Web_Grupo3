using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Projeto_Lab_Web_Grupo3.Models
{
    [Table("Servicos_Pacotes")]
    public partial class ServicosPacotes
    {
        [Column("Servico_Id")]
        public int ServicoId { get; set; }
        [Column("Pacote_Id")]
        public int PacoteId { get; set; }
        [Key]
        [Column("Sevico_Pacote_Id")]
        public int SevicoPacoteId { get; set; }

        [ForeignKey(nameof(PacoteId))]
        [InverseProperty(nameof(Pacotes.ServicosPacotes))]
        public virtual Pacotes Pacote { get; set; }
        [ForeignKey(nameof(ServicoId))]
        [InverseProperty(nameof(Servicos.ServicosPacotes))]
        public virtual Servicos Servico { get; set; }
    }
}
