using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Lab_Web_Grupo3.Data;
using Projeto_Lab_Web_Grupo3.Models;

namespace Projeto_Lab_Web_Grupo3.Controllers
{
    public class ClientesController : Controller
    {
        private readonly Projeto_Lab_WebContext _context;
        private readonly UserManager<IdentityUser> _gestorUtilizadores;

        public ClientesController(Projeto_Lab_WebContext context, UserManager<IdentityUser> gestorUtilizadores)
        {
            _context = context;
            _gestorUtilizadores = gestorUtilizadores; 
        }

        // GET: Clientes
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Clientes.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar)).CountAsync(),
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

        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Clientes clientes;

            if (id != null)
            {
                clientes = await _context.Clientes.SingleOrDefaultAsync(c => c.ClienteId == id);

                if (clientes == null)
                {
                    return NotFound();
                }
            }
            else
            {
                if (!User.IsInRole("Cliente"))
                {
                    return NotFound();
                }

                clientes = await _context.Clientes.SingleOrDefaultAsync(c => c.Email == User.Identity.Name);

                if (clientes == null)
                {
                    return NotFound();
                }
            }

            return View(clientes);
        }

        // GET: Clientes/Create
        public IActionResult Registo()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registo(RegistoClienteViewModel infoClientes)
        {
            IdentityUser utilizador = await _gestorUtilizadores.FindByNameAsync(infoClientes.Email);

            if (utilizador != null)
            {
                ModelState.AddModelError("Email", "Já existe um cliente com o email que especificou.");
            }

            utilizador = new IdentityUser(infoClientes.Email);
            IdentityResult resultado = await _gestorUtilizadores.CreateAsync(utilizador, infoClientes.Password);

            if (!resultado.Succeeded)
            {
                ModelState.AddModelError("", "Não foi possível fazer o registo. Por favor tente mais tarde novamente e se o problema persistir contacte a assistência.");
            }
            else
            {
                await _gestorUtilizadores.AddToRoleAsync(utilizador, "Cliente");
            }

            if (!ModelState.IsValid)
            {
                return View(infoClientes);
            }

            Clientes clientes = new Clientes
            {
                Nome = infoClientes.Nome,
                DataNascimento = infoClientes.DataNascimento,
                Nif =infoClientes.Nif,
                Morada = infoClientes.Morada,
                CodigoPostal = infoClientes.CodigoPostal,
                Email = infoClientes.Email,
                Telemovel = infoClientes.Telemovel,
            };

            _context.Add(clientes);
            await _context.SaveChangesAsync();

            ViewBag.Mensagem = "Cliente adicionado com sucesso.";
            return View("Sucesso");
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clientes = await _context.Clientes.FindAsync(id);
            if (clientes == null)
            {
                return View("Inexistente");
            }
            return View(clientes);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,Nome,DataNascimento,Nif,Morada,Telemovel,Email,CodigoPostal")] Clientes clientes)
        {
            if (id != clientes.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clientes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientesExists(clientes.ClienteId))
                    {
                        return View("EliminarInserir", clientes);
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Mensagem = "Funcionário alterado com sucesso";
            return View("Sucesso");
        }

        // GET: Clientes/Delete/5
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
                ViewBag.Mensagem = "O cliente que estava a tentar apagar foi eliminado por outra pessoa.";
                return View("Sucesso");
            }

            return View(clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clientes = await _context.Clientes.FindAsync(id);
            _context.Clientes.Remove(clientes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientesExists(int id)
        {
            return _context.Clientes.Any(e => e.ClienteId == id);
        }
    }
}
