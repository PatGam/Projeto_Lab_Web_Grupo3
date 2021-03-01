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
    public class PacotesController : Controller
    {
        private readonly Projeto_Lab_WebContext bd;

        public PacotesController(Projeto_Lab_WebContext context)
        {
            bd = context;
        }

        // GET: Pacotes
        public async Task<IActionResult> Index(string nomePesquisar , int pagina = 1)
        {
            Paginacao paginacao = new Paginacao
            {
                TotalItems = await bd.Pacotes.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar)).CountAsync(),
                PaginaAtual = pagina
            };
            List<Pacotes> pacotes = await bd.Pacotes.Where(p => nomePesquisar == null || p.Nome.Contains(nomePesquisar))
              .OrderBy(p => p.Nome)
              .Skip(paginacao.ItemsPorPagina * (pagina - 1))
              .Take(paginacao.ItemsPorPagina)
              .ToListAsync();
            PacotesViewModel modelo = new PacotesViewModel
            {
                Paginacao = paginacao,
                Pacotes = pacotes,
                NomePesquisar = nomePesquisar
            };
            return base.View(modelo);
        }

        // GET: Pacotes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacotes = await bd.Pacotes
                .SingleOrDefaultAsync(m => m.PacoteId == id);
            var servicos = await bd.ServicosPacotes.Where(s => s.PacoteId == id)
                .Include(s => s.Servico)
                .ToListAsync();
            var promocoes = await bd.PromocoesPacotes.Where(m => m.PacoteId == id)
                .Include(l => l.Promocoes)
                .ToListAsync();

            if (pacotes == null)
            {
                return View ("Inexistente");
            }

            ServicosPacotesViewModel modelo = new ServicosPacotesViewModel
            {
                Pacotes = pacotes,
                ServicosPacotes = servicos,
                PromocoesPacotes = promocoes,
            };
            
           
            
            return base.View(modelo);
            
        }

        // GET: Pacotes/Create
        public IActionResult Create()
        {
            //return View();


            var servicos = bd.Servicos.ToList();
            var tiposservicos = bd.TiposServicos.ToList();

            //for (int i = 0; i < tiposservicos.Count; i++)
            //{
            //    List<Servicos> Lista = new List<Servicos>();
            //}
            
            List<Servicos> Lista1 = new List<Servicos>();
            List<Servicos> Lista2 = new List<Servicos>();
            List<Servicos> Lista3 = new List<Servicos>();
            List<Servicos> Lista4 = new List<Servicos>();
            List<Servicos> Lista5 = new List<Servicos>();

            foreach (var item in servicos)
            {
                switch (item.TipoServicoId)
                {
                    case 1:
                    Lista1.Add(item);
                    break;

                    case 2:
                    Lista2.Add(item);
                    break;

                    case 3:
                    Lista3.Add(item);
                    break;

                    case 4:
                    Lista4.Add(item);
                    break;

                    case 5:
                    Lista5.Add(item);
                    break;
                }
            }

            ViewData["Lista1"] = new SelectList(Lista1, "ServicoId", "Nome");
            ViewData["Lista2"] = new SelectList(Lista2, "ServicoId", "Nome");
            ViewData["Lista3"] = new SelectList(Lista3, "ServicoId", "Nome");
            ViewData["Lista4"] = new SelectList(Lista4, "ServicoId", "Nome");
            ViewData["Lista5"] = new SelectList(Lista5, "ServicoId", "Nome");

            ServicosPacotesViewModel servicosPacotesViewModel = new ServicosPacotesViewModel();
            servicosPacotesViewModel.ListaServicos = servicos.Select(s => new Checkbox()
            {
                Id = s.ServicoId,
                Nome = s.Nome,
                TipoServico = s.TipoServicoId,
                NomeTipoServico = s.TipoServicos.Nome,
                Selecionado = false
            }).ToList();

            return View(servicosPacotesViewModel);

        }

        // POST: Pacotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServicosPacotesViewModel servicosPacotesViewModel, Pacotes pacotes, ServicosPacotes servicosPacotes)
        {

            List<ServicosPacotes> servicosNosPacotes = new List<ServicosPacotes>();

            pacotes.Nome = servicosPacotesViewModel.Nome;
            pacotes.Descricao = servicosPacotesViewModel.Descricao;
            pacotes.Preco = servicosPacotesViewModel.Preco;
            pacotes.Inactivo = false;

            bd.Pacotes.Add(pacotes);
            await bd.SaveChangesAsync();
            int pacoteId = pacotes.PacoteId;

            if (servicosPacotesViewModel.Servico1 != 0)
            {
                servicosNosPacotes.Add(new ServicosPacotes() { PacoteId = pacoteId, ServicoId = servicosPacotesViewModel.Servico1 });
            }

            if (servicosPacotesViewModel.Servico2 != 0)
            {
                servicosNosPacotes.Add(new ServicosPacotes() { PacoteId = pacoteId, ServicoId = servicosPacotesViewModel.Servico2 });
            }

            if (servicosPacotesViewModel.Servico3 != 0)
            {
                servicosNosPacotes.Add(new ServicosPacotes() { PacoteId = pacoteId, ServicoId = servicosPacotesViewModel.Servico3 });
            }

            if (servicosPacotesViewModel.Servico4 != 0)
            {
                servicosNosPacotes.Add(new ServicosPacotes() { PacoteId = pacoteId, ServicoId = servicosPacotesViewModel.Servico4 });
            }

            if (servicosPacotesViewModel.Servico5 != 0)
            {
                servicosNosPacotes.Add(new ServicosPacotes() { PacoteId = pacoteId, ServicoId = servicosPacotesViewModel.Servico5 });
            }


            foreach (var item in servicosNosPacotes)
            {
                bd.ServicosPacotes.Add(item);
            }

            //foreach (var item in servicosPacotesViewModel.ListaServicos)
            //{
            //    if (item.Selecionado == true)
            //    {
            //        servicosNosPacotes.Add(new ServicosPacotes() { PacoteId = pacoteId, ServicoId = item.Id });
            //    }
            //}
           
            await bd.SaveChangesAsync();


            ViewBag.Mensagem = "Pacote adicionado com sucesso.";
            return View("Sucesso");

        }

        // GET: Pacotes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ServicosPacotesViewModel servicosPacotesViewModel = new ServicosPacotesViewModel();

            var pacote = await bd.Pacotes.Include(p => p.ServicosPacotes)
                .ThenInclude(c => c.Servico)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.PacoteId == id);

            var listaServicos = bd.Servicos.Select(s => new Checkbox()
            {
                Id = s.ServicoId,
                Nome = s.Nome,
                TipoServico = s.TipoServicoId,
                NomeTipoServico = s.TipoServicos.Nome,
                Selecionado = s.ServicosPacotes.Any(s => s.PacoteId == pacote.PacoteId) ? true : false

            }).ToList();


            servicosPacotesViewModel.Nome = pacote.Nome;
            servicosPacotesViewModel.Descricao = pacote.Descricao;
            servicosPacotesViewModel.Preco = pacote.Preco;
            servicosPacotesViewModel.ListaServicos = listaServicos;
            servicosPacotesViewModel.PacoteId = (int)id;

            return View(servicosPacotesViewModel);
        }

        // POST: Pacotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ServicosPacotesViewModel servicosPacotesViewModel)
        {

            List<ServicosPacotes> servicosNosPacotes = new List<ServicosPacotes>();
            Pacotes pacote = await bd.Pacotes.Include(p => p.ServicosPacotes)
                .ThenInclude(c => c.Servico)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.PacoteId == id);

            pacote.Nome = servicosPacotesViewModel.Nome;
            pacote.Descricao = servicosPacotesViewModel.Descricao;
            pacote.Preco = servicosPacotesViewModel.Preco;

            bd.Update(pacote);
            await bd.SaveChangesAsync();

            int pacoteId = pacote.PacoteId;

            foreach (var servico in servicosPacotesViewModel.ListaServicos)
            {
                if (servico.Selecionado == true)
                {
                    servicosNosPacotes.Add(new ServicosPacotes() { PacoteId = pacoteId, ServicoId = servico.Id });
                }
            }

            var ListaServicosPacotes = bd.ServicosPacotes.Where(p => p.PacoteId == id).ToList();
            var resultado = ListaServicosPacotes.Except(servicosNosPacotes).ToList();
            foreach (var servicoPacote in resultado)
            {
                bd.ServicosPacotes.Remove(servicoPacote);
                await bd.SaveChangesAsync();
            }
            var novaListaServicosPacotes = bd.ServicosPacotes.Where(p => p.PacoteId == id).ToList();
            foreach (var servico in servicosNosPacotes)
            {
                if (!novaListaServicosPacotes.Contains(servico))
                {
                    bd.ServicosPacotes.Add(servico);
                    await bd.SaveChangesAsync();
                }
            }

            
            ViewBag.Mensagem = "Pacote alterado com sucesso";
            return View("Sucesso");
        }

        // GET: Pacotes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacotes = await bd.Pacotes
                .SingleOrDefaultAsync(m => m.PacoteId == id);
            if (pacotes == null)
            {
                ViewBag.Mensagem = "O Pacote que estava a tentar apagar foi eliminado por outra pessoa.";
                return View("Sucesso");
            }

            return View(pacotes);
        }

        // POST: Pacotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacotes = await bd.Pacotes.FindAsync(id);
            bd.Pacotes.Remove(pacotes);
            await bd.SaveChangesAsync();
            ViewBag.Mensagem = "O Pacote foi eliminado com sucesso";
            return View("Sucesso");
        }

        private bool PacotesExists(int id)
        {
            return bd.Pacotes.Any(e => e.PacoteId == id);
        }
    }
}
