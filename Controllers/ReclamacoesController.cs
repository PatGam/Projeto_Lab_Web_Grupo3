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
using AspNetCoreHero.ToastNotification;
using AspNetCoreHero.ToastNotification.Abstractions;

namespace Projeto_Lab_Web_Grupo3.Controllers
{
    public class ReclamacoesController : Controller
    {
        private readonly Projeto_Lab_WebContext bd;

        public ReclamacoesController(Projeto_Lab_WebContext context)
        {
            bd = context;
        }

        // GET: Reclamacoes
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {




            Paginacao paginacao = new Paginacao
            {
                TotalItems = await bd.Reclamacoes

                            .CountAsync(),
                PaginaAtual = pagina
            };

            List<Reclamacoes> reclamacoes = await bd.Reclamacoes.Where(p => nomePesquisar == null || p.Cliente.Nome.Contains(nomePesquisar) || p.Cliente.Nif.Contains(nomePesquisar))
                .Include(p => p.Cliente)
                .Where(p => p.Inactivo == false)
                  .OrderBy(p => p.Cliente.Nome)

                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();


            ReclamacoesViewModel modelo = new ReclamacoesViewModel
            {
                Paginacao = paginacao,
                Reclamacoes = reclamacoes,
                NomePesquisar = nomePesquisar
            };

            return base.View(modelo);
        }
        public async Task<IActionResult> ArquivadoOperador(string nomePesquisar, int pagina = 1)
        {

            Paginacao paginacao = new Paginacao
            {
                TotalItems = await bd.Reclamacoes

                         .CountAsync(),
                PaginaAtual = pagina
            };

            List<Reclamacoes> reclamacoes = await bd.Reclamacoes.Where(p => p.Inactivo == true || p.Cliente.Nome.Contains(nomePesquisar) || p.Cliente.Nif.Contains(nomePesquisar))
                 .Include(p => p.Cliente)
                  .OrderBy(p => p.Cliente.Nome)

                .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                .Take(paginacao.ItemsPorPagina)
                .ToListAsync();


            ReclamacoesViewModel ArquivadoOperador = new ReclamacoesViewModel
            {
                Paginacao = paginacao,
                Reclamacoes = reclamacoes,
                NomePesquisar = nomePesquisar
            };

            return View(ArquivadoOperador);
        }

        // GET: Reclamacoes

        public async Task<IActionResult> ViewCliente()
        {


            List<Reclamacoes> ViewCliente = await bd.Reclamacoes

                .Include(p => p.Cliente).Where(p => p.Cliente.Email == User.Identity.Name)

                .ToListAsync();

            ReclamacoesViewModel viewCliente = new ReclamacoesViewModel
            {
                Reclamacoes = ViewCliente,
            };

            return View(viewCliente);
        }


        // GET: Reclamacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclamacoes = await bd.Reclamacoes
                .Include(r => r.Cliente)
                .Include(r => r.Funcionario)
                .FirstOrDefaultAsync(m => m.ReclamacaoId == id);
            if (reclamacoes == null)
            {
                return NotFound();
            }

            return View(reclamacoes);
        }

        // GET: Reclamacoes/Create

        [Authorize(Roles = "Cliente")]
        public IActionResult Create(int id)
        {
            ReclamacoesViewModel criar = new ReclamacoesViewModel();
            return View(criar);
        }

        // POST: Reclamacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Cliente")]
        public async Task<IActionResult> Create(ReclamacoesViewModel reclamacoesViewModel, Reclamacoes reclamacao, int id)
        {
            if (ModelState.IsValid)
            {
                var cliente = bd.Utilizadores.SingleOrDefault(c => c.Email == User.Identity.Name);
                var contrato = bd.Contratos.SingleOrDefault(c => c.UtilizadorId == cliente.UtilizadorId);

                reclamacao.Cliente = cliente;

                reclamacao.ContratoId = contrato.ContratoId;
                reclamacao.FuncionarioId = contrato.FuncionarioId;

                reclamacao.EstadoResolução = false;
                reclamacao.EstadoResposta = false;
                reclamacao.DataReclamacao = DateTime.Now;

                reclamacao.Inactivo = false;
                reclamacao.Descricao = reclamacoesViewModel.Descricao;
                reclamacao.ReclamacaoId = reclamacoesViewModel.ReclamacaoId;


                bd.Add(reclamacao);
                await bd.SaveChangesAsync();

                ViewBag.Mensagem = "Reclamação enviada com sucesso";
                return View("Sucesso");
            }



            return View(reclamacao);
        }
        // GET: Reclamacao/RespostaOperador/5
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> RespostaOperador(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ReclamacoesViewModel reclamacoesViewModel = new ReclamacoesViewModel();
            var funcionario = await bd.Utilizadores.SingleOrDefaultAsync(c => c.Email == User.Identity.Name);
            var reclamacao = await bd.Reclamacoes
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.ReclamacaoId == id);
            reclamacoesViewModel.ReclamacaoId = reclamacao.ReclamacaoId;
            reclamacoesViewModel.ContratoId = reclamacao.ContratoId;
            reclamacoesViewModel.ClienteId = reclamacao.ClienteId;
            reclamacoesViewModel.Resposta = reclamacao.Resposta;


