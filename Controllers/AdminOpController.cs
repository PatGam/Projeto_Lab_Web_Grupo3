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

                foreach(var item in infoPacote.Servicos)
                {
                    infoPacote.TiposServicos = await bd.Servicos
                    .Include(p => p.TipoServicos)
                    .Where(p => p.ServicoId == item.ServicoId)
                    .Select(p => p.TipoServicos)
                    .ToListAsync();
                }
                

                ListaPacotes.Add(infoPacote);
            }

            var Funcionarios = bd.Utilizadores.Where(p => p.Role != "Cliente").ToList();
            int contagemFunc = Funcionarios.Count();

            var Clientes = bd.Utilizadores.Where(p => p.Role == "Cliente").ToList();
            int contagemClientes = Clientes.Count();

            var Contratos = bd.Contratos.ToList();
            int contagemContratos = Contratos.Count();

            decimal receita = 0;
            foreach (var item in Contratos)
            {
                receita += item.PrecoFinal;
            }


            if (User.IsInRole("Operador"))
            {
                var funcionario = bd.Utilizadores.SingleOrDefault(c => c.Email == User.Identity.Name);


                List<Contratos> MeusContratos = await bd.Contratos
                    .Where(p => p.FuncionarioId == funcionario.UtilizadorId)
                    .ToListAsync();
                int contagemMeusContratos = MeusContratos.Count();


                decimal faturacao = 0;
                foreach (var item in MeusContratos)
                {

                    faturacao += item.PrecoFinal;

                }
                ViewData["faturacao"] = faturacao;
                ViewData["Meuscontratos"] = contagemMeusContratos;
            }


                HomeGestaoViewModel modelo = new HomeGestaoViewModel
            {
                Pacotes = ListaPacotes,
            };
            
            ViewData["clientes"] = contagemClientes;
            ViewData["contratos"] = contagemContratos;
            ViewData["receita"] = receita;
            ViewData["func"] = contagemFunc;
            


            return View(modelo);
        }





    }
}
