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
    public class Tipos_ClientesController : Controller
    {
        private readonly Projeto_Lab_WebContext _context;

        public Tipos_ClientesController(Projeto_Lab_WebContext context)
        {
            _context = context;
        }

        // GET: Tipos_Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipos_Clientes.ToListAsync());
        }

        // GET: Tipos_Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipos_Clientes = await _context.Tipos_Clientes
                .FirstOrDefaultAsync(m => m.TipoClienteId == id);
            if (tipos_Clientes == null)
            {
                return NotFound();
            }

            return View(tipos_Clientes);
        }

        // GET: Tipos_Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipos_Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoClienteId,Nome")] Tipos_Clientes tipos_Clientes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipos_Clientes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipos_Clientes);
        }

        // GET: Tipos_Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipos_Clientes = await _context.Tipos_Clientes.FindAsync(id);
            if (tipos_Clientes == null)
            {
                return NotFound();
            }
            return View(tipos_Clientes);
        }

        // POST: Tipos_Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoClienteId,Nome")] Tipos_Clientes tipos_Clientes)
        {
            if (id != tipos_Clientes.TipoClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipos_Clientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tipos_ClientesExists(tipos_Clientes.TipoClienteId))
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
            return View(tipos_Clientes);
        }

        // GET: Tipos_Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipos_Clientes = await _context.Tipos_Clientes
                .FirstOrDefaultAsync(m => m.TipoClienteId == id);
            if (tipos_Clientes == null)
            {
                return NotFound();
            }

            return View(tipos_Clientes);
        }

        // POST: Tipos_Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipos_Clientes = await _context.Tipos_Clientes.FindAsync(id);
            _context.Tipos_Clientes.Remove(tipos_Clientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Tipos_ClientesExists(int id)
        {
            return _context.Tipos_Clientes.Any(e => e.TipoClienteId == id);
        }
    }
}
