using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Lab_Web_Grupo3.Data;
using Projeto_Lab_Web_Grupo3.Models;


namespace Projeto_Lab_Web_Grupo3.Controllers
{
    public class Top10Controller : Controller
    {
        private readonly Projeto_Lab_WebContext bd;

        public Top10Controller(Projeto_Lab_WebContext context)
        {
            bd = context;
        }

        public async Task<IActionResult> Index(string nifpesquisar, bool inactivo, int pagina = 1)
        {
          
                List<Utilizadores> clientesAntigos = await bd.Utilizadores
                    .OrderByDescending(p => p.DataAtivacao)
                    .Take(10)
                    .ToListAsync();

            Top10ViewModel top10clientesAntigos = new Top10ViewModel
            {
                   Utilizadores  = clientesAntigos,
                             };
                return View(top10clientesAntigos);
            }
        
    }
}
