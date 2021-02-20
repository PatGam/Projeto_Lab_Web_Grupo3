using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class Tipos_Sevicos
    {
        [Key]
        [Column("Tipo_Servico_Id")]
        public int TipoServicoId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Tipo Serviço")]
        [Remote("IsTypeServiceNameExist", "Tipos_Sevicos", AdditionalFields = "TipoServicoId",
                ErrorMessage = "Tipo de Serviço já existe")]
        public string Nome { get; set; }

        public ICollection<Servicos> Servicos { get; set; }

    }
}
