using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class ServicosContratos
    {
        [Key]
        public int ServicosContratosId { get; set; }

        public int ContratoId { get; set; }

        public int ServicoId { get; set; }

        public virtual Contratos Contratos { get; set; }

        public virtual Servicos Servicos { get; set; }






    }
}
