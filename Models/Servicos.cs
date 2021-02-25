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
        [Required(ErrorMessage = "Deve preencher o nome.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve no mínimo 3 caracteres e não deve exceder os 100 caracteres.")]
        public string Nome { get; set; }
        [StringLength(1000, ErrorMessage = "A descrição não deve exceder os 1000 caracteres.")]
        [Display(Name ="Descrição")]
        public string Descricao { get; set; }

        [Required]
        [Column("Tipo_Servico")]
        [Display(Name ="Tipo Serviço")]
        public int TipoServicoId { get; set; }
        public Tipos_Sevicos TipoServicos { get; set; }
       
        [InverseProperty("Servico")]
        public virtual ICollection<ServicosPacotes> ServicosPacotes { get; set; }
    }
}
