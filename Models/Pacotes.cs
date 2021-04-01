using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Projeto_Lab_Web_Grupo3.Models;

#nullable disable

namespace Projeto_Lab_Web_Grupo3.Models
{
    public partial class Pacotes
    {
        public Pacotes()
        {
            PromocoesPacotes = new HashSet<PromocoesPacotes>();
            ServicosPacotes = new HashSet<ServicosPacotes>();
            DistritosPacotes = new HashSet<DistritosPacotes>();
          
        }

        [Key]
        [Column("Pacote_Id")]
        public int PacoteId { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [StringLength(1000)]
        [Display(Name ="Descrição")]
        public string Descricao { get; set; }


        [Column(TypeName = "decimal(18, 2)")]
        [Display (Name ="Preço")]
        [RegularExpression(@"^([0-9]*[1-9][0-9]*(\,[0-9]+)?|[0]+\,[0-9]*[1-9][0-9]*)$", ErrorMessage ="O valor tem ser superior a 0")]
        public decimal Preco { get; set; }

        [InverseProperty("Pacote")]
        public virtual ICollection<PromocoesPacotes> PromocoesPacotes { get; set; }
        [InverseProperty("Pacote")]
        public virtual ICollection<ServicosPacotes> ServicosPacotes { get; set; }

        public virtual ICollection<Contratos> Contratos { get; set; }

        [Display(Name = "Inactivo")]
        public bool Inactivo { get; set; }

        [Display(Name = "Imagem ilustrativa")]
        public byte[] Imagem { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de criação")]
        public DateTime DataCriacao { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de inactivação")]
        public DateTime DataInactivo { get; set; }

        //public int DistritosId { get; set; }

        //[Display(Name = "Distrito")]
        //public Distritos Distritos { get; set; }

        [InverseProperty("Pacote")]
        public virtual ICollection<DistritosPacotes> DistritosPacotes { get; set; }
    }

}
