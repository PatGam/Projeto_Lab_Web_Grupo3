using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_Lab_Web_Grupo3.Data;
using Projeto_Lab_Web_Grupo3.Models;

namespace Projeto_Lab_Web_Grupo3.Controllers
{
    public class ContratosController : Controller
    {
        private readonly Projeto_Lab_WebContext bd;

        public ContratosController(Projeto_Lab_WebContext context)
        {
            bd = context;
        }

        // GET: Contratos
        public async Task<IActionResult> Index(string nifpesquisar, bool inactivo, int pagina = 1)
        {
            if (User.IsInRole("Operador"))
            {
                if (nifpesquisar != null)
                {
                    if (inactivo == false)
                    {
                        Paginacao paginacao = new Paginacao
                        {
                            TotalItems = await bd.Contratos
                            .Where(p => nifpesquisar == null || p.Utilizadores.Nif.Contains(nifpesquisar) && p.Inactivo == false)
                            .CountAsync(),
                            PaginaAtual = pagina

                        };

                        List<Contratos> contratos = await bd.Contratos.Where(p => p.Utilizadores.Nif.Contains(nifpesquisar) && p.Inactivo == false)
                            .Include(c => c.Pacotes)
                            .Include(c => c.Utilizadores)
                            .OrderByDescending(p => p.DataInicio)
                            .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                            .Take(paginacao.ItemsPorPagina)
                            .ToListAsync();

                        ContratosViewModel modelo1 = new ContratosViewModel
                        {
                            Contratos = contratos,
                            Paginacao = paginacao,
                            NifPesquisar = nifpesquisar,
                            Inactivo = inactivo,
                        };

                        return View(modelo1);

                    }

                    else
                    {
                        Paginacao paginacao = new Paginacao
                        {
                            TotalItems = await bd.Contratos
                            .Where(p => nifpesquisar == null || p.Utilizadores.Nif.Contains(nifpesquisar))
                            .CountAsync(),
                            PaginaAtual = pagina

                        };

                        List<Contratos> contratos = await bd.Contratos.Where(p => p.Utilizadores.Nif.Contains(nifpesquisar))
                            .Include(c => c.Pacotes)
                            .Include(c => c.Utilizadores)
                            .OrderByDescending(p => p.DataInicio)
                            .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                            .Take(paginacao.ItemsPorPagina)
                            .ToListAsync();


                        ContratosViewModel modelo1 = new ContratosViewModel
                        {

                            Contratos = contratos,
                            Paginacao = paginacao,
                            NifPesquisar = nifpesquisar,
                            Inactivo = inactivo,
                        };

                        return View(modelo1);
                    }
                }

                {
                    ContratosViewModel modelo2 = new ContratosViewModel
                    {

                        NifPesquisar = nifpesquisar
                    };

                    return View(modelo2);
                }
            }
            else
            {
                Paginacao paginacao2 = new Paginacao
                {
                    TotalItems = await bd.Contratos.Include(p => p.Utilizadores).Where(p => p.Utilizadores.Email == User.Identity.Name).CountAsync(),
                    PaginaAtual = pagina
                };

                List<Contratos> contratos2 = await bd.Contratos
                    .Include(c => c.Pacotes)
                    .Include(c => c.Utilizadores)
                    .Include(p => p.Utilizadores).Where(p => p.Utilizadores.Email == User.Identity.Name)
                    .OrderByDescending(p => p.DataInicio)
                    .Skip(paginacao2.ItemsPorPagina * (pagina - 1))
                    .Take(paginacao2.ItemsPorPagina)
                    .ToListAsync();

                ContratosViewModel modelo3 = new ContratosViewModel
                {
                    Contratos = contratos2,
                    Paginacao = paginacao2,
                };

                return View(modelo3);
            }
        }
        // GET: Contratos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratos = await bd.Contratos
                .Include(c => c.Pacotes)
                .Include(c => c.Promocoes)
                .Include(c => c.Utilizadores)
                .Include(c => c.ServicosContratos)
                .ThenInclude(c => c.Servicos)
                .FirstOrDefaultAsync(m => m.ContratoId == id);

            var funcionario = await bd.Utilizadores
                .FirstOrDefaultAsync(m => m.UtilizadorId == contratos.FuncionarioId);

            var servicos = await bd.ServicosContratos
                .Include(c => c.Contratos)
                .Include(c => c.Servicos)
                .Where(c => c.ContratoId == id)
                .ToListAsync();

            ViewData["FuncionarioNome"] = funcionario.Nome;


            if (contratos == null)
            {
                return View("Inexistente");
            }

            return View(contratos);
        }


