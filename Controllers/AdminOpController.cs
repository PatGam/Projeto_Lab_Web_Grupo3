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
            List<InfoPacoteViewModel> ListaPacotes = new List<InfoPacoteViewModel>();

            foreach (var pacote in bd.Pacotes)
            {
                InfoPacoteViewModel infoPacote = new InfoPacoteViewModel();
                infoPacote.Pacote = pacote;

                infoPacote.Promocao = await bd.PromocoesPacotes
                    .Include(p => p.Promocoes)
                    .Where(p => p.PacoteId == pacote.PacoteId)
                    .Select(p => p.Promocoes)
                    .Where(p => p.DataInicio < DateTime.Now && p.DataFim > DateTime.Now)
                    .FirstOrDefaultAsync();

                infoPacote.Servicos = await bd.ServicosPacotes
                    .Include(p => p.Servico)
                    .Where(p => p.PacoteId == pacote.PacoteId)
                    .Select(p => p.Servico)
                    .ToListAsync();

                 
                if (infoPacote.Promocao != null)
                {
                    decimal PrecoPacote = infoPacote.Pacote.Preco;
                    decimal Desc = infoPacote.Promocao.PromocaoDesc;
                    //esta conta não funciona :(
                    decimal PrecoFinal = PrecoPacote - Desc; 
                    ViewData["PrecoFinal"] = PrecoFinal;
                }
                                
                else
                {

                    ViewData["PrecoFinal"] = "";               

                }
         
                ListaPacotes.Add(infoPacote);
            }

            HomeGestaoViewModel modelo = new HomeGestaoViewModel
            {
                Pacotes = ListaPacotes,
                            
                
            };

            return View(modelo);
        }





    }
}
