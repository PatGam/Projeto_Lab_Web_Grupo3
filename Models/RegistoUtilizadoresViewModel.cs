﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace Projeto_Lab_Web_Grupo3.Models
{
    public partial class RegistoUtilizadoresViewModel
    {
     
        [Required(ErrorMessage = "Preencha o nome do utilizador")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres")]
        [Display(Name = "Nome do utilizador")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha a data de nascimento do utilizador")]
        [Column("Data_Nascimento", TypeName = "date")]
        [Display(Name = "Data de nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Preencha a morada do utilizador")]
        [StringLength(500, ErrorMessage = "A morada não pode ter mais de 500 caracteres")]
        [Display(Name = "Morada")]
        public string Morada { get; set; }

        [Required(ErrorMessage = "Preencha o contacto do utilizador")]
        [Display(Name = "Contacto de telemóvel")]
        public string Telemovel { get; set; }

        [Required(ErrorMessage = "Preencha o email do utilizador")]
        [StringLength(100, ErrorMessage = "O email não pode ter mais de 100 caracteres")]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "NIF")]
        [Column("NIF")]
        [StringLength(9, MinimumLength = 9)]
        public string Nif { get; set; }

        //[RegularExpression(@"(\d{8}(-\d{4})?", ErrorMessage = "Código Postal Inválido")]
        [Required(ErrorMessage = "Preencha o código postal do utilizador")]
        [Column("Codigo_Postal")]
        [StringLength(8, MinimumLength = 8)]
        [Display(Name = "Código Postal")]
        public string CodigoPostal { get; set; }

        [Required(ErrorMessage = "Especifique o role do utilizador")]
        [StringLength(20)]
        [Display(Name = "Role")]
        public string Role { get; set; }


        [Required]
        [StringLength(256)]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&]{6,}$", ErrorMessage = "A Password deve conter: Minímo 8 caracteres;  " +
            "Pelo menos 1 letra maiúscula; " +
            "Pelo menos 1 letra minúscula; " +
            "Pelo menos 1 Número; " +
            "1 caracter especial($ @ ! % ? &);")]
        public string Password { get; set; }

        [Required]
        [StringLength(256)]
        [Compare("Password", ErrorMessage = "Palavra-passe não coincidente")]
        [Display(Name = "Confirme a password")]
        [DataType(DataType.Password)]
        public string ConfirmePassword { get; set; }
    }
}
