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
    public class UtilizadoresController : Controller
    {
        private readonly Projeto_Lab_WebContext _context;
        private readonly UserManager<IdentityUser> _gestorUtilizadores;

        public UtilizadoresController(Projeto_Lab_WebContext context, UserManager<IdentityUser> gestorUtilizadores)
        {
            _context = context;
            _gestorUtilizadores = gestorUtilizadores;

        }

        // GET: Utilizadores
        public async Task<IActionResult> Index()
        {
            return View(await _context.Utilizadores.ToListAsync());
        }

        // GET: Utilizadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizadores = await _context.Utilizadores
                .FirstOrDefaultAsync(m => m.UtilizadorId == id);
            if (utilizadores == null)
            {
                return NotFound();
            }

            return View(utilizadores);
        }

        // GET: Utilizadores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Utilizadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegistoUtilizadoresViewModel infoUtilizador)
        {
            IdentityUser utilizador = await _gestorUtilizadores.FindByNameAsync(infoUtilizador.Email);

            if (utilizador != null)
            {
                ModelState.AddModelError("Email", "Já existe um funcionário com o email que especificou.");
            }

            utilizador = new IdentityUser(infoUtilizador.Email);
            IdentityResult resultado = await _gestorUtilizadores.CreateAsync(utilizador, infoUtilizador.Password);

            if (!resultado.Succeeded)
            {
                ModelState.AddModelError("", "Não foi possível fazer o registo. Por favor tente mais tarde novamente e se o problema persistir contacte a assistência.");
            }
            else
            {
                await _gestorUtilizadores.AddToRoleAsync(utilizador, infoUtilizador.Role);
            }

            if (!ModelState.IsValid)
            {
                //ViewData["Roles_Nome"] = new SelectList(_context.Roles, "Roles_Nome", "Roles_Nome");
                return View(infoUtilizador);
            }

            Utilizadores funcionarios = new Utilizadores
            {

                Nome = infoUtilizador.Nome,
                DataNascimento = infoUtilizador.DataNascimento,
                Morada = infoUtilizador.Morada,
                Nif = infoUtilizador.Nif,
                CodigoPostal = infoUtilizador.CodigoPostal,
                Email = infoUtilizador.Email,
                Telemovel = infoUtilizador.Telemovel,
                Role = infoUtilizador.Role,
            };

            _context.Add(utilizador);
            await _context.SaveChangesAsync();

            ViewBag.Mensagem = "Utilizador adicionado com sucesso.";
            return View("Sucesso");
        }

        // GET: Utilizadores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizadores = await _context.Utilizadores.FindAsync(id);
            if (utilizadores == null)
            {
                return NotFound();
            }
            return View(utilizadores);
        }

        // POST: Utilizadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UtilizadorId,Nome,Nif,DataNascimento,Morada,Telemovel,Email,CodigoPostal,Role")] Utilizadores utilizadores)
        {
            if (id != utilizadores.UtilizadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utilizadores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtilizadoresExists(utilizadores.UtilizadorId))
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
            return View(utilizadores);
        }

        // GET: Utilizadores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizadores = await _context.Utilizadores
                .FirstOrDefaultAsync(m => m.UtilizadorId == id);
            if (utilizadores == null)
            {
                return NotFound();
            }

            return View(utilizadores);
        }

        // POST: Utilizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utilizadores = await _context.Utilizadores.FindAsync(id);
            _context.Utilizadores.Remove(utilizadores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilizadoresExists(int id)
        {
            return _context.Utilizadores.Any(e => e.UtilizadorId == id);
        }
    }
}
