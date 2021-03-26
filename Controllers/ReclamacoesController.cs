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
        private readonly Projeto_Lab_WebContext bd;

        public ReclamacoesController(Projeto_Lab_WebContext context)
        {
            bd = context;
        }

        // GET: Reclamacoes
        public async Task<IActionResult> Index()
        {
            var projeto_Lab_WebContext = bd.Reclamacoes.Include(r => r.Cliente).Include(r => r.Funcionario);
            return View(await projeto_Lab_WebContext.ToListAsync());
        }

        // GET: Reclamacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclamacoes = await bd.Reclamacoes
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
            ViewData["ClienteId"] = new SelectList(bd.Utilizadores, "UtilizadorId", "Nome");
            ViewData["FuncionarioId"] = new SelectList(bd.Utilizadores, "UtilizadorId", "Nome");
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
                bd.Add(reclamacoes);
                await bd.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(bd.Utilizadores, "UtilizadorId", "Nome", reclamacoes.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(bd.Utilizadores, "UtilizadorId", "Nome", reclamacoes.FuncionarioId);
            return View(reclamacoes);
        }

        // GET: Reclamacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclamacoes = await bd.Reclamacoes.FindAsync(id);
            if (reclamacoes == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(bd.Utilizadores, "UtilizadorId", "Nome", reclamacoes.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(bd.Utilizadores, "UtilizadorId", "Nome", reclamacoes.FuncionarioId);
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
                    bd.Update(reclamacoes);
                    await bd.SaveChangesAsync();
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
            ViewData["ClienteId"] = new SelectList(bd.Utilizadores, "UtilizadorId", "Nome", reclamacoes.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(bd.Utilizadores, "UtilizadorId", "Nome", reclamacoes.FuncionarioId);
            return View(reclamacoes);
        }

        // GET: Reclamacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclamacoes = await bd.Reclamacoes
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
            var reclamacoes = await bd.Reclamacoes.FindAsync(id);
            bd.Reclamacoes.Remove(reclamacoes);
            await bd.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReclamacoesExists(int id)
        {
            return bd.Reclamacoes.Any(e => e.ReclamacaoId == id);
        }
    }
}
