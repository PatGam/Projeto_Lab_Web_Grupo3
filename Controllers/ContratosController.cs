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
    public class ContratosController : Controller
    {
        private readonly Projeto_Lab_WebContext _context;

        public ContratosController(Projeto_Lab_WebContext context)
        {
            _context = context;
        }

        // GET: Contratos
        public async Task<IActionResult> Index()
        {
            var projeto_Lab_WebContext = _context.Contratos.Include(c => c.Cliente).Include(c => c.Funcionario).Include(c => c.PromocoesPacotesNavigation);
            return View(await projeto_Lab_WebContext.ToListAsync());
        }

        // GET: Contratos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratos = await _context.Contratos
                .Include(c => c.Cliente)
                .Include(c => c.Funcionario)
                .Include(c => c.PromocoesPacotesNavigation)
                .FirstOrDefaultAsync(m => m.ContratoId == id);
            if (contratos == null)
            {
                return NotFound();
            }

            return View(contratos);
        }

        // GET: Contratos/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "CodigoPostal");
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionarios, "FuncionarioId", "CodigoPostal");
            ViewData["PromocoesPacotes"] = new SelectList(_context.PromocoesPacotes, "PromocoesPacotesId", "NomePacote");
            return View();
        }

        // POST: Contratos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContratoId,ClienteId,FuncionarioId,DataInicio,PrecoFinal,DataFim,PromocoesPacotes,PrecoPacote,PromocaoDesc,NomeCliente,NomeFuncionario,Telefone")] Contratos contratos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contratos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "CodigoPostal", contratos.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionarios, "FuncionarioId", "CodigoPostal", contratos.FuncionarioId);
            ViewData["PromocoesPacotes"] = new SelectList(_context.PromocoesPacotes, "PromocoesPacotesId", "NomePacote", contratos.PromocoesPacotes);
            return View(contratos);
        }

        // GET: Contratos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratos = await _context.Contratos.FindAsync(id);
            if (contratos == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "CodigoPostal", contratos.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionarios, "FuncionarioId", "CodigoPostal", contratos.FuncionarioId);
            ViewData["PromocoesPacotes"] = new SelectList(_context.PromocoesPacotes, "PromocoesPacotesId", "NomePacote", contratos.PromocoesPacotes);
            return View(contratos);
        }

        // POST: Contratos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContratoId,ClienteId,FuncionarioId,DataInicio,PrecoFinal,DataFim,PromocoesPacotes,PrecoPacote,PromocaoDesc,NomeCliente,NomeFuncionario,Telefone")] Contratos contratos)
        {
            if (id != contratos.ContratoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contratos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratosExists(contratos.ContratoId))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "ClienteId", "CodigoPostal", contratos.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Funcionarios, "FuncionarioId", "CodigoPostal", contratos.FuncionarioId);
            ViewData["PromocoesPacotes"] = new SelectList(_context.PromocoesPacotes, "PromocoesPacotesId", "NomePacote", contratos.PromocoesPacotes);
            return View(contratos);
        }

        // GET: Contratos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratos = await _context.Contratos
                .Include(c => c.Cliente)
                .Include(c => c.Funcionario)
                .Include(c => c.PromocoesPacotesNavigation)
                .FirstOrDefaultAsync(m => m.ContratoId == id);
            if (contratos == null)
            {
                return NotFound();
            }

            return View(contratos);
        }

        // POST: Contratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contratos = await _context.Contratos.FindAsync(id);
            _context.Contratos.Remove(contratos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratosExists(int id)
        {
            return _context.Contratos.Any(e => e.ContratoId == id);
        }
    }
}
