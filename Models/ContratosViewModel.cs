using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class ContratosViewModel
    {
        public List<Contratos> Contratos { get; set; }
        public Paginacao Paginacao { get; set; }
        public string NomePesquisar { get; set; }
        public List<Promocoes> Promocoes { get; set; }
        public List<Pacotes> Pacotes { get; set; }




    }
}