        // GET: Contratos/Create
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> Create(string nifPesquisa, int pagina = 1)
        {
            if (nifPesquisa != null)
            {
                Paginacao paginacao = new Paginacao
                {
                    TotalItems = await bd.Utilizadores.Where(p => nifPesquisa == null || p.Nif.Contains(nifPesquisa)).CountAsync(),
                    PaginaAtual = pagina

                };

                List<Utilizadores> utilizadores = await bd.Utilizadores.Where(p => p.Nif.Contains(nifPesquisa) && p.Inactivo == false && p.Role == "Cliente")
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
        public IActionResult Create2(int cliente)
        {
            //função que vai buscar o ClienteId à tabela utilizadores, para lhe atribuir o nome;
            var clienteId = bd.Utilizadores.SingleOrDefault(e => e.UtilizadorId == cliente);

            ViewData["ClienteId"] = cliente;
            ViewData["ClienteNome"] = clienteId.Nome;
            Contratos contratos = new Contratos();
            NovoContratoViewModel novoContrato = new NovoContratoViewModel
            {
                Contratos = contratos,
            };

            return View(novoContrato);
        }

        public IActionResult Create3(NovoContratoViewModel novoContrato)
        {
            ViewData["ClienteId"] = novoContrato.ClienteId;
            ViewData["Morada"] = novoContrato.Morada;
            ViewData["CodigoPostal"] = novoContrato.CodigoPostal;
            ViewData["Telefone"] = novoContrato.Telefone;

            int id = novoContrato.UtilizadorId;
            ViewData["PacoteId"] = new SelectList(bd.Pacotes, "PacoteId", "Nome");

            return View(novoContrato);
        }

        public async Task<IActionResult> Create4(NovoContratoViewModel novoContrato)
        {
            ViewData["ClienteId"] = novoContrato.ClienteId;
            var clienteId = bd.Utilizadores.SingleOrDefault(e => e.UtilizadorId == novoContrato.ClienteId);
            ViewData["ClienteNome"] = clienteId.Nome;
            ViewData["PacoteId"] = novoContrato.PacoteId;
            var pacoteId = bd.Pacotes.SingleOrDefault(e => e.PacoteId == novoContrato.PacoteId);
            ViewData["PacoteNome"] = pacoteId.Nome;
            ViewData["Morada"] = novoContrato.Morada;
            ViewData["CodigoPostal"] = novoContrato.CodigoPostal;
            ViewData["Telefone"] = novoContrato.Telefone;
            ViewData["DataInicio"] = novoContrato.DataInicio;
            ViewData["DataFim"] = novoContrato.DataFim;


            List<Promocoes> promocoes = await bd.PromocoesPacotes.Where(p => p.PacoteId == novoContrato.PacoteId)
                            .Include(c => c.Promocoes)
                            .Select(c => c.Promocoes)
                            .Where(c => c.DataInicio < DateTime.Now && c.DataFim > DateTime.Now)
                            .ToListAsync();

            ViewData["PromocoesId"] = new SelectList(promocoes, "PromocoesId", "Nome");

            return View(novoContrato);
        }


        // POST: Contratos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> Create5(NovoContratoViewModel novoContrato, Contratos contratos)
        {
            if (!ModelState.IsValid)
            {
                var clienteId = bd.Utilizadores.SingleOrDefault(e => e.UtilizadorId == contratos.UtilizadorId);

                ViewData["ClienteId"] = contratos.ClienteId;
                ViewData["ClienteNome"] = clienteId.Nome;
                ViewData["PacoteId"] = new SelectList(bd.Pacotes, "PacoteId", "Nome");
                ViewData["PromocoesId"] = new SelectList(bd.Promocoes, "PromocoesId", "Nome");
                return View();
            }

            //Código que vai buscar o ID do funcionário que tem login feito e atribui automaticamente ao contrato
            var funcionario = bd.Utilizadores.SingleOrDefault(c => c.Email == User.Identity.Name);
            var funcionarioEmail = bd.Utilizadores.SingleOrDefault(d => d.Email == funcionario.Email);
            contratos.FuncionarioId = funcionarioEmail.UtilizadorId;

            //Código que vai buscar o preço do pacote
            contratos.PacoteId = novoContrato.PacoteId;
            var pacoteid = bd.Pacotes.SingleOrDefault(e => e.PacoteId == contratos.PacoteId);
            contratos.PrecoPacote = pacoteid.Preco;

            //Código que vai buscar o nome do pacote
            contratos.NomePacote = pacoteid.Nome;

            ////Código que vai buscar o cliente
            //contratos.ClienteId = contratos.UtilizadorId;

            List<PromocoesPacotes> PromocoesDisponiveis = new List<PromocoesPacotes>();

            foreach (var pacote in bd.PromocoesPacotes)
            {
                if (contratos.PacoteId == pacote.PacoteId)
                {
                    PromocoesDisponiveis.Add(pacote);
                }
            }

            contratos.PromocoesId = novoContrato.PromocoesId;

            bool PromoDisponivel = false;
            foreach (var promocao in PromocoesDisponiveis)
            {
                if (contratos.PromocoesId == promocao.PromocoesId)
                {
                    PromoDisponivel = true;
                }
            }

            if (PromoDisponivel == false)
            {
                var clienteId = bd.Utilizadores.SingleOrDefault(e => e.UtilizadorId == contratos.UtilizadorId);

                ViewData["ClienteId"] = contratos.UtilizadorId;
                ViewData["ClienteNome"] = clienteId.Nome;
                ViewData["UtilizadorId"] = new SelectList(bd.Utilizadores, "UtilizadorId", "Nome");
                ViewData["PacoteId"] = new SelectList(bd.Pacotes, "PacoteId", "Nome");
                ViewData["PromocaoDesc"] = new SelectList(bd.Promocoes, "PromocoesId", "PromocaoDesc");
                ViewData["PromocoesId"] = new SelectList(bd.Promocoes, "PromocoesId", "Nome");

                ViewBag.Message = "A promoção que está a tentar aplicar não está disponível para o pacote selecionado";
                return View(contratos);
            }

            //Código que vai buscar o desconto da promoção
            int promo = contratos.PromocoesId;
            var promocaoid = bd.Promocoes.SingleOrDefault(e => e.PromocoesId == contratos.PromocoesId);
            contratos.PromocaoDesc = promocaoid.PromocaoDesc;

            //Cálculo do PrecoFinal
            contratos.PrecoFinal = contratos.PrecoPacote - contratos.PromocaoDesc;

            contratos.ClienteId = novoContrato.ClienteId;
            contratos.CodigoPostal = novoContrato.CodigoPostal;
            contratos.DataFim = novoContrato.DataFim;
            contratos.DataInicio = novoContrato.DataInicio;
            contratos.Morada = novoContrato.Morada;

            bd.Add(contratos);
            await bd.SaveChangesAsync();

            List<ServicosPacotes> servicosNoPacote = new List<ServicosPacotes>();
            List<ServicosContratos> servicosNoContrato = new List<ServicosContratos>();

            foreach (var item in bd.ServicosPacotes)
            {
                if (item.PacoteId == pacoteid.PacoteId)
                {
                    servicosNoPacote.Add(item);
                }
            }

            foreach (var item in servicosNoPacote)
            {
                servicosNoContrato.Add(new ServicosContratos() { ServicoId = item.ServicoId, ContratoId = contratos.ContratoId });
            }
            foreach (var item in servicosNoContrato)
            {
                bd.ServicosContratos.Add(item);
            }

            await bd.SaveChangesAsync();


            ViewBag.Mensagem = "Contrato adicionado com sucesso.";
            return View("Sucesso");
        }

        // GET: Contratos/Edit/5
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratos = await bd.Contratos.FindAsync(id);
            if (contratos == null)
            {
                return View("Inexistente");
            }
            ViewData["UtilizadorId"] = new SelectList(bd.Utilizadores, "UtilizadorId", "Nome");
            ViewData["PacoteId"] = new SelectList(bd.Pacotes, "PacoteId", "Nome");
            //ViewData["PromocoesId"] = new SelectList(bd.Promocoes, "PromocoesId", "Nome", contratos.PromocoesPacotesId);
            return View(contratos);
        }

        // POST: Contratos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> Edit(int id, [Bind("ContratoId,ClienteId, Nif, FuncionarioId,DataInicio,PrecoFinal,DataFim,PrecoPacote,PromocaoDesc,NomeCliente,NomeFuncionario,Telefone")] Contratos contratos)
        {
            if (id != contratos.ContratoId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(contratos);
            }
            try

            {
                bd.Update(contratos);
                await bd.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!ContratosExists(contratos.ContratoId))
                {
                    return View("EliminarInserir");
                }
                else
                {
                    return View(contratos);
                }
            }

            return View("Sucesso");
        }

