using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class FaturacaoMensalViewModel
    {

        public List<FaturacaoOperadores> faturacaoOperadores { get; set; }

        public Utilizadores funcionario { get; set; }
        
        public Distritos distrito { get; set; }


    }
}
