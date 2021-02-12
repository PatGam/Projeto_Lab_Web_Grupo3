using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Projeto_Lab_Web_Grupo3.Models
{
    public partial class Servicos
    {
        public Servicos()
        {
            ServicosPacotes = new HashSet<ServicosPacotes>();
        }

        [Key]
        [Column("Servico_Id")]
        public int ServicoId { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [StringLength(1000)]
        [Display(Name ="Descrição")]
        public string Descricao { get; set; }
        [Required]
        [Column("Tipo_Servico")]
        [StringLength(50)]
        [Display(Name ="Tipo Serviço")]
        public string TipoServico { get; set; }

        [InverseProperty("Servico")]
        public virtual ICollection<ServicosPacotes> ServicosPacotes { get; set; }
    }
}
