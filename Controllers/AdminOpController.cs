using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Lab_Web_Grupo3.Data;
using Projeto_Lab_Web_Grupo3.Models;
using Microsoft.EntityFrameworkCore;

namespace Projeto_Lab_Web_Grupo3.Controllers
{
    public class AdminOpController : Controller
    {
     
            private readonly Projeto_Lab_WebContext bd;

            public AdminOpController(Projeto_Lab_WebContext context)
            {
                bd = context;
            }

         
            public async Task<IActionResult> Index()
            {
            

                };

            return base.View(modelo);
        }

   



    }
}