            reclamacoesViewModel.EstadoResposta = reclamacao.EstadoResposta;
            reclamacoesViewModel.EstadoResolução = reclamacao.EstadoResolução;







            if (reclamacao == null)
            {
                return NotFound();
            }
            ViewData["ContratoId"] = new SelectList(bd.Contratos, "ContratoId", "ContratoId", reclamacoesViewModel.ContratoId);
            return View(reclamacoesViewModel);

        }
        // POST: Reclamacao/RespostaReclamacaoOperador/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> RespostaOperador(int id, ReclamacoesViewModel reclamacoesViewModel)
        {
            if (id != reclamacoesViewModel.ReclamacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var reclamacao = await bd.Reclamacoes
                        .AsNoTracking()
                        .SingleOrDefaultAsync(p => p.ReclamacaoId == id);

                    var funcionario = await bd.Utilizadores.SingleOrDefaultAsync(c => c.Email == User.Identity.Name);

                    reclamacao.ReclamacaoId = reclamacoesViewModel.ReclamacaoId;

                    reclamacoesViewModel.ClienteId = reclamacao.ClienteId;
                    reclamacao.FuncionarioId = funcionario.UtilizadorId;
                    reclamacao.ContratoId = reclamacao.ContratoId;
                    reclamacao.Resposta = reclamacoesViewModel.Resposta;
                    reclamacao.EstadoResposta = reclamacoesViewModel.EstadoResposta;
                    reclamacao.EstadoResolução = reclamacoesViewModel.EstadoResolução;
                    reclamacao.DataResposta = DateTime.Now;
                    reclamacao.DataResolucao = DateTime.Now;

                    bd.Reclamacoes.Update(reclamacao);
                    await bd.SaveChangesAsync();



                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReclamacoesExists(reclamacoesViewModel.ReclamacaoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                ViewBag.Mensagem = "Resposta enviada com sucesso";
                return View("SucessoOperador");
            }


            ModelState.AddModelError("", "Não foi possível registar a reclamação, tente novamente");
            return View(reclamacoesViewModel);
        }

        // GET: Reclamacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclamacoes = await bd.Reclamacoes.FindAsync(id);
            if (reclamacoes == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(bd.Utilizadores, "UtilizadorId", "Nome", reclamacoes.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(bd.Utilizadores, "UtilizadorId", "Nome", reclamacoes.FuncionarioId);
            return View(reclamacoes);
        }

        // POST: Reclamacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReclamacaoId,Descricao,DataReclamacao,Resposta,DataResposta,EstadoResposta,EstadoResolução,DataResolucao,ClienteId,FuncionarioId")] Reclamacoes reclamacoes)
        {
            if (id != reclamacoes.ReclamacaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bd.Update(reclamacoes);
                    await bd.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReclamacoesExists(reclamacoes.ReclamacaoId))
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
            ViewData["ClienteId"] = new SelectList(bd.Utilizadores, "UtilizadorId", "Nome", reclamacoes.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(bd.Utilizadores, "UtilizadorId", "Nome", reclamacoes.FuncionarioId);
            return View(reclamacoes);
        }

        // GET: Reclamacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reclamacoes = await bd.Reclamacoes
                .Include(r => r.Cliente)
                .Include(r => r.Funcionario)
                .FirstOrDefaultAsync(m => m.ReclamacaoId == id);
            if (reclamacoes == null)
            {
                return NotFound();
            }

            return View(reclamacoes);
        }

        // POST: Reclamacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reclamacoes = await bd.Reclamacoes.FindAsync(id);
            reclamacoes.Inactivo = true;
            bd.Update(reclamacoes);
            await bd.SaveChangesAsync();
            ViewBag.Mensagem = "Reclamação arquivada com sucesso";
            return View("Sucesso");

        }
        private bool ReclamacoesExists(int id)
        {
            return bd.Reclamacoes.Any(e => e.ReclamacaoId == id);
        }
    }
}
