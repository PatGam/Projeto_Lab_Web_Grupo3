using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class Distritos
    {
        [Key]
        public int DistritosId { get; set; }

        [Required]
        public string Nome { get; set; }

        public virtual ICollection<Promocoes> Promocoes { get; set; }
        public virtual ICollection<Pacotes> Pacotes { get; set; }
        public virtual ICollection<Utilizadores> Utilizadores { get; set; }
        public virtual ICollection<Contratos> Contratos { get; set; }
    }
}
