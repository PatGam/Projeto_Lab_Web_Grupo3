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

        [Authorize(Roles = "Administrador,Operador")]
        public async Task<IActionResult> IndexAdministradores(string nifPesquisa, int pagina = 1)
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

                List<Utilizadores> utilizadores = await _context.Utilizadores.Where(p => p.Nif.Contains(nifPesquisa) && p.Inactivo == false && p.Role == "Administrador")
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

        [Authorize(Roles = "Administrador,Operador")]
        public IActionResult IndexClientesDistritos()
        {

            return View();



            
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

                List<Utilizadores> utilizadores = await _context.Utilizadores.Where(p => p.Nif.Contains(nifPesquisa) && p.Inactivo == false && p.Role == "Operador")
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

        [Authorize(Roles = "Administrador,Operador")]
        public async Task<IActionResult> IndexFuncionariosDistritos(string distrito, int pagina = 1)
        {




            //string que especifica o asp-router
            //ViewData["TipoUtil"] = tipoUtil;
            //return View(await _context.Utilizadores.ToListAsync());

            if (distrito != null)
            {
                Paginacao paginacao = new Paginacao
                {
                    TotalItems = await _context.Utilizadores.Where(p => distrito == null || p.Distritos.Nome.Contains(distrito)).CountAsync(),
                    PaginaAtual = pagina

                };

                List<Utilizadores> utilizadores = await _context.Utilizadores.Where(p => p.Distritos.Nome.Contains(distrito) && p.Inactivo == false && p.Role == "Operador")
                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();

                UtilizadoresViewModel model1 = new UtilizadoresViewModel
                {
                    Utilizador = utilizadores,
                    Paginacao = paginacao,
                    distrito = distrito,

                };

                return View(model1);

            }
            else
            {
                UtilizadoresViewModel model2 = new UtilizadoresViewModel
                {
                    distrito = distrito
                };

                return View(model2);

            }
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

        public IActionResult CreateAdiministrador()
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> CreateAdiministrador(RegistoUtilizadoresViewModel infoUtilizador)
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
        [Authorize(Roles = "Administrador, Cliente")]
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
        public async Task<IActionResult> EditClientes(int id, [Bind("UtilizadorId,Nome,Nif,DataNascimento,Morada,Telemovel,Email,CodigoPostal,Role, Concelho")] Utilizadores utilizadores)
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
                        ViewBag.Mensagem = "Informação do Cliente editada com sucesso.";
                        return View("SucessoClientes");
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
                else
                {
                    return View(utilizadores);
                }
                
            }
            
        }

        // GET: Utilizadores/Edit/5
        [Authorize(Roles = "Administrador,Operador, Cliente")]
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

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteFuncionarios(int? id)
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
        public async Task<IActionResult> DeleteFuncionarios(int id)
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
        public IActionResult ClientesAveiro()
        {
            return View();
        }

        public IActionResult ClientesBeja()
        {
            return View();
        }

        public IActionResult ClientesBraga()
        {
            return View();
        }

        public IActionResult ClientesBraganca()
        {
            return View();
        }

        public IActionResult ClientesCasteloBranco()
        {
            return View();
        }

        public IActionResult ClientesCoimbra()
        {
            return View();
        }

        public IActionResult ClientesEvora()
        {
            return View();
        }

        public IActionResult ClientesFaro()
        {
            return View();
        }

        public IActionResult ClientesGuarda()
        {
            return View();
        }

        public IActionResult ClientesLeiria()
        {
            return View();
        }
        public IActionResult ClientesLisboa()
        {
            return View();
        }
        public IActionResult ClientesPortalegre()
        {
            return View();
        }
        public IActionResult ClientesPorto()
        {
            return View();
        }
        public IActionResult ClientesSantarem()
        {
            return View();
        }
        public IActionResult ClientesSetubal()
        {
            return View();
        }
        public IActionResult ClientesVianaCastelo()
        {
            return View();
        }
        public IActionResult ClientesVilaReal()
        {
            return View();
        }
        public IActionResult ClientesViseu()
        {
            return View();
        }
        public IActionResult ClientesAcores()
        {
            return View();
        }
        public IActionResult ClientesMadeira()
        {
            return View();
        }

        public IActionResult OperadoresAveiro()
        {
            return View();
        }

        public IActionResult OperadoresBeja()
        {
            return View();
        }

        public IActionResult OperadoresBraga()
        {
            return View();
        }

        public IActionResult OperadoresBraganca()
        {
            return View();
        }

        public IActionResult OperadoresCasteloBranco()
        {
            return View();
        }

        public IActionResult OperadoresCoimbra()
        {
            return View();
        }

        public IActionResult OperadoresEvora()
        {
            return View();
        }

        public IActionResult OperadoresFaro()
        {
            return View();
        }

        public IActionResult OperadoresGuarda()
        {
            return View();
        }

        public IActionResult OperadoresLeiria()
        {
            return View();
        }
        public IActionResult OperadoresLisboa()
        {
            return View();
        }
        public IActionResult OperadoresPortalegre()
        {
            return View();
        }
        public IActionResult OperadoresPorto()
        {
            return View();
        }
        public IActionResult OperadoresSantarem()
        {
            return View();
        }
        public IActionResult OperadoresSetubal()
        {
            return View();
        }
        public IActionResult OperadoresVianaCastelo()
        {
            return View();
        }
        public IActionResult OperadoresVilaReal()
        {
            return View();
        }
        public IActionResult OperadoresViseu()
        {
            return View();
        }
        public IActionResult OperadoresAcores()
        {
            return View();
        }
        public IActionResult OperadoresMadeira()
        {
            return View();
        }
        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAllClientesAveiro()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Cliente" && i.DistritosId == 1)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientesBeja()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Cliente" && i.DistritosId == 2)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientesBraga()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Cliente" && i.DistritosId == 3)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientesBraganca()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Cliente" && i.DistritosId == 4)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientesCasteloBranco()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Cliente" && i.DistritosId == 5)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientesCoimbra()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Cliente" && i.DistritosId == 6)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientesEvora()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Cliente" && i.DistritosId == 7)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientesFaro()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Cliente" && i.DistritosId == 8)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientesGuarda()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Cliente" && i.DistritosId == 9)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientesLeiria()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Cliente" && i.DistritosId == 10)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientesLisboa()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Cliente" && i.DistritosId == 11)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientesPortalegre()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Cliente" && i.DistritosId == 12)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientesPorto()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Cliente" && i.DistritosId == 13)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientesSantarem()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Cliente" && i.DistritosId == 14)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientesSetubal()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Cliente" && i.DistritosId == 15)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientesVianaCastelo()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Cliente" && i.DistritosId == 16)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientesVilaReal()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Cliente" && i.DistritosId == 17)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientesViseu()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Cliente" && i.DistritosId == 18)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientesAcores()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Cliente" && i.DistritosId == 19)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClientesMadeira()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Cliente" && i.DistritosId == 20)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOperadoresAveiro()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Operador" && i.DistritosId == 1)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOperadoresBeja()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Operador" && i.DistritosId == 2)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOperadoresBraga()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Operador" && i.DistritosId == 3)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOperadoresBraganca()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Operador" && i.DistritosId == 4)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOperadoresCasteloBranco()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Operador" && i.DistritosId == 5)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOperadoresCoimbra()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Operador" && i.DistritosId == 6)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOperadoresEvora()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Operador" && i.DistritosId == 7)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOperadoresFaro()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Operador" && i.DistritosId == 8)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOperadoresGuarda()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Operador" && i.DistritosId == 9)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOperadoresLeiria()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Operador" && i.DistritosId == 10)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOperadoresLisboa()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Operador" && i.DistritosId == 11)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOperadoresPortalegre()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Operador" && i.DistritosId == 12)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOperadoresPorto()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Operador" && i.DistritosId == 13)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOperadoresSantarem()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Operador" && i.DistritosId == 14)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOperadoresSetubal()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Operador" && i.DistritosId == 15)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOperadoresVianaCastelo()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Operador" && i.DistritosId == 16)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOperadoresVilaReal()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Operador" && i.DistritosId == 17)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOperadoresViseu()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Operador" && i.DistritosId == 18)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOperadoresAcores()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Operador" && i.DistritosId == 19)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOperadoresMadeira()
        {
            var clientes = await _context.Utilizadores
                .Select(s => new { s.UtilizadorId, s.Nome, s.Nif, s.Telemovel, s.Role, s.Inactivo, s.DistritosId })
                .Where(i => i.Inactivo == false && i.Role == "Operador" && i.DistritosId == 20)
                .ToListAsync();
            return Json(new { data = clientes });
        }

        #endregion




    }

    
}
