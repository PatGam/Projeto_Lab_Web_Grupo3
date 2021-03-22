using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class Top10ViewModel

    {
        public List<Contratos> Contratos { get; set; }
        public List<Utilizadores> Utilizadores { get; set; }

        public List<LucroClienteOperador> operadoresAveiro { get; set; }

        public List<LucroClienteOperador> operadoresBeja { get; set; }

        public List<LucroClienteOperador> operadoresBraga { get; set; }

        public List<LucroClienteOperador> operadoresBraganca { get; set; }

        public List<LucroClienteOperador> operadoresCasteloBranco { get; set; }

        public List<LucroClienteOperador> operadoresCoimbra { get; set; }

        public List<LucroClienteOperador> operadoresEvora { get; set; }

        public List<LucroClienteOperador> operadoresFaro { get; set; }

        public List<LucroClienteOperador> operadoresGuarda { get; set; }

        public List<LucroClienteOperador> operadoresLeiria { get; set; }

        public List<LucroClienteOperador> operadoresLisboa { get; set; }

        public List<LucroClienteOperador> operadoresPortalegre { get; set; }

        public List<LucroClienteOperador> operadoresPorto { get; set; }

        public List<LucroClienteOperador> operadoresSantarem { get; set; }

        public List<LucroClienteOperador> operadoresSetubal { get; set; }

        public List<LucroClienteOperador> operadoresVianadoCastelo { get; set; }

        public List<LucroClienteOperador> operadoresVilaReal { get; set; }

        public List<LucroClienteOperador> operadoresViseu { get; set; }

        public List<LucroClienteOperador> operadoresAcores { get; set; }

        public List<LucroClienteOperador> operadoresMadeira { get; set; }

        public int UtilizadorId { get; set; }        

        public LucroClienteOperador LucroClienteOperador { get; set; }

    }
}
