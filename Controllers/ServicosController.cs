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
    public class ServicosController : Controller
    {
        private readonly Projeto_Lab_WebContext bd;

        public ServicosController(Projeto_Lab_WebContext context)
        {
            bd = context;
        }

        // GET: Servicos
        public async Task<IActionResult> Index(string nomePesquisar , int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await bd.Servicos.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };
            List<Servicos> servicos = await bd.Servicos.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar))
              .Include(p => p.TipoServicos)
              .OrderBy(p => p.Nome)
              .Skip(paginacao.ItemsPorPagina * (pagina - 1))
              .Take(paginacao.ItemsPorPagina)
              .ToListAsync();
            ServicosViewModel modelo = new ServicosViewModel
            {
                Paginacao = paginacao,
                Servicos = servicos,
                NomePesquisar = nomePesquisar
            };
            return base.View(modelo);
        }

        // GET: Servicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var servicos = await bd.Servicos.Include(p => p.TipoServicos)
                .SingleOrDefaultAsync(m => m.ServicoId == id);

            if (servicos == null)
            {
                return View ("Inexistente");
            }

            return View(servicos);
        }

        // GET: Servicos/Create
        public IActionResult Create()
        {
            ViewData["TipoServicoId"] = new SelectList(bd.TiposServicos, "TipoServicoId", "Nome");
            return View();
        }

        // POST: Servicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServicoId,Nome,Descricao,TipoServicoId")] Servicos servicos)
        {
            if (!ModelState.IsValid)
            {
                ViewData["TipoServicoId"] = new SelectList(bd.TiposServicos, "TipoServicoId", "Nome");
                return View(servicos);
             
               
            }
            bd.Add(servicos);
            await bd.SaveChangesAsync();

            ViewBag.Mensagem = "Serviço adicionado com sucesso.";
            return View("Sucesso");
        }

        // GET: Servicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicos = await bd.Servicos.FindAsync(id);
            if (servicos == null)
            {
                return View ("Inexistente");
            }

            ViewData["TipoServicoId"] = new SelectList(bd.TiposServicos, "TipoServicoId", "Nome");
            return View(servicos);
        }

        // POST: Servicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServicoId,Nome,Descricao,TipoServicoId")] Servicos servicos)
        {
            if (id != servicos.ServicoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bd.Update(servicos);
                    await bd.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServicosExists(servicos.ServicoId))
                    {
                        return View ("EliminarInserir");
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            ViewBag.Mensagem = "Serviço alterado com sucesso";
            return View("Sucesso");
        }

        // GET: Servicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servicos = await bd.Servicos.Include(p => p.TipoServicos)
                .SingleOrDefaultAsync(m => m.ServicoId == id);
            if (servicos == null)
            {
                ViewBag.Mensagem = "O Serviço que estava a tentar apagar foi eliminado por outra pessoa";
                return View("Sucesso");
            }

            return View(servicos);
        }

        // POST: Servicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servicos = await bd.Servicos.FindAsync(id);
            bd.Servicos.Remove(servicos);
            await bd.SaveChangesAsync();
            ViewBag.Mensagem = "O Serviço foi eliminado com sucesso";
            return View("Sucesso");
        }

        private bool ServicosExists(int id)
        {
            return bd.Servicos.Any(e => e.ServicoId == id);
        }
    }
}
