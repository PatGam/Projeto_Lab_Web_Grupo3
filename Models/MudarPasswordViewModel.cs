using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class MudarPasswordViewModel
    {
        [Required]
        [StringLength(256)]
        [DataType(DataType.Password)]
        [Display(Name = "Password atual")]
        public string Password { get; set; }

        [Required]
        [StringLength(256)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Password")]
        public string NovaPassword { get; set; }

       
        [StringLength(256)]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar nova Password")]
        [Compare("Nova Password", ErrorMessage = "A nova Password e a confirmação não são iguais")]
        public string ConfirmarPassword { get; set; }

    }
}
