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
        public string NifPesquisar { get; set; }
        public List<Promocoes> Promocoes { get; set; }
        public List<Pacotes> Pacotes { get; set; }
        public int UtilizadorId { get; set; }

        public int FuncionarioId { get; set; }

        public Utilizadores Utilizadores { get; set; }





    }
}
