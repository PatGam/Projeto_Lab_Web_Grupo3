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
        private readonly Projeto_Lab_WebContext _context;

        public PromocoesPacotesController(Projeto_Lab_WebContext context)
        {
            _context = context;
        }

        // GET: PromocoesPacotes
        public async Task<IActionResult> Index()
        {
            var projeto_Lab_WebContext = _context.PromocoesPacotes.Include(p => p.Pacote).Include(p => p.Promocoes);
            return View(await projeto_Lab_WebContext.ToListAsync());
        }

        // GET: PromocoesPacotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocoesPacotes = await _context.PromocoesPacotes
                .Include(p => p.Pacote)
                .Include(p => p.Promocoes)
                .FirstOrDefaultAsync(m => m.PromocoesPacotesId == id);
            if (promocoesPacotes == null)
            {
                return NotFound();
            }

            return View(promocoesPacotes);
        }

        // GET: PromocoesPacotes/Create
        public IActionResult Create()
        {
            ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "Nome");
            ViewData["PromocoesId"] = new SelectList(_context.Promocoes, "PromocoesId", "Nome");
            return View();
        }

        // POST: PromocoesPacotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PacoteId,PromocoesId,PromocoesPacotesId,NomePacote,NomePromocoes")] PromocoesPacotes promocoesPacotes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promocoesPacotes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "Nome", promocoesPacotes.PacoteId);
            ViewData["PromocoesId"] = new SelectList(_context.Promocoes, "PromocoesId", "Nome", promocoesPacotes.PromocoesId);
            return View(promocoesPacotes);
        }

        // GET: PromocoesPacotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocoesPacotes = await _context.PromocoesPacotes.FindAsync(id);
            if (promocoesPacotes == null)
            {
                return NotFound();
            }
            ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "Nome", promocoesPacotes.PacoteId);
            ViewData["PromocoesId"] = new SelectList(_context.Promocoes, "PromocoesId", "Nome", promocoesPacotes.PromocoesId);
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
                    _context.Update(promocoesPacotes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromocoesPacotesExists(promocoesPacotes.PromocoesPacotesId))
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
            ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "Nome", promocoesPacotes.PacoteId);
            ViewData["PromocoesId"] = new SelectList(_context.Promocoes, "PromocoesId", "Nome", promocoesPacotes.PromocoesId);
            return View(promocoesPacotes);
        }

        // GET: PromocoesPacotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocoesPacotes = await _context.PromocoesPacotes
                .Include(p => p.Pacote)
                .Include(p => p.Promocoes)
                .FirstOrDefaultAsync(m => m.PromocoesPacotesId == id);
            if (promocoesPacotes == null)
            {
                return NotFound();
            }

            return View(promocoesPacotes);
        }

        // POST: PromocoesPacotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promocoesPacotes = await _context.PromocoesPacotes.FindAsync(id);
            _context.PromocoesPacotes.Remove(promocoesPacotes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromocoesPacotesExists(int id)
        {
            return _context.PromocoesPacotes.Any(e => e.PromocoesPacotesId == id);
        }
    }
}
