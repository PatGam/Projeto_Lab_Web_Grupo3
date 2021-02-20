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
        private readonly Projeto_Lab_WebContext bd;

        public Tipos_ClientesController(Projeto_Lab_WebContext context)
        {
            bd = context;
        }

        // GET: Tipos_Clientes
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await bd.Tipos_Clientes.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };
            List<Tipos_Clientes> tipos_Clientes = await bd.Tipos_Clientes.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar))
              .OrderBy(p => p.Nome)
              .Skip(paginacao.ItemsPorPagina * (pagina - 1))
              .Take(paginacao.ItemsPorPagina)
              .ToListAsync();
            TiposClientesViewModel modelo = new TiposClientesViewModel
            {
                Paginacao = paginacao,
                Tipos_Clientes = tipos_Clientes,
                NomePesquisar = nomePesquisar
            };
            return base.View(modelo);
        }

        // GET: Tipos_Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipos_Clientes = await bd.Tipos_Clientes
                .FirstOrDefaultAsync(m => m.TipoClienteId == id);
            if (tipos_Clientes == null)
            {
                return View("Inexistente");
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
            bool IsTypeServiceNameExist = bd.Tipos_Clientes.Any
         (x => x.Nome == tipos_Clientes.Nome && x.TipoClienteId != tipos_Clientes.TipoClienteId);
            if (IsTypeServiceNameExist == true)
            {
                ModelState.AddModelError("Nome", "Tipo de Cliente já existe");
            }

            if (!ModelState.IsValid)
            {

                return View(tipos_Clientes);
            }
            bd.Add(tipos_Clientes);
            await bd.SaveChangesAsync();
            ViewBag.Mensagem = "Dados adicionados com sucesso.";
            return View("Sucesso");

        }

        // GET: Tipos_Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipos_Clientes = await bd.Tipos_Clientes.FindAsync(id);
            if (tipos_Clientes == null)
            {
                return View("Inexistente");
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
            bool IsTypeServiceNameExist = bd.Tipos_Clientes.Any
         (x => x.Nome == tipos_Clientes.Nome && x.TipoClienteId != tipos_Clientes.TipoClienteId);
            if (IsTypeServiceNameExist == true)
            {
                ModelState.AddModelError("Nome", "Tipo de Cliente já existe");
            }

            if (id != tipos_Clientes.TipoClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bd.Update(tipos_Clientes);
                    await bd.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tipos_ClientesExists(tipos_Clientes.TipoClienteId))
                    {
                        return View("EliminarInserir");
                    }
                    else
                    {
                        throw;
                    }
                }

            }
            ViewBag.Mensagem = "Dados alterados com sucesso";
            return View("Sucesso");
        }

        // GET: Tipos_Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipos_Clientes = await bd.Tipos_Clientes
                .FirstOrDefaultAsync(m => m.TipoClienteId == id);
            if (tipos_Clientes == null)
            {
                ViewBag.Mensagem = "Os dados que estava a tentar apagar foram eliminados por outra pessoa.";
                return View("Sucesso");
            }

            return View(tipos_Clientes);
        }

        // POST: Tipos_Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipos_Clientes = await bd.Tipos_Clientes.FindAsync(id);
            bd.Tipos_Clientes.Remove(tipos_Clientes);
            await bd.SaveChangesAsync();
            ViewBag.Mensagem = "Dados eliminados com sucesso";
            return View("Sucesso");
        }

        private bool Tipos_ClientesExists(int id)
        {
            return bd.Tipos_Clientes.Any(e => e.TipoClienteId == id);
        }
    }
}
