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
    public class Tipos_SevicosController : Controller
    {
        private readonly Projeto_Lab_WebContext _context;

        public Tipos_SevicosController(Projeto_Lab_WebContext context)
        {
            _context = context;
        }

        // GET: Tipos_Sevicos
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.TiposServicos.Where(p => nomePesquisar == null | p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            List<Tipos_Sevicos> tipos_servicos = await _context.TiposServicos.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar))
              .OrderBy(p => p.Nome)
              .Skip(paginacao.ItemsPorPagina * (pagina - 1))
              .Take(paginacao.ItemsPorPagina)
              .ToListAsync();

            TiposServicosViewModel modelo = new TiposServicosViewModel
            {
                Paginacao = paginacao,
                TiposServicos = tipos_servicos,
                NomePesquisar = nomePesquisar
            };
            return base.View(modelo);
        }

        // GET: Tipos_Sevicos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipos_Sevicos = await _context.TiposServicos
                .FirstOrDefaultAsync(m => m.TipoServicoId == id);
            if (tipos_Sevicos == null)
            {
                return View("Inexistente");
            }

            return View(tipos_Sevicos);
        }

        // GET: Tipos_Sevicos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tipos_Sevicos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoServicoId,Nome")] Tipos_Sevicos tipos_Sevicos)
        {
            if (!ModelState.IsValid)
            {
                return View(tipos_Sevicos);
            }
            _context.Add(tipos_Sevicos);
            await _context.SaveChangesAsync();

            ViewBag.Mensagem = "Pacote adicionado com sucesso.";
            return View("Sucesso");
        }

        // GET: Tipos_Sevicos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipos_Sevicos = await _context.TiposServicos.FindAsync(id);
            if (tipos_Sevicos == null)
            {
                return View("Inexistente");
            }
            return View(tipos_Sevicos);
        }

        // POST: Tipos_Sevicos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoServicoId,Nome")] Tipos_Sevicos tipos_Sevicos)
        {
            if (id != tipos_Sevicos.TipoServicoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipos_Sevicos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Tipos_SevicosExists(tipos_Sevicos.TipoServicoId))
                    {
                        return View("EliminarInserir");
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            ViewBag.Mensagem = "Tipo de Serviço alterado com sucesso";
            return View("Sucesso");
        }

        // GET: Tipos_Sevicos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipos_Sevicos = await _context.TiposServicos
                .FirstOrDefaultAsync(m => m.TipoServicoId == id);
            if (tipos_Sevicos == null)
            {
                ViewBag.Mensagem = "O tipo de Serviço que estava a tentar apagar foi eliminado por outra pessoa.";
                return View("Sucesso");
            }

            return View(tipos_Sevicos);
        }

        // POST: Tipos_Sevicos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipos_Sevicos = await _context.TiposServicos.FindAsync(id);
            _context.TiposServicos.Remove(tipos_Sevicos);
            await _context.SaveChangesAsync();
            ViewBag.Mensagem = "O tipo de Serviço foi eliminado com sucesso";
            return View("Sucesso");
        }

        private bool Tipos_SevicosExists(int id)
        {
            return _context.TiposServicos.Any(e => e.TipoServicoId == id);
        }
    }
}
