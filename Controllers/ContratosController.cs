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
        
        public IActionResult Create2(int? clienteId, NovoContratoPasso2ViewModel contrato = null)
        {
            Utilizadores cliente = null;

            if (clienteId != null)
            {
                //função que vai buscar o ClienteId à tabela utilizadores, para lhe atribuir o nome;
                cliente = bd.Utilizadores.SingleOrDefault(e => e.UtilizadorId == clienteId);
                ViewData["ClienteId"] = cliente.UtilizadorId;
                ViewData["ClienteNome"] = cliente.Nome;
            }

            if (contrato == null)
            {
                if (cliente == null)
                {
                    // todo: mandar erro e voltar ao 1º passo
                }

                contrato = new NovoContratoPasso2ViewModel();
                contrato.Cliente = cliente;
                
            }

            ViewData["DistritosId"] = new SelectList(bd.Distritos, "DistritosId", "Nome");

            return View(contrato);
        }

        [HttpPost]
        public IActionResult Create2(NovoContratoPasso2ViewModel contrato)
        {
            if (!ModelState.IsValid)
            {
                ViewData["DistritosId"] = new SelectList(bd.Distritos, "DistritosId", "Nome");
                return View(contrato);
            }

            NovoContratoPasso3ViewModel contratoPasso3 = new NovoContratoPasso3ViewModel
            {
                ClienteId = contrato.ClienteId,
                Morada = contrato.Morada,
                DistritosId = contrato.DistritosId,
                CodigoPostal = contrato.CodigoPostal,
                Telefone = contrato.Telefone

            };
            ViewData["PacoteId"] = new SelectList(bd.Pacotes, "PacoteId", "Nome");

            return View("Create3", contratoPasso3);

        }

        public IActionResult Create3(NovoContratoPasso3ViewModel contratoPasso3, string s ="s")
        {
           
            ViewData["ClienteId"] = contratoPasso3.ClienteId;
            ViewData["Morada"] = contratoPasso3.Morada;
            ViewData["CodigoPostal"] = contratoPasso3.CodigoPostal;
            ViewData["Telefone"] = contratoPasso3.Telefone;
            ViewData["DistritosId"] = contratoPasso3.DistritosId;

            int id = contratoPasso3.ClienteId;
            ViewData["PacoteId"] = new SelectList(bd.Pacotes, "PacoteId", "Nome");

           
            return View(contratoPasso3);
        }


        [HttpPost]
        public IActionResult Create3(NovoContratoPasso3ViewModel contratoPasso3)
        {
            if (!ModelState.IsValid)
            {
                ViewData["PacoteId"] = new SelectList(bd.Pacotes, "PacoteId", "Nome");
                return View(contratoPasso3);
            }
            ViewData["PacoteId"] = new SelectList(bd.Pacotes, "PacoteId", "Nome");

            NovoContratoPasso4ViewModel contratoPasso4 = new NovoContratoPasso4ViewModel
            {
                ClienteId = contratoPasso3.ClienteId,
                Morada = contratoPasso3.Morada,
                DistritosId = contratoPasso3.DistritosId,
                CodigoPostal = contratoPasso3.CodigoPostal,
                Telefone = contratoPasso3.Telefone,
                PacoteId = contratoPasso3.PacoteId,
                DataInicio = contratoPasso3.DataInicio,
                UmAno = contratoPasso3.UmAno,
                DoisAnos = contratoPasso3.DoisAnos,

            };

            return View("Create4", contratoPasso4);

        }
        public async Task<IActionResult> Create4(NovoContratoPasso4ViewModel contratoPasso4)
        {
            if (contratoPasso4.UmAno == true)
            {
                contratoPasso4.DataFim = contratoPasso4.DataInicio.AddYears(1);
            }
            else if (contratoPasso4.DoisAnos == true)
            {
                contratoPasso4.DataFim = contratoPasso4.DataInicio.AddYears(2);
            }

            ViewData["ClienteId"] = contratoPasso4.ClienteId;
            var clienteId = bd.Utilizadores.SingleOrDefault(e => e.UtilizadorId == contratoPasso4.ClienteId);
            ViewData["ClienteNome"] = clienteId.Nome;
            ViewData["PacoteId"] = contratoPasso4.PacoteId;
            var pacoteId = bd.Pacotes.SingleOrDefault(e => e.PacoteId == contratoPasso4.PacoteId);
            ViewData["PacoteNome"] = pacoteId.Nome;
            ViewData["Morada"] = contratoPasso4.Morada;
            ViewData["CodigoPostal"] = contratoPasso4.CodigoPostal;
            ViewData["Telefone"] = contratoPasso4.Telefone;
            ViewData["DataInicio"] = contratoPasso4.DataInicio;
            ViewData["DataFim"] = contratoPasso4.DataFim;
            ViewData["DistritosId"] = contratoPasso4.DistritosId;
            var distritoId = bd.Distritos.SingleOrDefault(e => e.DistritosId == contratoPasso4.DistritosId);
            ViewData["DistritoNome"] = distritoId.Nome;


            List<Promocoes> promocoes = await bd.PromocoesPacotes.Where(p => p.PacoteId == contratoPasso4.PacoteId)
                            .Include(c => c.Promocoes)
                            .Select(c => c.Promocoes)
                            .Where(c => c.DataInicio < DateTime.Now && c.DataFim > DateTime.Now)
                            .ToListAsync();

            ViewData["PromocoesId"] = new SelectList(promocoes, "PromocoesId", "Nome");

            return View(contratoPasso4);
        }


        // POST: Contratos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Operador")]
        public async Task<IActionResult> Create5(NovoContratoPasso4ViewModel contratoPasso4, Contratos contratos)
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
            contratos.PacoteId = contratoPasso4.PacoteId;
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

            contratos.PromocoesId = contratoPasso4.PromocoesId;

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

            contratos.ClienteId = contratoPasso4.ClienteId;
            contratos.CodigoPostal = contratoPasso4.CodigoPostal;
            contratos.DataFim = contratoPasso4.DataFim;
            contratos.DataInicio = contratoPasso4.DataInicio;
            contratos.Morada = contratoPasso4.Morada;
            contratos.DistritosId = contratoPasso4.DistritosId;


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
                ViewBag.Mensagem = "O Contrato que estava a tentar apagar foi arquivado por outra pessoa.";
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
            ViewBag.Mensagem = "O Contrato foi arquivado com sucesso";
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
