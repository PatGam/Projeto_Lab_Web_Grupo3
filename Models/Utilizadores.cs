﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Projeto_Lab_Web_Grupo3.Models
{
    public partial class Utilizadores
    {
        public Utilizadores()
        {
            Contratos = new HashSet<Contratos>();
        }

        [Key]
        [Column("Utilizador_Id")]
        public int UtilizadorId { get; set; }

        [Required(ErrorMessage = "Preencha o nome do utilizador")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres")]
        [Display(Name = "Nome do utilizador")]
        public string Nome { get; set; }


        [Display(Name = "NIF")]
        [Column("NIF")]
        [StringLength(9, MinimumLength = 9)]
        public string Nif { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [Column("Data_Nascimento", TypeName = "date")]
        [Display(Name = "Data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Preencha a morada")]
        [StringLength(500, ErrorMessage = "A morada não pode ter mais de 500 caracteres")]
        [Display(Name = "Morada")]
        public string Morada { get; set; }

        [Display(Name = "Contacto de telemóvel")]
        [RegularExpression(@"(9[1236]|\d{2})\d{7}", ErrorMessage = "Telefone Inválido")]
        public string Telemovel { get; set; }

        [Required(ErrorMessage = "Preencha o email")]
        [StringLength(100, ErrorMessage = "O email não pode ter mais de 100 caracteres")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o código postal")]
        [Column("Codigo_Postal")]
        [RegularExpression(@"(\d{4})[-](\d{3})", ErrorMessage = "Código Postal Inválido")]
        [StringLength(8, MinimumLength = 8)]
        [Display(Name = "Código Postal")]
        public string CodigoPostal { get; set; }

        [Required(ErrorMessage = "Especifique o role do utilizador")]
        [StringLength(20)]
        [Display(Name = "Role")]

        public string Role { get; set; }

        //[InverseProperty("Funcionario")]
        public virtual ICollection<Contratos> Contratos { get; set; }

        [Display(Name = "Inactivo")]
        public bool Inactivo { get; set; }
    }
}

        //[Display(Name = "Tipo de Cliente")]

        //public int TipoClienteId { get; set; }
        //public Tipos_Clientes TiposClientes { get; set; }