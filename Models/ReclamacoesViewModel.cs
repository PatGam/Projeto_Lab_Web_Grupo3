using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class ReclamacoesViewModel
    {
        public List <Reclamacoes> Reclamacoes { get; set; }
        public Paginacao Paginacao { get; set; }

        public string Descricao { get; set; }

        public DateTime DataReclamacao { get; set; }

        public string Resposta { get; set; }

        public DateTime DataResposta { get; set; }

        public bool EstadoResposta { get; set; }

        public bool EstadoResolução { get; set; }

        public DateTime DataResolucao { get; set; }

        public int ClienteId { get; set; }

        public int FuncionarioId { get; set; }

        public bool Inactivo { get; set; }

    }
}
