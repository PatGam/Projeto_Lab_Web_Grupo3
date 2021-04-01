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
    public class PacotesNoContratoController : Controller
    {
        private readonly Projeto_Lab_WebContext _context;

        public PacotesNoContratoController(Projeto_Lab_WebContext context)
        {
            _context = context;
        }

        // GET: PacotesNoContrato
        public async Task<IActionResult> Index()
        {
            var projeto_Lab_WebContext = _context.PacotesNoContrato.Include(p => p.Contratos).Include(p => p.Distritos).Include(p => p.Pacotes);
            return View(await projeto_Lab_WebContext.ToListAsync());
        }

        // GET: PacotesNoContrato/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacotesNoContrato = await _context.PacotesNoContrato
                .Include(p => p.Contratos)
                .Include(p => p.Distritos)
                .Include(p => p.Pacotes)
                .FirstOrDefaultAsync(m => m.PacotesNoContratoId == id);
            if (pacotesNoContrato == null)
            {
                return NotFound();
            }

            return View(pacotesNoContrato);
        }

        // GET: PacotesNoContrato/Create
        public IActionResult Create()
        {
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "CodigoPostal");
            ViewData["DistritosId"] = new SelectList(_context.Distritos, "DistritosId", "Nome");
            ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "Nome");
            return View();
        }

        // POST: PacotesNoContrato/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PacotesNoContratoId,ContratoId,PacoteId,DataInicio,DataFim,PrecoPacote,PromocaoDesc,PrecoFinal,Inactivo,Morada,CodigoPostal,DistritosId")] PacotesNoContrato pacotesNoContrato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pacotesNoContrato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "CodigoPostal", pacotesNoContrato.ContratoId);
            ViewData["DistritosId"] = new SelectList(_context.Distritos, "DistritosId", "Nome", pacotesNoContrato.DistritosId);
            ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "Nome", pacotesNoContrato.PacoteId);
            return View(pacotesNoContrato);
        }

        // GET: PacotesNoContrato/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacotesNoContrato = await _context.PacotesNoContrato.FindAsync(id);
            if (pacotesNoContrato == null)
            {
                return NotFound();
            }
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "CodigoPostal", pacotesNoContrato.ContratoId);
            ViewData["DistritosId"] = new SelectList(_context.Distritos, "DistritosId", "Nome", pacotesNoContrato.DistritosId);
            ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "Nome", pacotesNoContrato.PacoteId);
            return View(pacotesNoContrato);
        }

        // POST: PacotesNoContrato/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PacotesNoContratoId,ContratoId,PacoteId,DataInicio,DataFim,PrecoPacote,PromocaoDesc,PrecoFinal,Inactivo,Morada,CodigoPostal,DistritosId")] PacotesNoContrato pacotesNoContrato)
        {
            if (id != pacotesNoContrato.PacotesNoContratoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pacotesNoContrato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PacotesNoContratoExists(pacotesNoContrato.PacotesNoContratoId))
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
            ViewData["ContratoId"] = new SelectList(_context.Contratos, "ContratoId", "CodigoPostal", pacotesNoContrato.ContratoId);
            ViewData["DistritosId"] = new SelectList(_context.Distritos, "DistritosId", "Nome", pacotesNoContrato.DistritosId);
            ViewData["PacoteId"] = new SelectList(_context.Pacotes, "PacoteId", "Nome", pacotesNoContrato.PacoteId);
            return View(pacotesNoContrato);
        }

        // GET: PacotesNoContrato/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacotesNoContrato = await _context.PacotesNoContrato
                .Include(p => p.Contratos)
                .Include(p => p.Distritos)
                .Include(p => p.Pacotes)
                .FirstOrDefaultAsync(m => m.PacotesNoContratoId == id);
            if (pacotesNoContrato == null)
            {
                return NotFound();
            }

            return View(pacotesNoContrato);
        }

        // POST: PacotesNoContrato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacotesNoContrato = await _context.PacotesNoContrato.FindAsync(id);
            _context.PacotesNoContrato.Remove(pacotesNoContrato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacotesNoContratoExists(int id)
        {
            return _context.PacotesNoContrato.Any(e => e.PacotesNoContratoId == id);
        }
    }
}
