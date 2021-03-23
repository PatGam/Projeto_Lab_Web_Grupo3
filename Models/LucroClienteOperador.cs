using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class LucroClienteOperador
    {
        public Utilizadores Utilizadores { get; set; }
        public int UtilizadorId { get; set; }
        public List<Contratos> Contratos { get; set; }
        public decimal Lucro { get; set; }
        public int DistritosId { get; set; }
        public string ClienteNome { get; set; }
        public string OperadorNome { get; set; }


    }
}
