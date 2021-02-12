﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Projeto_Lab_Web_Grupo3.Models
{
    public partial class RegistoFuncionariosViewModel
    {
     
        [Required(ErrorMessage = "Preencha o nome do funcionário")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres")]
        [Display(Name = "Nome do funcionário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha a data de nascimento do funcionário")]
        [Column("Data_Nascimento", TypeName = "date")]
        [Display(Name = "Data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Preencha a morada do funcionário")]
        [StringLength(500, ErrorMessage = "A morada não pode ter mais de 500 caracteres")]
        [Display(Name = "Morada")]
        public string Morada { get; set; }

        [Required(ErrorMessage = "Preencha o contacto do funcionário")]
        [Display(Name = "Contacto de telemóvel")]
        public int Telemovel { get; set; }

        [Required(ErrorMessage = "Preencha o email do funcionário")]
        [StringLength(100, ErrorMessage = "O email não pode ter mais de 100 caracteres")]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o código postal do funcionário")]
        [Column("Codigo_Postal")]
        [RegularExpression(@"(\d{8}(-\d{4})?", ErrorMessage = "Código Postal Inválido")]
        [StringLength(8, MinimumLength = 8)]
        [Display(Name = "Código Postal")]
        public string CodigoPostal { get; set; }

        [Required(ErrorMessage = "Especifique o cargo do funcionário")]
        [StringLength(20)]
        [Display(Name = "Cargo")]
        public string Role { get; set; }

        [Required]
        [StringLength(256)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(256)]
        [Compare("Password", ErrorMessage = "Palavra-passe não coincidente")]
        [Display(Name = "Confirme a password")]
        [DataType(DataType.Password)]
        public string ConfirmePassword { get; set; }
    }
}
