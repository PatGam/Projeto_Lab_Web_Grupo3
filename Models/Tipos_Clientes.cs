using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class Tipos_Clientes
    {
        [Key]
        [Column("Tipos_CLientes_Id")]
        public int TipoClienteId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Tipo de cliente")]
        [Remote("IsTypeClientNameExist", "Tipos_Clientes", AdditionalFields = "TipoClienteId",
                ErrorMessage = "Tipo de Cliente já existe")]
        public string Nome { get; set; }


    }
}
