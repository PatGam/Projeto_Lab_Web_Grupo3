using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Lab_Web_Grupo3.Data;
using Projeto_Lab_Web_Grupo3.Models;

namespace Projeto_Lab_Web_Grupo3.Controllers
{
    public class PromocoesPacotesController : Controller
    {
        private readonly Projeto_Lab_WebContext bd;

        public PromocoesPacotesController(Projeto_Lab_WebContext context)
        {
            bd = context;
        }

        // GET: PromocoesPacotes
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await bd.PromocoesPacotes.Where(p => nomePesquisar == null || p.Pacote.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };
            List<PromocoesPacotes> promocoesPacotes = await bd.PromocoesPacotes.Where(p => nomePesquisar == null || p.Pacote.Nome.Contains(nomePesquisar))
              .OrderBy(p => p.Pacote.Nome)
              .Skip(paginacao.ItemsPorPagina * (pagina - 1))
              .Take(paginacao.ItemsPorPagina)
              .ToListAsync();
            PromocoesPacotesViewModel modelo = new PromocoesPacotesViewModel
            {
                Paginacao = paginacao,
                PromocoesPacotes=promocoesPacotes,
                NomePesquisar = nomePesquisar
            };
            return base.View(modelo);
        }

        // GET: PromocoesPacotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocoesPacotes = await bd.PromocoesPacotes
                .Include(p => p.Pacote)
                .Include(p => p.Promocoes)
                .FirstOrDefaultAsync(m => m.PromocoesPacotesId == id);
            if (promocoesPacotes == null)
            {
                return View ("Inexistente");
            }

            return View(promocoesPacotes);
        }

        // GET: PromocoesPacotes/Create
        public IActionResult Create(int promocoesId)
        {

            var promocao = bd.Promocoes.SingleOrDefault(e => e.PromocoesId == promocoesId);
           
            ViewData["PacoteId"] = new SelectList(bd.Pacotes, "PacoteId", "Nome");
            ViewData["PromocoesId"] = promocoesId;
            ViewData["PromocoesNome"] = promocao.Nome;

            return View();
        }

        // POST: PromocoesPacotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PacoteId,PromocoesId,PromocoesPacotesId,NomePacote,NomePromocoes")] PromocoesPacotes promocoesPacotes)
        {
            if (!ModelState.IsValid)
            {
                return View(promocoesPacotes);
                
            }
            ViewData["PacoteId"] = new SelectList(bd.Pacotes, "PacoteId", "Nome", promocoesPacotes.PacoteId);
            ViewData["PromocoesId"] = new SelectList(bd.Promocoes, "PromocoesId", "Nome", promocoesPacotes.PromocoesId);
            bd.Add(promocoesPacotes);
            await bd.SaveChangesAsync();
            ViewBag.Mensagem = "Dados adicionados com sucesso.";
            return View("Sucesso");
        }

        // GET: PromocoesPacotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocoesPacotes = await bd.PromocoesPacotes.FindAsync(id);
            if (promocoesPacotes == null)
            {
                return View("Inexistente");
            }
            ViewData["PacoteId"] = new SelectList(bd.Pacotes, "PacoteId", "Nome", promocoesPacotes.PacoteId);
            ViewData["PromocoesId"] = new SelectList(bd.Promocoes, "PromocoesId", "Nome", promocoesPacotes.PromocoesId);
            return View(promocoesPacotes);
        }

        // POST: PromocoesPacotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PacoteId,PromocoesId,PromocoesPacotesId,NomePacote,NomePromocoes")] PromocoesPacotes promocoesPacotes)
        {
            if (id != promocoesPacotes.PromocoesPacotesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bd.Update(promocoesPacotes);
                    await bd.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromocoesPacotesExists(promocoesPacotes.PromocoesPacotesId))
                    {
                        return View("EliminarInserir");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacoteId"] = new SelectList(bd.Pacotes, "PacoteId", "Nome", promocoesPacotes.PacoteId);
            ViewData["PromocoesId"] = new SelectList(bd.Promocoes, "PromocoesId", "Nome", promocoesPacotes.PromocoesId);
            ViewBag.Mensagem = "Dados alterados com sucesso";
            return View("Sucesso");
        }

        // GET: PromocoesPacotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocoesPacotes = await bd.PromocoesPacotes
                .Include(p => p.Pacote)
                .Include(p => p.Promocoes)
                .FirstOrDefaultAsync(m => m.PromocoesPacotesId == id);
            if (promocoesPacotes == null)
            {
                ViewBag.Mensagem = "Os dados que estava a tentar apagar foram eliminados por outra pessoa.";
                return View("Sucesso");
            }

            return View(promocoesPacotes);
        }

        // POST: PromocoesPacotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promocoesPacotes = await bd.PromocoesPacotes.FindAsync(id);
            bd.PromocoesPacotes.Remove(promocoesPacotes);
            await bd.SaveChangesAsync();
            ViewBag.Mensagem = "Os dados foram eliminados com sucesso";
            return View("Sucesso");
        }

        private bool PromocoesPacotesExists(int id)
        {
            return bd.PromocoesPacotes.Any(e => e.PromocoesPacotesId == id);
        }
    }
}
