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
        private readonly SignInManager<IdentityUser> _signInManager;

        public UtilizadoresController(Projeto_Lab_WebContext context, UserManager<IdentityUser> gestorUtilizadores)
        {
            _context = context;
            _gestorUtilizadores = gestorUtilizadores;
            

        }

        // GET: Utilizadores
        public async Task<IActionResult> Index(string tipoUtil)
        {
            //string que especifica o asp-router
            ViewData["TipoUtil"] = tipoUtil;
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
        public IActionResult Create(string tipoUtil)
        {
            //string que especifica o asp-router
            ViewData["TipoUtil"] = tipoUtil;

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



            Utilizadores utilizadores = new Utilizadores
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

            string contribuente = utilizadores.Nif;

            char firstChar = contribuente[0];
            if (firstChar.Equals('1')
                || firstChar.Equals('2')
                || firstChar.Equals('3')
                || firstChar.Equals('5')
                || firstChar.Equals('6')
                || firstChar.Equals('8')
                || firstChar.Equals('9'))
            {
                int checkDigit = (Convert.ToInt32(firstChar.ToString()) * 9);
                for (int i = 2; i <= 8; ++i)
                {
                    checkDigit += Convert.ToInt32(contribuente[i - 1].ToString()) * (10 - i);
                }

                checkDigit = 11 - (checkDigit % 11);
                if (checkDigit >= 10)
                {
                    checkDigit = 0;
                }

                if (checkDigit.ToString() != contribuente[8].ToString())
                {
                    ModelState.AddModelError("Nif", "Contribuinte Inválido, coloque novamente");
                    return View(infoUtilizador);
                }
            };

            _context.Add(utilizadores);
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

            if (utilizadores.Role == "Cliente")
            {
                ViewBag.Titulo = "Clientes";
            }

            if (utilizadores.Role != "Cliente")
            {
                ViewBag.Titulo = "Funcionários";
            }
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
            utilizadores.Inactivo = true;
            _context.Update(utilizadores); await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilizadoresExists(int id)
        {
            return _context.Utilizadores.Any(e => e.UtilizadorId == id);
        }

        [HttpPost]
        public IActionResult ConfirmarMudancaPassword()
        {
            return View();
        }

        public IActionResult MudarPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MudarPassword(MudarPasswordViewModel model)
        {
            string email = User.Identity.Name;
            

            IdentityUser utilizador = await _gestorUtilizadores.FindByNameAsync(email);
            if (ModelState.IsValid)
            {

                
                var user = await _gestorUtilizadores.GetUserAsync(User);
                if (user == null)
                {
                    return RedirectToAction("Login");
                }
                var result = await _gestorUtilizadores.ChangePasswordAsync(user,
                    model.Password, model.NovaPassword);

                //if (!result.Succeeded)
                //{
                //    foreach (var error in result.Errors)
                //    {
                //        ModelState.AddModelError(string.Empty, error);

                //    }
                //    return View();
                //}
                await _signInManager.RefreshSignInAsync(user);
                return View("Alteração da Password confirmada");
            }
            return View(model);
        }
        public ActionResult ChangePassword()
        {
            return View();
        }

        ////
        ////Save Details of New Password using Identity
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ChangePassword(MudarPasswordViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }
        //    var result = await _gestorUtilizadores.ChangePasswordAsync(User.Identity.GetUserId<int>(), model.Password, model.NovaPassword);
        //    if (result.Succeeded)
        //    {
        //        var user = await _gestorUtilizadores.FindByIdAsync(User.Identity.GetUserId<int>());
        //        if (user != null)
        //        {
        //            await _gestorUtilizadores.SignInAsync(user, isPersistent: false, rememberBrowser: false);
        //        }
        //        return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
        //    }
        //    AddErrors(result);
        //    return View(model);
        //}
    }
}
