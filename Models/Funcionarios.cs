using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Projeto_Lab_Web_Grupo3.Models
{
    public partial class Funcionarios
    {
        public Funcionarios()
        {
            Contratos = new HashSet<Contratos>();
        }

        [Key]
        [Column("Funcionario_Id")]
        public int FuncionarioId { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; }
        [Column("Data_Nascimento", TypeName = "date")]
        public DateTime DataNascimento { get; set; }
        [Required]
        [StringLength(500)]
        public string Morada { get; set; }
        public int Telemovel { get; set; }
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [Column("Codigo_Postal")]
        [StringLength(8)]
        public string CodigoPostal { get; set; }
        [Required]
        [StringLength(20)]
        public string Role { get; set; }

        [InverseProperty("Funcionario")]
        public virtual ICollection<Contratos> Contratos { get; set; }
    }
}
