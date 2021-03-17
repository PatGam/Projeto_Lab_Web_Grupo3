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
    public class ReclamacoesController : Controller
    {
        private readonly Projeto_Lab_WebContext _context;

        public ReclamacoesController(Projeto_Lab_WebContext context)
        {
            _context = context;
        }

        // GET: Reclamacoes
        public async Task<IActionResult> Index()
        {
            var projeto_Lab_WebContext = _context.Reclamacoes.Include(r => r.Cliente).Include(r => r.Funcionario);
            return View(await projeto_Lab_WebContext.ToListAsync());
        }

        // GET: Reclamacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclamacoes = await _context.Reclamacoes
                .Include(r => r.Cliente)
                .Include(r => r.Funcionario)
                .FirstOrDefaultAsync(m => m.ReclamacaoId == id);
            if (reclamacoes == null)
            {
                return NotFound();
            }

            return View(reclamacoes);
        }

        // GET: Reclamacoes/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Utilizadores, "UtilizadorId", "CodigoPostal");
            ViewData["FuncionarioId"] = new SelectList(_context.Utilizadores, "UtilizadorId", "CodigoPostal");
            return View();
        }

        // POST: Reclamacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReclamacaoId,Descricao,DataReclamacao,Resposta,DataResposta,EstadoResposta,EstadoResolução,DataResolucao,ClienteId,FuncionarioId")] Reclamacoes reclamacoes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reclamacoes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Utilizadores, "UtilizadorId", "CodigoPostal", reclamacoes.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Utilizadores, "UtilizadorId", "CodigoPostal", reclamacoes.FuncionarioId);
            return View(reclamacoes);
        }

        // GET: Reclamacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclamacoes = await _context.Reclamacoes.FindAsync(id);
            if (reclamacoes == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Utilizadores, "UtilizadorId", "CodigoPostal", reclamacoes.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Utilizadores, "UtilizadorId", "CodigoPostal", reclamacoes.FuncionarioId);
            return View(reclamacoes);
        }

        // POST: Reclamacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReclamacaoId,Descricao,DataReclamacao,Resposta,DataResposta,EstadoResposta,EstadoResolução,DataResolucao,ClienteId,FuncionarioId")] Reclamacoes reclamacoes)
        {
            if (id != reclamacoes.ReclamacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reclamacoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReclamacoesExists(reclamacoes.ReclamacaoId))
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
            ViewData["ClienteId"] = new SelectList(_context.Utilizadores, "UtilizadorId", "CodigoPostal", reclamacoes.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(_context.Utilizadores, "UtilizadorId", "CodigoPostal", reclamacoes.FuncionarioId);
            return View(reclamacoes);
        }

        // GET: Reclamacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclamacoes = await _context.Reclamacoes
                .Include(r => r.Cliente)
                .Include(r => r.Funcionario)
                .FirstOrDefaultAsync(m => m.ReclamacaoId == id);
            if (reclamacoes == null)
            {
                return NotFound();
            }

            return View(reclamacoes);
        }

        // POST: Reclamacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reclamacoes = await _context.Reclamacoes.FindAsync(id);
            _context.Reclamacoes.Remove(reclamacoes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReclamacoesExists(int id)
        {
            return _context.Reclamacoes.Any(e => e.ReclamacaoId == id);
        }
    }
}
