using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class Distritos
    {
        public Distritos()
        {
            DistritosPacotes = new HashSet<DistritosPacotes>();
        }

        [Key]
        public int DistritosId { get; set; }

        [Required]
        public string Nome { get; set; }

        public virtual ICollection<Promocoes> Promocoes { get; set; }
        public virtual ICollection<Pacotes> Pacotes { get; set; }
        public virtual ICollection<Utilizadores> Utilizadores { get; set; }
        public virtual ICollection<Contratos> Contratos { get; set; }

        [InverseProperty("Distritos")]
        public virtual ICollection<DistritosPacotes> DistritosPacotes { get; set; }

        public virtual ICollection<DistritosPromocoes> DistritosPromocoes { get; set; }


        public virtual ICollection<PacotesNoContrato> PacotesNoContrato { get; set; }

    }
}
