using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Projeto_Lab_Web_Grupo3.Models
{
    public partial class Clientes
    {
        public Clientes()
        {
            Contratos = new HashSet<Contratos>();
        }

        [Key]
        [Column("Cliente_Id")]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Column("Data_Nascimento", TypeName = "date")]
        public DateTime DataNascimento { get; set; }

        [Column("NIF")]
        [StringLength(9, MinimumLength = 9)]
        public string Nif { get; set; }

        [Required]
        [StringLength(200)]
        public string Morada { get; set; }

        [RegularExpression(@"(9[1236]|2\d)\d{7}", ErrorMessage = "Telefone Inválido")]
        [StringLength(9, MinimumLength = 9)]
        public string Telemovel { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Column("Codigo_Postal")]
        [StringLength(8, MinimumLength = 8)]
        public string CodigoPostal { get; set; }

        [InverseProperty("Cliente")]
        public virtual ICollection<Contratos> Contratos { get; set; }

        [Display(Name = "Tipo de Cliente")]


        public int TipoClienteId { get; set; }
        public Tipos_Clientes TiposClientes { get; set; }
    }
}
