using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class RegistoClienteViewModel
    {

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
        public string Telemovel { get; set; }


        [Required(ErrorMessage = "Preencha o email do cliente")]
        [StringLength(100, ErrorMessage = "O email não pode ter mais de 100 caracteres")]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }


        [Required]
        [Column("Codigo_Postal")]
        [StringLength(8, MinimumLength = 8)]

        public string CodigoPostal { get; set; }

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
