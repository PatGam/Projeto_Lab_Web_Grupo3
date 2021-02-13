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
    public class PromocoesController : Controller
    {
        private readonly Projeto_Lab_WebContext _context;

        public PromocoesController(Projeto_Lab_WebContext context)
        {
            _context = context;
        }

        // GET: Promocoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Promocoes.ToListAsync());
        }

        // GET: Promocoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocoes = await _context.Promocoes
                .FirstOrDefaultAsync(m => m.PromocoesId == id);
            if (promocoes == null)
            {
                return NotFound();
            }

            return View(promocoes);
        }

        // GET: Promocoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Promocoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PromocoesId,Nome,Descricao,DataInicio,DataFim,PromocaoDesc")] Promocoes promocoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promocoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promocoes);
        }

        // GET: Promocoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocoes = await _context.Promocoes.FindAsync(id);
            if (promocoes == null)
            {
                return NotFound();
            }
            return View(promocoes);
        }

        // POST: Promocoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PromocoesId,Nome,Descricao,DataInicio,DataFim,PromocaoDesc")] Promocoes promocoes)
        {
            if (id != promocoes.PromocoesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promocoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromocoesExists(promocoes.PromocoesId))
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
            return View(promocoes);
        }

        // GET: Promocoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocoes = await _context.Promocoes
                .FirstOrDefaultAsync(m => m.PromocoesId == id);
            if (promocoes == null)
            {
                return NotFound();
            }

            return View(promocoes);
        }

        // POST: Promocoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promocoes = await _context.Promocoes.FindAsync(id);
            _context.Promocoes.Remove(promocoes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromocoesExists(int id)
        {
            return _context.Promocoes.Any(e => e.PromocoesId == id);
        }
    }
}