        // GET: Contratos/Delete/5
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratos = await bd.Contratos
                .Include(c => c.Utilizadores)

                //.Include(c => c.PromocoesPacotesNavigation)
                .FirstOrDefaultAsync(m => m.ContratoId == id);
            if (contratos == null)
            {
                ViewBag.Mensagem = "O Contrato que estava a tentar apagar foi eliminado por outra pessoa.";
                return View("Sucesso");
            }

            return View(contratos);
        }

        // POST: Contratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contratos = await bd.Contratos.FindAsync(id);
            contratos.Inactivo = true;
            bd.Update(contratos);
            await bd.SaveChangesAsync();
            ViewBag.Mensagem = "O Contrato foi eliminado com sucesso";
            return View("Sucesso");
        }

        private bool ContratosExists(int id)
        {
            return bd.Contratos.Any(e => e.ContratoId == id);
        }


        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var contratos = await bd.Contratos
                .Select(s => new { s.ContratoId, s.DataInicio, s.DataFim, s.PrecoFinal, s.Telefone, s.Inactivo })
                .Where(i => i.Inactivo == false)
                .ToListAsync();
            return Json(new { data = contratos });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var contratoFromDb = await bd.Contratos.FirstOrDefaultAsync(s => s.ContratoId == id);
            if (contratoFromDb == null)
            {
                return Json(new { success = false, message = "Erro ao eliminar o contrato" });
            }
            contratoFromDb.Inactivo = true;
            bd.Update(contratoFromDb);
            await bd.SaveChangesAsync();
            return Json(new { success = true, message = "O Contrato foi eliminado com sucesso" });
        }
        #endregion
    }
}
