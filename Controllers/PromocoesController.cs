using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Lab_Web_Grupo3.Data;
using Projeto_Lab_Web_Grupo3.Models;

namespace Projeto_Lab_Web_Grupo3.Controllers
{
    public class PromocoesController : Controller
    {
        private readonly Projeto_Lab_WebContext bd;

        public PromocoesController(Projeto_Lab_WebContext context)
        {
            bd = context;
        }

        // GET: Promocoes
        [Authorize(Roles = "Administrador,Operador")]
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await bd.Promocoes.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };
            List<Promocoes> promocoes = await bd.Promocoes.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar))
              .OrderBy(p => p.Nome)
              .Skip(paginacao.ItemsPorPagina * (pagina - 1))
              .Take(paginacao.ItemsPorPagina)
              .ToListAsync();
            PromocoesViewModel modelo = new PromocoesViewModel
            {
                Paginacao = paginacao,
                Promocoes=promocoes,
                NomePesquisar = nomePesquisar
            };
            return base.View(modelo);
        }
        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> VistaCliente()
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

                foreach (var item in infoPacote.Servicos)
                {
                    infoPacote.TiposServicos = await bd.Servicos
                    .Include(p => p.TipoServicos)
                    .Where(p => p.ServicoId == item.ServicoId)
                    .Select(p => p.TipoServicos)
                    .ToListAsync();
                }

                if(infoPacote.Promocao != null)
                {
                    ListaPacotes.Add(infoPacote);

                }
            }

            HomeGestaoViewModel modelo = new HomeGestaoViewModel
            {
                Pacotes = ListaPacotes,
            };

            return View(modelo);
        
        }

        // GET: Promocoes/Details/5
        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocoes = await bd.Promocoes
                .FirstOrDefaultAsync(m => m.PromocoesId == id);
            var pacotes = await bd.PromocoesPacotes.Where(s => s.PromocoesId == id)
               .Include(s => s.Pacote)
               .ToListAsync();

            int count = 0;
            foreach (var item in bd.PromocoesPacotes.ToList())
            {
                //SystemsCount 
                count = bd.PromocoesPacotes.Where(x => x.PromocoesId == id).Count();
            }

            ViewData["linhas"] = count;

            if (promocoes == null)
            {
                return View ("Inexistente");
            }

            PromocoesPacotesViewModel modelo = new PromocoesPacotesViewModel
            {
                 Promocoes = promocoes,
                 PromocoesPacotes = pacotes, 

            };
            return base.View(modelo);
        }

        // GET: Promocoes/Create
        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {
            var pacotes = bd.Pacotes.ToList();

            PromocoesPacotesViewModel promocoesPacotesViewModel = new PromocoesPacotesViewModel();
            promocoesPacotesViewModel.ListaPacotes = pacotes.Select(s => new Checkbox()
            {
                Id = s.PacoteId,
                NomePacote = s.Nome,
                Selecionado = false
            }).ToList();

            return View(promocoesPacotesViewModel);
        }

        // POST: Promocoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create(PromocoesPacotesViewModel promocoesPacotesViewModel, PromocoesPacotes promocoesPacotes, Promocoes promocoes)
        {

            if (!ModelState.IsValid)
            {
                var pacotes = bd.Pacotes.ToList();

                promocoesPacotesViewModel.ListaPacotes = pacotes.Select(s => new Checkbox()
                {
                    Id = s.PacoteId,
                    NomePacote = s.Nome,
                    Selecionado = false
                }).ToList();

                return View(promocoesPacotesViewModel);
            }

            List<PromocoesPacotes> promocoesDosPacotes = new List<PromocoesPacotes>();

            promocoes.Nome = promocoesPacotesViewModel.Nome;
            promocoes.Descricao = promocoesPacotesViewModel.Descricao;
            promocoes.DataInicio = promocoesPacotesViewModel.DataInicio;
            promocoes.DataFim = promocoesPacotesViewModel.DataFim;
            promocoes.PromocaoDesc = promocoesPacotesViewModel.PromocaoDesc;
            promocoes.Inactivo = false;

            bd.Promocoes.Add(promocoes);
            await bd.SaveChangesAsync();
            int promocaoId = promocoes.PromocoesId;

            foreach (var item in promocoesPacotesViewModel.ListaPacotes)
            {
                if (item.Selecionado == true)
                {
                    promocoesDosPacotes.Add(new PromocoesPacotes() { PromocoesId = promocaoId, PacoteId = item.Id });
                }
            }
            foreach (var item in promocoesDosPacotes)
            {
                bd.PromocoesPacotes.Add(item);
            }
            await bd.SaveChangesAsync();


            ViewBag.Mensagem = "Promoção adicionado com sucesso.";
            return View("Sucesso");

        }

        // GET: Promocoes/Edit/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int? id)
        {
            PromocoesPacotesViewModel promocoesPacotesViewModel = new PromocoesPacotesViewModel();

            var promocao = await bd.Promocoes.Include(p => p.PromocoesPacotes)
                .ThenInclude(c => c.Pacote)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.PromocoesId == id);

            var listaPacotes = bd.Pacotes.Select(s => new Checkbox()
            {
                Id = s.PacoteId,
                NomePacote = s.Nome,
                Selecionado = s.PromocoesPacotes.Any(s => s.PromocoesId == promocao.PromocoesId) ? true : false

            }).ToList();

            promocoesPacotesViewModel.Nome = promocao.Nome;
            promocoesPacotesViewModel.Descricao = promocao.Descricao;
            promocoesPacotesViewModel.DataInicio = promocao.DataInicio;
            promocoesPacotesViewModel.DataFim = promocao.DataFim;
            promocoesPacotesViewModel.PromocaoDesc = promocao.PromocaoDesc;
            promocoesPacotesViewModel.ListaPacotes = listaPacotes;
            promocoesPacotesViewModel.PromocoesId = (int)id;

            return View(promocoesPacotesViewModel);
        }

        // POST: Promocoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit( PromocoesPacotesViewModel promocoesPacotesViewModel)
        {
            List<PromocoesPacotes> promocoesDosPacotes = new List<PromocoesPacotes>();
            int id = promocoesPacotesViewModel.PromocoesId;
            Promocoes promocao = await bd.Promocoes.Include(p => p.PromocoesPacotes)
                .ThenInclude(c => c.Pacote)
                //.AsNoTracking()
                .SingleOrDefaultAsync(p => p.PromocoesId == id);

            promocao.Nome = promocoesPacotesViewModel.Nome;
            promocao.Descricao = promocoesPacotesViewModel.Descricao;
            promocao.DataInicio = promocoesPacotesViewModel.DataInicio;
            promocao.DataFim = promocoesPacotesViewModel.DataFim;
            promocao.PromocaoDesc = promocoesPacotesViewModel.PromocaoDesc;

            bd.Promocoes.Update(promocao);
            await bd.SaveChangesAsync();

            int promocaoId = promocao.PromocoesId;

            foreach (var pacote in promocoesPacotesViewModel.ListaPacotes)
            {
                if (pacote.Selecionado == true)
                {
                    promocoesDosPacotes.Add(new PromocoesPacotes() { PromocoesId = promocaoId, PacoteId = pacote.Id });
                }
            }

            var ListaPromocoesPacotes = bd.PromocoesPacotes.Where(p => p.PromocoesId == id).ToList();
            var resultado = ListaPromocoesPacotes.Except(promocoesDosPacotes).ToList();

            foreach (var promocaoPacote in resultado)
            {
                bd.PromocoesPacotes.Remove(promocaoPacote);
                await bd.SaveChangesAsync();
            }

            var novaListaPromocoesPacotes = bd.PromocoesPacotes.Where(p => p.PromocoesId == id).ToList();
            foreach (var pacote in promocoesDosPacotes)
            {
                if (!novaListaPromocoesPacotes.Contains(pacote))
                {
                    bd.PromocoesPacotes.Add(pacote);
                    await bd.SaveChangesAsync();
                }
            }


            ViewBag.Mensagem = "Promoção alterada com sucesso";
            return View("Sucesso");
        }

        // GET: Promocoes/Delete/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocoes = await bd.Promocoes
                .FirstOrDefaultAsync(m => m.PromocoesId == id);
            if (promocoes == null)
            {
                ViewBag.Mensagem = "A Promoção que estava a tentar apagar foi eliminada por outra pessoa.";
                return View("Sucesso");
            }

            return View(promocoes);
        }

        // POST: Promocoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promocoes = await bd.Promocoes.FindAsync(id);
            promocoes.Inactivo = true;
            bd.Update(promocoes);
            await bd.SaveChangesAsync();
            ViewBag.Mensagem = "A Promoção foi eliminada com sucesso";
            return View("Sucesso");
        }

        private bool PromocoesExists(int id)
        {
            return bd.Promocoes.Any(e => e.PromocoesId == id);
        }

        #region API Calls
        [HttpGet]
        [Authorize(Roles = "Administrador, Operador")]
        public async Task<IActionResult> GetAll()
        {
            var promocoes = await bd.Promocoes
                .Select(s => new { s.PromocoesId, s.Nome, s.DataInicio, s.DataFim, s.PromocaoDesc, s.Inactivo })
                .Where(i => i.Inactivo == false && i.DataInicio < DateTime.Now && i.DataFim > DateTime.Now)
                .ToListAsync();
            return Json(new { data = promocoes });
        }

        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int id)
        {
            var promocaoFromDb = await bd.Promocoes.FirstOrDefaultAsync(s => s.PromocoesId == id);
            if (promocaoFromDb == null)
            {
                return Json(new { success = false, message = "Erro ao eliminar a promoção" });
            }
            bd.Promocoes.Remove(promocaoFromDb);
            await bd.SaveChangesAsync();
            return Json(new { success = true, message = "A Promoção foi eliminado com sucesso" });
        }
        #endregion

        // GET: Promocoes/Edit/5
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> EditOperadores(int? id)
        {
            PromocoesPacotesViewModel promocoesPacotesViewModel = new PromocoesPacotesViewModel();

            var promocao = await bd.Promocoes.Include(p => p.PromocoesPacotes)
                .ThenInclude(c => c.Pacote)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.PromocoesId == id);

            var listaPacotes = bd.Pacotes.Select(s => new Checkbox()
            {
                Id = s.PacoteId,
                NomePacote = s.Nome,
                Selecionado = s.PromocoesPacotes.Any(s => s.PromocoesId == promocao.PromocoesId) ? true : false

            }).ToList();

            promocoesPacotesViewModel.Nome = promocao.Nome;
            promocoesPacotesViewModel.Descricao = promocao.Descricao;
            promocoesPacotesViewModel.DataInicio = promocao.DataInicio;
            promocoesPacotesViewModel.DataFim = promocao.DataFim;
            promocoesPacotesViewModel.PromocaoDesc = promocao.PromocaoDesc;
            promocoesPacotesViewModel.ListaPacotes = listaPacotes;
            promocoesPacotesViewModel.PromocoesId = (int)id;

            return View(promocoesPacotesViewModel);
        }

        // POST: Promocoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOperadores(PromocoesPacotesViewModel promocoesPacotesViewModel)
        {
            List<PromocoesPacotes> promocoesDosPacotes = new List<PromocoesPacotes>();
            int id = promocoesPacotesViewModel.PromocoesId;
            Promocoes promocao = await bd.Promocoes.Include(p => p.PromocoesPacotes)
                .ThenInclude(c => c.Pacote)
                //.AsNoTracking()
                .SingleOrDefaultAsync(p => p.PromocoesId == id);

            
            int promocaoId = promocao.PromocoesId;

            foreach (var pacote in promocoesPacotesViewModel.ListaPacotes)
            {
                if (pacote.Selecionado == true)
                {
                    promocoesDosPacotes.Add(new PromocoesPacotes() { PromocoesId = promocaoId, PacoteId = pacote.Id });
                }
            }

            var ListaPromocoesPacotes = bd.PromocoesPacotes.Where(p => p.PromocoesId == id).ToList();
            var resultado = ListaPromocoesPacotes.Except(promocoesDosPacotes).ToList();

            foreach (var promocaoPacote in resultado)
            {
                bd.PromocoesPacotes.Remove(promocaoPacote);
                await bd.SaveChangesAsync();
            }

            var novaListaPromocoesPacotes = bd.PromocoesPacotes.Where(p => p.PromocoesId == id).ToList();
            foreach (var pacote in promocoesDosPacotes)
            {
                if (!novaListaPromocoesPacotes.Contains(pacote))
                {
                    bd.PromocoesPacotes.Add(pacote);
                    await bd.SaveChangesAsync();
                }
            }


            ViewBag.Mensagem = "Promoção alterada com sucesso";
            return View("Sucesso");
        }
    }
}
