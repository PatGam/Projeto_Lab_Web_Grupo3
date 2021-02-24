using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Models
{
    public class Roles
    {
        public int RolesId { get; set; }


        [Display(Name = "Cargo")]
        public string Roles_Nome { get; set; }

        public ICollection<Utilizadores> Funcionarios { get; set; }



    }
}
