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
        private readonly Projeto_Lab_WebContext bd;

        public PromocoesController(Projeto_Lab_WebContext context)
        {
            bd = context;
        }

        // GET: Promocoes
        public async Task<IActionResult> Index()
        {
            return View(await bd.Promocoes.ToListAsync());
        }

        // GET: Promocoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocoes = await bd.Promocoes
                .FirstOrDefaultAsync(m => m.PromocoesId == id);
            if (promocoes == null)
            {
                return View ("Inexistente");
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
            if (!ModelState.IsValid)
            {

                return View(promocoes);
            }
            bd.Add(promocoes);
            await bd.SaveChangesAsync();
            ViewBag.Mensagem = "Promoção adicionada com sucesso.";
            return View("Sucesso");
        }

        // GET: Promocoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocoes = await bd.Promocoes.FindAsync(id);
            if (promocoes == null)
            {
                return View ("Inexistente");
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
                    bd.Update(promocoes);
                    await bd.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromocoesExists(promocoes.PromocoesId))
                    {
                        return View ("EliminarInserir");
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            ViewBag.Mensagem = "Promoção alterada com sucesso";
            return View("Sucesso");
        }

        // GET: Promocoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocoes = await bd.Promocoes
                .FirstOrDefaultAsync(m => m.PromocoesId == id);
            if (promocoes == null)
            {
                ViewBag.Mensagem = "A Promoção que estava a tentar apagar foi eliminada por outra pessoa.";
                return View("Sucesso");
            }

            return View(promocoes);
        }

        // POST: Promocoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promocoes = await bd.Promocoes.FindAsync(id);
            bd.Promocoes.Remove(promocoes);
            await bd.SaveChangesAsync();
            ViewBag.Mensagem = "A Promoção foi eliminada com sucesso";
            return View("Sucesso");
        }

        private bool PromocoesExists(int id)
        {
            return bd.Promocoes.Any(e => e.PromocoesId == id);
        }
    }
}
