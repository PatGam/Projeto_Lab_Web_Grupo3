﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Projeto_Lab_Web_Grupo3.Models
{
    public partial class Pacotes
    {
        public Pacotes()
        {
            PromocoesPacotes = new HashSet<PromocoesPacotes>();
            ServicosPacotes = new HashSet<ServicosPacotes>();
        }

        [Key]
        [Column("Pacote_Id")]
        public int PacoteId { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [StringLength(1000)]
        public string Descricao { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Preco { get; set; }

        [InverseProperty("Pacote")]
        public virtual ICollection<PromocoesPacotes> PromocoesPacotes { get; set; }
        [InverseProperty("Pacote")]
        public virtual ICollection<ServicosPacotes> ServicosPacotes { get; set; }
    }
}