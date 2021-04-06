using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class EnvioDeFaturas
    {
        [Key]
        public int EnvioDeFaturasId { get; set; }

        public DateTime DataDeEnvio { get; set; }

        public bool Enviado { get; set; }

        public string Texto { get; set; }

    }
}
