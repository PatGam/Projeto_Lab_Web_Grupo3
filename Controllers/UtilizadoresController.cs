using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Administrador,Operador")]
        public async Task<IActionResult> IndexClientes(string nifPesquisa, int pagina = 1)
        {




            //string que especifica o asp-router
            //ViewData["TipoUtil"] = tipoUtil;
            //return View(await _context.Utilizadores.ToListAsync());

            if (nifPesquisa != null)
            {
                Paginacao paginacao = new Paginacao
                {
                    TotalItems = await _context.Utilizadores.Where(p => nifPesquisa == null || p.Nif.Contains(nifPesquisa)).CountAsync(),
                    PaginaAtual = pagina

                };

                List<Utilizadores> utilizadores = await _context.Utilizadores.Where(p => p.Nif.Contains(nifPesquisa) && p.Inactivo == false && p.Role == "Cliente")
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

                UtilizadoresViewModel model1 = new UtilizadoresViewModel
                {
                    Utilizador = utilizadores,
                    Paginacao = paginacao,
                    nifPesquisa = nifPesquisa

                };

                return View(model1);

            }
            else
            {
                UtilizadoresViewModel model2 = new UtilizadoresViewModel
                {
                    nifPesquisa = nifPesquisa
                };

                return View(model2);

            }
        }





        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> IndexFuncionarios(string nifPesquisa, int pagina = 1)
        {
            if (nifPesquisa != null)
            {
                Paginacao paginacao = new Paginacao
                {
                    TotalItems = await _context.Utilizadores.Where(p => nifPesquisa == null || p.Nif.Contains(nifPesquisa)).CountAsync(),
                    PaginaAtual = pagina

                };

                List<Utilizadores> utilizadores = await _context.Utilizadores.Where(p => p.Nif.Contains(nifPesquisa) && p.Inactivo == false && p.Role != "Cliente")
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

                UtilizadoresViewModel model1 = new UtilizadoresViewModel
                {
                    Utilizador = utilizadores,
                    Paginacao = paginacao,
                    nifPesquisa = nifPesquisa

                };

                return View(model1);

            }
            else
            {
                UtilizadoresViewModel model2 = new UtilizadoresViewModel
                {
                    nifPesquisa = nifPesquisa
                };

                return View(model2);

            };

        }


        // GET: Utilizadores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            Utilizadores utilizadores;

            if (id != null)
            {
                utilizadores = await _context.Utilizadores.FirstOrDefaultAsync(m => m.UtilizadorId == id);

                if (utilizadores == null)
                { return NotFound();}
                
            }

            else
            {
                if (User.IsInRole("Cliente"))
                {
                    utilizadores = await _context.Utilizadores.SingleOrDefaultAsync(c => c.Email == User.Identity.Name);
                    ViewBag.Titulo = "Clientes";
                }
                else
                {
                    return NotFound();
                }
            }
            

            return View(utilizadores);
        }

        // GET: Utilizadores/Create
        [Authorize(Roles = "Administrador")]
        public IActionResult CreateClientes()
        {
            //string que especifica o asp-router
            //ViewData["TipoUtil"] = tipoUtil;

            return View();
        }
        [Authorize(Roles = "Administrador")]
        public IActionResult CreateFuncionarios()
        {
            //string que especifica o asp-router
            //ViewData["TipoUtil"] = tipoUtil;

            return View();
        }

        // POST: Utilizadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> CreateClientes(RegistoUtilizadoresViewModel infoUtilizador)
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
            return View("SucessoClientes");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> CreateFuncionarios(RegistoUtilizadoresViewModel infoUtilizador)
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
            return View("SucessoFuncionarios");
        }

        // GET: Utilizadores/Edit/5
        [Authorize(Roles = "Administrador,Cliente")]
        public async Task<IActionResult> EditClientes(int? id)
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
        [Authorize(Roles = "Administrador,Cliente")]
        public async Task<IActionResult> EditClientes(int id, [Bind("UtilizadorId,Nome,Nif,DataNascimento,Morada,Telemovel,Email,CodigoPostal,Role")] Utilizadores utilizadores)
        {
            var login = await _context.Utilizadores.SingleOrDefaultAsync(c => c.Email == User.Identity.Name);

            if (login.Role != "Cliente")
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        utilizadores.Role = "Cliente";
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
                }
                ViewBag.Mensagem = "Informação do Cliente editada com sucesso";
                return View("SucessoClientes");
            }
            else
            {
                if (id != login.UtilizadorId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        utilizadores.Role = "Cliente";
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
                }
                ViewBag.Mensagem = "Informação do Cliente editada com sucesso.";
                return View("SucessoClientes");
            }
                

            
        }

        // GET: Utilizadores/Edit/5
        [Authorize(Roles = "Administrador,Cliente")]
        public async Task<IActionResult> EditFuncionarios(int? id)
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
        [Authorize(Roles = "Administrador,Cliente")]
        public async Task<IActionResult> EditFuncionarios(int id, [Bind("UtilizadorId,Nome,Nif,DataNascimento,Morada,Telemovel,Email,CodigoPostal,Role")] Utilizadores utilizadores)
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
            ViewBag.Mensagem = "Informação do Funcionario editada com sucesso.";
            return View("SucessoFuncionarios");
        }


        // GET: Utilizadores/Delete/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteClientes(int? id)
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
        [HttpPost, ActionName("Arquive")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteClientes(int id)
        {
            var utilizadores = await _context.Utilizadores.FindAsync(id);
            utilizadores.Inactivo = true;
            _context.Update(utilizadores);
            await _context.SaveChangesAsync();
            ViewBag.Mensagem = "O Cliente foi arquivado com sucesso";
            return View("SucessoClientes");
        }

        private bool UtilizadoresExists(int id)
        {
            return _context.Utilizadores.Any(e => e.UtilizadorId == id);
        }


        #region API Calls
        //[HttpGet]
        //public async Task<IActionResult> GetAllFuncionarios()
        //{
        //    var funcionarios = await _context.Utilizadores
        //        .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.DataNascimento, s.Morada, s.Telemovel, s.Email, s.Role, s.Inactivo })
        //        .Where(i => i.Inactivo == false && i.Role == "Administrador" || i.Role == "Operador")
        //        .ToListAsync();
        //    return Json(new { data = funcionarios });
        //}
        #endregion

        #region API Calls
        //[HttpGet]
        //public async Task<IActionResult> GetAllClientes()
        //{
        //    var clientes = await _context.Utilizadores
        //        .Select(s => new { s.UtilizadorId, s.Nome,s.Nif, s.DataNascimento, s.Morada, s.Telemovel, s.Email,s.Role, s.Inactivo })
        //        .Where(i => i.Inactivo == false && i.Role == "Cliente")
        //        .ToListAsync();
        //    return Json(new { data = clientes });
        //}


        //[HttpDelete]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var clientesFromDb = await _context.Utilizadores.FirstOrDefaultAsync(s => s.UtilizadorId == id);
        //    if (clientesFromDb == null)
        //    {
        //        return Json(new { success = false, message = "Erro ao eliminar o cliente" });
        //    }
        //    _context.Utilizadores.Remove(clientesFromDb);
        //    await _context.SaveChangesAsync();
        //    return Json(new { success = true, message = "O Cliente foi eliminado com sucesso" });
        //}
        #endregion



    }
}
