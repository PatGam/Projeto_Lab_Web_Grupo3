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
    public class PacotesController : Controller
    {
        private readonly Projeto_Lab_WebContext _context;

        public PacotesController(Projeto_Lab_WebContext context)
        {
            _context = context;
        }

        // GET: Pacotes
        public async Task<IActionResult> Index(string nomePesquisar , int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Pacotes.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };
            List<Pacotes> pacotes = await _context.Pacotes.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar))
              .OrderBy(p => p.Nome)
              .Skip(paginacao.ItemsPorPagina * (pagina - 1))
              .Take(paginacao.ItemsPorPagina)
              .ToListAsync();
            PacotesViewModel modelo = new PacotesViewModel
            {
                Paginacao = paginacao,
                Pacotes = pacotes,
                NomePesquisar = nomePesquisar
            };
            return base.View(modelo);
        }

        // GET: Pacotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacotes = await _context.Pacotes
                .FirstOrDefaultAsync(m => m.PacoteId == id);
            if (pacotes == null)
            {
                return NotFound();
            }

            return View(pacotes);
        }

        // GET: Pacotes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pacotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PacoteId,Nome,Descricao,Preco")] Pacotes pacotes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacotes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pacotes);
        }

        // GET: Pacotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacotes = await _context.Pacotes.FindAsync(id);
            if (pacotes == null)
            {
                return NotFound();
            }
            return View(pacotes);
        }

        // POST: Pacotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PacoteId,Nome,Descricao,Preco")] Pacotes pacotes)
        {
            if (id != pacotes.PacoteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacotes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacotesExists(pacotes.PacoteId))
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
            return View(pacotes);
        }

        // GET: Pacotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacotes = await _context.Pacotes
                .FirstOrDefaultAsync(m => m.PacoteId == id);
            if (pacotes == null)
            {
                return NotFound();
            }

            return View(pacotes);
        }

        // POST: Pacotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacotes = await _context.Pacotes.FindAsync(id);
            _context.Pacotes.Remove(pacotes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacotesExists(int id)
        {
            return _context.Pacotes.Any(e => e.PacoteId == id);
        }
    }
}
