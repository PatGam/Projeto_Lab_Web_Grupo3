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
    public class ContratosController : Controller
    {
        private readonly Projeto_Lab_WebContext bd;

        public ContratosController(Projeto_Lab_WebContext context)
        {
            bd = context;
        }

        // GET: Contratos
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await bd.Contratos.Where(p => nomePesquisar == null || p.Clientes.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };
            List<Contratos> contratos = await bd.Contratos.Where(p => nomePesquisar == null || p.Clientes.Nome.Contains(nomePesquisar))
              .OrderBy(p => p.Clientes.Nome)
              .Skip(paginacao.ItemsPorPagina * (pagina - 1))
              .Take(paginacao.ItemsPorPagina)
              .ToListAsync();
           ContratosViewModel modelo = new ContratosViewModel
            {
                Paginacao = paginacao,
                Contratos=contratos,
                NomePesquisar = nomePesquisar
            };
            return base.View(modelo);
        }
        // GET: Contratos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratos = await bd.Contratos
                .Include(c => c.Clientes)
                .Include(c => c.Funcionarios)
                //.Include(c => c.PromocoesPacotesNavigation)
                .FirstOrDefaultAsync(m => m.ContratoId == id);
            if (contratos == null)
            {
                return View("Inexistente") ;
            }

            return View(contratos);
        }

        // GET: Contratos/Create
        public IActionResult Create()
        {

            ViewData["ClienteId"] = new SelectList(bd.Clientes, "ClienteId", "Nome");
            ViewData["FuncionarioId"] = new SelectList(bd.Funcionarios, "FuncionarioId", "Nome");
            ViewData["PacoteId"] = new SelectList(bd.Pacotes, "PacoteId", "Nome");
            ViewData["PromocoesId"] = new SelectList(bd.Promocoes, "PromocoesId", "PromocaoDesc");
            ViewData["PromocoesPacotesId"] = new SelectList(bd.PromocoesPacotes, "PromocoesPacotesId", "NomePromocoes");


            return View();
        }

        // POST: Contratos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContratoId,ClienteId,FuncionarioId,PacoteId,PromocoesPacotesId,DataInicio,DataFim,Telefone,PrecoPacote,PromocaoDesc,PrecoFinal")] Contratos contratos)
        {


            var funcionario = bd.Funcionarios.SingleOrDefault(c => c.Email == User.Identity.Name);
            var funcionarioEmail = bd.Funcionarios.SingleOrDefault(d => d.Email == funcionario.Email);
            contratos.FuncionarioId = funcionarioEmail.FuncionarioId;

            //var pacoteId = contratos.PacoteId;
            //var pacoteId2 = bd.Pacotes.SingleOrDefault(e => e.PacoteId == pacoteId);
            //var precoPacote = bd.Pacotes.SingleOrDefault(e => e.Preco == pacoteId2.Preco);

            //contratos.PrecoPacote = precoPacote.PacoteId;

            //var promocaoPacoteId = contratos.PromocoesPacotesId;
            //var promocaopacoteId = bd.PromocoesPacotes.SingleOrDefault(c => c.PromocoesPacotesId == promocaoPacoteId);
            //var pacoteProm = bd.PromocoesPacotes.SingleOrDefault(c => c.PromocoesPacotesId == promocaopacoteId.PromocoesId);
            //var promocaoId = bd.Promocoes.SingleOrDefault(c => c.PromocoesId == pacoteProm.PromocoesId);
            //var desc = bd.Promocoes.SingleOrDefault(c => c.PromocoesId == promocaoId.PromocaoDesc);

            //contratos.PromocaoDesc = desc.PromocoesId;
            //contratos.PrecoFinal = contratos.PrecoPacote - contratos.PromocaoDesc;

            contratos.PrecoPacote = 30m;
            contratos.PromocaoDesc = 2.5m;
            contratos.PrecoFinal = contratos.PrecoPacote - contratos.PromocaoDesc;

            bd.Add(contratos);
            await bd.SaveChangesAsync();

            ViewBag.Mensagem = "Contrato adicionado com sucesso.";
            return View("Sucesso");


            if (!ModelState.IsValid)
            {
                ViewData["ClienteId"] = new SelectList(bd.Clientes, "ClienteId", "CodigoPostal", contratos.ClienteId);
                ViewData["FuncionarioId"] = new SelectList(bd.Funcionarios, "FuncionarioId", "CodigoPostal", contratos.FuncionarioId);
                ViewData["PromocoesPacotesId"] = new SelectList(bd.PromocoesPacotes, "PromocoesPacotesId", "NomePromocoes", contratos.PromocoesPacotesId);
                return View(contratos);
            }
        }

        // GET: Contratos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratos = await bd.Contratos.FindAsync(id);
            if (contratos == null)
            {
                return View ("Inexistente");
            }
            ViewData["ClienteId"] = new SelectList(bd.Clientes, "ClienteId", "CodigoPostal", contratos.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(bd.Funcionarios, "FuncionarioId", "CodigoPostal", contratos.FuncionarioId);
            //ViewData["PromocoesPacotes"] = new SelectList(bd.PromocoesPacotes, "PromocoesPacotesId", "NomePacote", contratos.PromocoesPacotes);
            return View(contratos);
        }

        // POST: Contratos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContratoId,ClienteId,FuncionarioId,DataInicio,PrecoFinal,DataFim,PromocoesPacotes,PrecoPacote,PromocaoDesc,NomeCliente,NomeFuncionario,Telefone")] Contratos contratos)
        {
            if (id != contratos.ContratoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    bd.Update(contratos);
                    await bd.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratosExists(contratos.ContratoId))
                    {
                        return View ("EliminarInserir");
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(bd.Clientes, "ClienteId", "CodigoPostal", contratos.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(bd.Funcionarios, "FuncionarioId", "CodigoPostal", contratos.FuncionarioId);
            //ViewData["PromocoesPacotes"] = new SelectList(bd.PromocoesPacotes, "PromocoesPacotesId", "NomePacote", contratos.PromocoesPacotes);
            return View("Sucesso");
        }

        // GET: Contratos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratos = await bd.Contratos
                .Include(c => c.Clientes)
                .Include(c => c.Funcionarios)
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contratos = await bd.Contratos.FindAsync(id);
            bd.Contratos.Remove(contratos);
            await bd.SaveChangesAsync();
            ViewBag.Mensagem = "O Contrato foi eliminado com sucesso";
            return View("Sucesso");
        }

        private bool ContratosExists(int id)
        {
            return bd.Contratos.Any(e => e.ContratoId == id);
        }
    }
}
