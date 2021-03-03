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
            List<Pacotes> pacotes = await bd.Pacotes
              .ToListAsync();

            List<ServicosPacotes> servicospacotes = await bd.ServicosPacotes
            .ToListAsync();

            List<Servicos> servicos = await bd.Servicos
            .ToListAsync();

          
            List<PromocoesPacotes> promocoespacotes = await bd.PromocoesPacotes
            .ToListAsync();

            List<Promocoes> promocoes = await bd.Promocoes
            .ToListAsync();

            HomeGestaoViewModel modelo = new HomeGestaoViewModel
            {
                Pacotes = pacotes,
                ServicosPacotes = servicospacotes,
                PromocoesPacotes = promocoespacotes,
                Servicos = servicos,
                Promocoes = promocoes,
                

        };

            return base.View(modelo);
        }

   



    }
}
