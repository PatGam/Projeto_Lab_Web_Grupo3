using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_Lab_Web_Grupo3.Data;
using Projeto_Lab_Web_Grupo3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Controllers
{
    public class Clientes2Controller : Controller
    {
        private readonly Projeto_Lab_WebContext _context;

        public Clientes2Controller(Projeto_Lab_WebContext context)
        {
            _context = context;
        }

        // GET : Clientes


        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Clientes.Where(c => nomePesquisar == null || c.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            List<Clientes> clientes = await _context.Clientes.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar))
                .OrderBy(p => p.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            ListaClientesViewModel modelo = new ListaClientesViewModel
            {
                Paginacao = paginacao,
                Clientes = clientes,
                NomePesquisar = nomePesquisar
            };
            return base.View(modelo);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        public async Task<IActionResult> Create([Bind("ClienteId,DataNascimento,Nif,Morada,Telemovel,Email,CodigoPostal")] Clientes clientes)
        {
            if (!ModelState.IsValid)
            {
                return View(clientes);
            }

            _context.Add(clientes);
            await _context.SaveChangesAsync();

            ViewBag.Mensagem = "Projeto adicionado com sucesso.";
            return View("Success");

        }

        //GET: Clientes/Edit

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projetos = await _context.Clientes.FindAsync(id);
            if (projetos == null)
            {
                return View("Missing");
            }

            return View(projetos);
        }

        // POST: Clientes/Edit

        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,DataNascimento,Nif,Morada,Telemovel,Email,CodigoPostal")] Clientes clientes)
        {
            if (id != clientes.ClienteId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(clientes);
            }
            try
            {
                _context.Update(clientes);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientesExist(clientes.ClienteId))
                {
                    return View("DeleteInsert", clientes);
                }
                else
                {
                    ModelState.AddModelError("", "Ocorreu um erro. Não foi possível guardar o produto. Tente novamente e se o problema persistir contacte a assistência.");
                    return View(clientes);
                }
            }
            ViewBag.Mensagem = "Cliente alterado com sucesso";
            return View("Success");
        }

        // GET: Clientes/Delete

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (clientes == null)
            {
                ViewBag.Mensagem = "O produto que estava a tentar apagar foi eliminado por outra pessoa.";
                return View("Success");
            }

            return View(clientes);
        }

        // POST: Clientes/Delete

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientes = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(clientes);
            await _context.SaveChangesAsync();

            ViewBag.Mensagem = "O cliente foi eliminado com sucesso";
            return View("Success");
        }

        private bool ClientesExist(int id)
        {
            return _context.Clientes.Any(p => p.ClienteId == id);
        }
    }
}
