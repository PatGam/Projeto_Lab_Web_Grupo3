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
    public class FuncionariosController : Controller
    {
        private readonly Projeto_Lab_WebContext _context;
        private readonly UserManager<IdentityUser> _gestorUtilizadores;

        public FuncionariosController(Projeto_Lab_WebContext context, UserManager<IdentityUser> gestorUtilizadores)
        {
            _context = context;
            _gestorUtilizadores = gestorUtilizadores;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await _context.Funcionarios.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };

            List<Funcionarios> funcionarios = await _context.Funcionarios.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar))
                .OrderBy(p => p.Nome)
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

            FuncionariosViewModel modelo = new FuncionariosViewModel
            {
                Paginacao = paginacao,
                Funcionarios = funcionarios,
                NomePesquisar = nomePesquisar
            };

            return base.View(modelo);
        }

        // GET: Funcionarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarios = await _context.Funcionarios
                .FirstOrDefaultAsync(m => m.FuncionarioId == id);
            if (funcionarios == null)
            {
                return NotFound();
            }

            return View(funcionarios);
        }

        // GET: Funcionarios/Create
        public IActionResult Registo()
        {
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registo(RegistoFuncionariosViewModel infoFuncionarios)
        {
            IdentityUser utilizador = await _gestorUtilizadores.FindByNameAsync(infoFuncionarios.Email);

            if (utilizador != null)
            {
                ModelState.AddModelError("Email", "Já existe um funcionário com o email que especificou.");
            }

            utilizador = new IdentityUser(infoFuncionarios.Email);
            IdentityResult resultado = await _gestorUtilizadores.CreateAsync(utilizador, infoFuncionarios.Password);

            if (!resultado.Succeeded)
            {
                ModelState.AddModelError("", "Não foi possível fazer o registo. Por favor tente mais tarde novamente e se o problema persistir contacte a assistência.");
            }
            else
            {
                await _gestorUtilizadores.AddToRoleAsync(utilizador, infoFuncionarios.Role);
            }

            if (!ModelState.IsValid)
            {
                return View(infoFuncionarios);
            }

            Funcionarios funcionarios = new Funcionarios
            {
                Nome = infoFuncionarios.Nome,
                DataNascimento = infoFuncionarios.DataNascimento,
                Morada = infoFuncionarios.Morada,
                CodigoPostal = infoFuncionarios.CodigoPostal,
                Email = infoFuncionarios.Email,
                Telemovel = infoFuncionarios.Telemovel,
                Role = infoFuncionarios.Role
            };

            _context.Add(funcionarios);
            await _context.SaveChangesAsync();

            ViewBag.Mensagem = "Funcionário adicionado com sucesso.";
            return View("Sucesso");
        }

        // GET: Funcionarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarios = await _context.Funcionarios.FindAsync(id);
            if (funcionarios == null)
            {
                return View("Inexistente");
            }
            return View(funcionarios);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FuncionarioId,Nome,DataNascimento,Morada,Telemovel,Email,CodigoPostal,Role")] Funcionarios funcionarios)
        {
            if (id != funcionarios.FuncionarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionarios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionariosExists(funcionarios.FuncionarioId))
                    {
                        return View("EliminarInserir", funcionarios);
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

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionarios = await _context.Funcionarios
                .FirstOrDefaultAsync(m => m.FuncionarioId == id);

            if (funcionarios == null)
            {
                ViewBag.Mensagem = "O funcionário que estava a tentar apagar foi eliminado por outra pessoa.";
                return View("Sucesso");
            }

            return View(funcionarios);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionarios = await _context.Funcionarios.FindAsync(id);
            _context.Funcionarios.Remove(funcionarios);
            await _context.SaveChangesAsync();

            ViewBag.Mensagem = "O funcionário foi eliminado com sucesso";
            return View("Sucesso");
        }

        private bool FuncionariosExists(int id)
        {
            return _context.Funcionarios.Any(e => e.FuncionarioId == id);
        }
    }
}
