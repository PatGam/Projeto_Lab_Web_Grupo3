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
    public class ServicosPacotesController : Controller
    {
        private readonly Projeto_Lab_WebContext bd;

        public ServicosPacotesController(Projeto_Lab_WebContext context)
        {
            bd = context;
        }

        // GET: ServicosPacotes
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await bd.ServicosPacotes.Where(p => nomePesquisar == null || p.Servico.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };
            List<ServicosPacotes> servicosPacotes = await bd.ServicosPacotes.Where(p => nomePesquisar == null || p.Servico.Nome.Contains(nomePesquisar))
              .OrderBy(p => p.Servico.Nome)
              .Skip(paginacao.ItemsPorPagina * (pagina - 1))
              .Take(paginacao.ItemsPorPagina)
              .ToListAsync();
            ServicosPacotesViewModel modelo = new ServicosPacotesViewModel
            {
                Paginacao = paginacao,
                ServicosPacotes= servicosPacotes,
                NomePesquisar = nomePesquisar
            };
            return base.View(modelo);
        }

        // GET: ServicosPacotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicosPacotes = await bd.ServicosPacotes
                .Include(s => s.Pacote)
                .Include(s => s.Pacote.Nome)
                .Include(s => s.Servico)
                .Include(s => s.Servico.Nome)
                .FirstOrDefaultAsync(m => m.SevicoPacoteId == id);
            if (servicosPacotes == null)
            {
                return NotFound();
            }

            return View(servicosPacotes);
        }

        // GET: ServicosPacotes/Create
        public IActionResult Create()
        {
            ViewData["PacoteId"] = new SelectList(bd.Pacotes, "PacoteId", "Nome");
            ViewData["ServicoId"] = new SelectList(bd.Servicos, "ServicoId", "Nome");
            return View();
        }

        // POST: ServicosPacotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServicoId,PacoteId,SevicoPacoteId")] ServicosPacotes servicosPacotes)
        {
            if (ModelState.IsValid)
            {
                bd.Add(servicosPacotes);
                await bd.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacoteId"] = new SelectList(bd.Pacotes, "PacoteId", "Nome", servicosPacotes.PacoteId);
            ViewData["ServicoId"] = new SelectList(bd.Servicos, "ServicoId", "Nome", servicosPacotes.ServicoId);
            return View(servicosPacotes);
        }

        // GET: ServicosPacotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicosPacotes = await bd.ServicosPacotes.FindAsync(id);
            if (servicosPacotes == null)
            {
                return NotFound();
            }
            ViewData["PacoteId"] = new SelectList(bd.Pacotes, "PacoteId", "Nome", servicosPacotes.PacoteId);
            ViewData["ServicoId"] = new SelectList(bd.Servicos, "ServicoId", "Nome", servicosPacotes.ServicoId);
            return View(servicosPacotes);
        }

        // POST: ServicosPacotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServicoId,PacoteId,SevicoPacoteId")] ServicosPacotes servicosPacotes)
        {
            if (id != servicosPacotes.SevicoPacoteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bd.Update(servicosPacotes);
                    await bd.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicosPacotesExists(servicosPacotes.SevicoPacoteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacoteId"] = new SelectList(bd.Pacotes, "PacoteId", "Nome", servicosPacotes.PacoteId);
            ViewData["ServicoId"] = new SelectList(bd.Servicos, "ServicoId", "Nome", servicosPacotes.ServicoId);
            return View(servicosPacotes);
        }

        // GET: ServicosPacotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicosPacotes = await bd.ServicosPacotes
                .Include(s => s.Pacote)
                .Include(s => s.Servico)
                .FirstOrDefaultAsync(m => m.SevicoPacoteId == id);
            if (servicosPacotes == null)
            {
                return NotFound();
            }

            return View(servicosPacotes);
        }

        // POST: ServicosPacotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicosPacotes = await bd.ServicosPacotes.FindAsync(id);
            bd.ServicosPacotes.Remove(servicosPacotes);
            await bd.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServicosPacotesExists(int id)
        {
            return bd.ServicosPacotes.Any(e => e.SevicoPacoteId == id);
        }
    }
}
