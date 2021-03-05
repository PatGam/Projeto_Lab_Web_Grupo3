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
        public async Task<IActionResult> Index(string nifpesquisar, int pagina = 1)
        {

            if (nifpesquisar != null)
            {
                Paginacao paginacao = new Paginacao
                {
                    TotalItems = await bd.Contratos.Where(p => nifpesquisar == null || p.Utilizadores.Nif.Contains(nifpesquisar)).CountAsync(),
                    PaginaAtual = pagina

                };

                List<Contratos> contratos = await bd.Contratos.Where(p => p.Utilizadores.Nif.Contains(nifpesquisar))
                    .Skip(paginacao.ItemsPorPagina * (pagina - 1))
                    .Take(paginacao.ItemsPorPagina)
                    .ToListAsync();

                ContratosViewModel modelo1 = new ContratosViewModel
                {

                    Contratos = contratos,
                    Paginacao = paginacao,
                    NifPesquisar = nifpesquisar
                };

                

                return View(modelo1);
            }
            else
            {
                ContratosViewModel modelo2 = new ContratosViewModel
                {

                    NifPesquisar = nifpesquisar
                };

                return View(modelo2);
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
                .FirstOrDefaultAsync(m => m.ContratoId == id);

            var funcionario = await bd.Utilizadores
                .FirstOrDefaultAsync(m => m.UtilizadorId == contratos.FuncionarioId);

            ViewData["FuncionarioNome"] = funcionario.Nome;


            if (contratos == null)
            {
                return View("Inexistente");
            }

            return View(contratos);
        }

        public async Task<IActionResult> SelectCliente()
        {
            var clientes = await bd.Utilizadores
                .Where(i => i.Role == "Cliente")
                .ToListAsync();

           

            ViewData["Clientes"] = new SelectList(clientes, "UtilizadorId", "Nome");
            

            return View();
        }

        // GET: Contratos/Create
        public IActionResult Create(int cliente)
        {
            //função que vai buscar o ClienteId à tabela utilizadores, para lhe atribuir o nome;
            var clienteId = bd.Utilizadores.SingleOrDefault(e => e.UtilizadorId == cliente);

            ViewData["ClienteId"] = cliente;
            ViewData["ClienteNome"] = clienteId.Nome;
            ViewData["UtilizadorId"] = new SelectList(bd.Utilizadores, "UtilizadorId", "Nome");
            ViewData["PacoteId"] = new SelectList(bd.Pacotes, "PacoteId", "Nome");
            ViewData["PromocaoDesc"] = new SelectList(bd.Promocoes, "PromocoesId", "PromocaoDesc");
            ViewData["PromocoesId"] = new SelectList(bd.Promocoes, "PromocoesId", "Nome");


            return View();
        }

        // POST: Contratos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContratoId,ClienteId, Nif, UtilizadorId, FuncionarioId,PacoteId,PromocoesId,DataInicio,DataFim,Telefone,PrecoPacote,PromocaoDesc,PrecoFinal")] Contratos contratos)
        {

            if (!ModelState.IsValid)
            {
                var clienteId = bd.Utilizadores.SingleOrDefault(e => e.UtilizadorId == contratos.UtilizadorId);

                ViewData["ClienteId"] = contratos.UtilizadorId;
                ViewData["ClienteNome"] = clienteId.Nome;
                ViewData["UtilizadorId"] = new SelectList(bd.Utilizadores, "UtilizadorId", "Nome");
                ViewData["PacoteId"] = new SelectList(bd.Pacotes, "PacoteId", "Nome");
                ViewData["PromocaoDesc"] = new SelectList(bd.Promocoes, "PromocoesId", "PromocaoDesc");
                ViewData["PromocoesId"] = new SelectList(bd.Promocoes, "PromocoesId", "Nome");
                return View();
            }

            //Código que vai buscar o ID do funcionário que tem login feito e atribui automaticamente ao contrato
            var funcionario = bd.Utilizadores.SingleOrDefault(c => c.Email == User.Identity.Name);
            var funcionarioEmail = bd.Utilizadores.SingleOrDefault(d => d.Email == funcionario.Email);
            contratos.FuncionarioId = funcionarioEmail.UtilizadorId;

            //Código que vai buscar o preço do pacote
            var pacoteid = bd.Pacotes.SingleOrDefault(e => e.PacoteId == contratos.PacoteId);
            contratos.PrecoPacote = pacoteid.Preco;

            //Código que vai buscar o cliente
            
            contratos.ClienteId = contratos.UtilizadorId;

            List<PromocoesPacotes> PromocoesDisponiveis = new List<PromocoesPacotes>();

            foreach(var pacote in bd.PromocoesPacotes)
            {
                if(contratos.PacoteId == pacote.PacoteId)
                {
                    PromocoesDisponiveis.Add(pacote);
                }
            }

            bool PromoDisponivel = false;
            foreach (var promocao in PromocoesDisponiveis)
            {
                if(contratos.PromocoesId == promocao.PromocoesId)
                {
                    PromoDisponivel = true;
                }
            }

            if(PromoDisponivel == false)
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

            bd.Add(contratos);
            await bd.SaveChangesAsync();

            ViewBag.Mensagem = "Contrato adicionado com sucesso.";
            return View("Sucesso");
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
                .Select(s => new { s.ContratoId, s.DataInicio, s.DataFim, s.PrecoFinal, s.Telefone , s.Inactivo })
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
            bd.Contratos.Remove(contratoFromDb);
            await bd.SaveChangesAsync();
            return Json(new { success = true, message = "O Contrato foi eliminado com sucesso" });
        }
        #endregion
    }
}
