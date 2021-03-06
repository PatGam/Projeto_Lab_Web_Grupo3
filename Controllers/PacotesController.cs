﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
        [Authorize(Roles = "Administrador,Operador")]
        public async Task<IActionResult> Index(string nomePesquisar, int pagina = 1)
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

        public async Task<IActionResult> VistaCliente()
        {

            List<Pacotes> pacotes = await bd.Pacotes
               .Where(i => i.Inactivo == false)
              .OrderBy(p => p.Nome)
              .ToListAsync();

            PacotesViewModel modelo = new PacotesViewModel
            {
                Pacotes = pacotes,
            };
            return base.View(modelo);
        }

        // GET: Pacotes/Details/5
        //[Authorize(Roles = "Administrador")]
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
            var distritos = await bd.DistritosPacotes.Where(m => m.PacoteId == id)
                .Include(l => l.Distritos)
                .ToListAsync();

            if (pacotes == null)
            {
                return View("Inexistente");
            }

            ServicosPacotesViewModel modelo = new ServicosPacotesViewModel
            {
                Pacotes = pacotes,
                ServicosPacotes = servicos,
                PromocoesPacotes = promocoes,
                DistritosPacotes = distritos,
            };



            return base.View(modelo);

        }

        // GET: Pacotes/Create
        [Authorize(Roles = "Administrador")]
        public IActionResult Create()
        {

            var servicos = bd.Servicos.ToList();
            var tiposServicos = bd.TiposServicos.ToList();

            ViewData["Tipo1"] = tiposServicos[0].Nome;
            ViewData["Tipo2"] = tiposServicos[1].Nome;
            ViewData["Tipo3"] = tiposServicos[2].Nome;
            ViewData["Tipo4"] = tiposServicos[3].Nome;
            ViewData["Tipo5"] = tiposServicos[4].Nome;

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

            var distritosCentro = bd.Distritos.Where(p => p.Nome == "Coimbra" || p.Nome == "Aveiro" || p.Nome == "Viseu"
            || p.Nome == "Leiria" || p.Nome == "Castelo Branco" || p.Nome == "Guarda")
                .ToList();

            var distritosNorte = bd.Distritos.Where(p => p.Nome == "Viana do Castelo" || p.Nome == "Braga" || p.Nome == "Porto"
            || p.Nome == "Vila Real" || p.Nome == "Bragança")
                .ToList();

            var distritosSul = bd.Distritos.Where(p => p.Nome == "Lisboa" || p.Nome == "Setúbal" || p.Nome == "Santarém"
            || p.Nome == "Portalegre" || p.Nome == "Évora" || p.Nome == "Beja" || p.Nome == "Faro")
                .ToList();

            var distritosIlhas = bd.Distritos.Where(p => p.Nome == "Açores" || p.Nome == "Madeira")
                .ToList();

            servicosPacotesViewModel.ListaDistritosCentro = distritosCentro.Select(s => new Checkbox()
            {
                Id = s.DistritosId,
                NomeDistrito = s.Nome,
                Selecionado = false
            }).ToList();

            servicosPacotesViewModel.ListaDistritosNorte = distritosNorte.Select(s => new Checkbox()
            {
                Id = s.DistritosId,
                NomeDistrito = s.Nome,
                Selecionado = false
            }).ToList();

            servicosPacotesViewModel.ListaDistritosSul = distritosSul.Select(s => new Checkbox()
            {
                Id = s.DistritosId,
                NomeDistrito = s.Nome,
                Selecionado = false
            }).ToList();

            servicosPacotesViewModel.ListaDistritosIlhas = distritosIlhas.Select(s => new Checkbox()
            {
                Id = s.DistritosId,
                NomeDistrito = s.Nome,
                Selecionado = false
            }).ToList();

            return View(servicosPacotesViewModel);

        }

        // POST: Pacotes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Create(ServicosPacotesViewModel servicosPacotesViewModel, Pacotes pacotes, ServicosPacotes servicosPacotes, IFormFile Imagem)
        {

            List<ServicosPacotes> servicosNosPacotes = new List<ServicosPacotes>();
            pacotes.Nome = servicosPacotesViewModel.Nome;
            pacotes.Descricao = servicosPacotesViewModel.Descricao;
            pacotes.Preco = servicosPacotesViewModel.Preco;
            pacotes.Inactivo = false;
            pacotes.Imagem = servicosPacotesViewModel.Imagem;
            AtualizaImagem(pacotes, Imagem);
            //acrescenta data de criação
            pacotes.DataCriacao = DateTime.Now;

            int pacoteId = pacotes.PacoteId;

            var servico1id = bd.Servicos.SingleOrDefault(e => e.ServicoId == servicosPacotesViewModel.Servico1);
            var servico2id = bd.Servicos.SingleOrDefault(e => e.ServicoId == servicosPacotesViewModel.Servico2);
            var servico3id = bd.Servicos.SingleOrDefault(e => e.ServicoId == servicosPacotesViewModel.Servico3);
            var servico4id = bd.Servicos.SingleOrDefault(e => e.ServicoId == servicosPacotesViewModel.Servico4);
            var servico5id = bd.Servicos.SingleOrDefault(e => e.ServicoId == servicosPacotesViewModel.Servico5);


            if (servico1id.Nome != "---")
            {
                servicosNosPacotes.Add(new ServicosPacotes() { PacoteId = pacoteId, ServicoId = servicosPacotesViewModel.Servico1 });
            }

            if (servico2id.Nome != "---")
            {
                servicosNosPacotes.Add(new ServicosPacotes() { PacoteId = pacoteId, ServicoId = servicosPacotesViewModel.Servico2 });
            }

            if (servico3id.Nome != "---")
            {
                servicosNosPacotes.Add(new ServicosPacotes() { PacoteId = pacoteId, ServicoId = servicosPacotesViewModel.Servico3 });
            }

            if (servico4id.Nome != "---")
            {
                servicosNosPacotes.Add(new ServicosPacotes() { PacoteId = pacoteId, ServicoId = servicosPacotesViewModel.Servico4 });
            }

            if (servico5id.Nome != "---")
            {
                servicosNosPacotes.Add(new ServicosPacotes() { PacoteId = pacoteId, ServicoId = servicosPacotesViewModel.Servico5 });
            }

            if (servicosNosPacotes.Count == 0)
            {

                ModelState.AddModelError("Servico1", "O pacote deve ter pelo menos um serviço associado.");

            }

            List<DistritosPacotes> distritoscomPacotes = new List<DistritosPacotes>();

            foreach (var item in servicosPacotesViewModel.ListaDistritosCentro)
            {
                if (item.Selecionado == true)
                {
                    distritoscomPacotes.Add(new DistritosPacotes() { PacoteId = pacoteId, DistritosId = item.Id });
                }
            }
            foreach (var item in servicosPacotesViewModel.ListaDistritosIlhas)
            {
                if (item.Selecionado == true)
                {
                    distritoscomPacotes.Add(new DistritosPacotes() { PacoteId = pacoteId, DistritosId = item.Id });
                }
            }
            foreach (var item in servicosPacotesViewModel.ListaDistritosNorte)
            {
                if (item.Selecionado == true)
                {
                    distritoscomPacotes.Add(new DistritosPacotes() { PacoteId = pacoteId, DistritosId = item.Id });
                }
            }
            foreach (var item in servicosPacotesViewModel.ListaDistritosSul)
            {
                if (item.Selecionado == true)
                {
                    distritoscomPacotes.Add(new DistritosPacotes() { PacoteId = pacoteId, DistritosId = item.Id });
                }
            }

            if (distritoscomPacotes.Count == 0)
            {

                ModelState.AddModelError("ListaDistritosCentro", "O pacote que está a criar não vai ficar disponível em nenhum distrito");

            }

            if (!ModelState.IsValid)
            {
                var servicos = bd.Servicos.ToList();
                var tiposServicos = bd.TiposServicos.ToList();

                ViewData["Tipo1"] = tiposServicos[0].Nome;
                ViewData["Tipo2"] = tiposServicos[1].Nome;
                ViewData["Tipo3"] = tiposServicos[2].Nome;
                ViewData["Tipo4"] = tiposServicos[3].Nome;
                ViewData["Tipo5"] = tiposServicos[4].Nome;

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

                var distritosCentro = bd.Distritos.Where(p => p.Nome == "Coimbra" || p.Nome == "Aveiro" || p.Nome == "Viseu"
            || p.Nome == "Leiria" || p.Nome == "Castelo Branco" || p.Nome == "Guarda")
                .ToList();

                var distritosNorte = bd.Distritos.Where(p => p.Nome == "Viana do Castelo" || p.Nome == "Braga" || p.Nome == "Porto"
                || p.Nome == "Vila Real" || p.Nome == "Bragança")
                    .ToList();

                var distritosSul = bd.Distritos.Where(p => p.Nome == "Lisboa" || p.Nome == "Setúbal" || p.Nome == "Santarém"
                || p.Nome == "Portalegre" || p.Nome == "Évora" || p.Nome == "Beja" || p.Nome == "Faro")
                    .ToList();

                var distritosIlhas = bd.Distritos.Where(p => p.Nome == "Açores" || p.Nome == "Madeira")
                    .ToList();

                servicosPacotesViewModel.ListaDistritosCentro = distritosCentro.Select(s => new Checkbox()
                {
                    Id = s.DistritosId,
                    NomeDistrito = s.Nome,
                    Selecionado = false
                }).ToList();

                servicosPacotesViewModel.ListaDistritosNorte = distritosNorte.Select(s => new Checkbox()
                {
                    Id = s.DistritosId,
                    NomeDistrito = s.Nome,
                    Selecionado = false
                }).ToList();

                servicosPacotesViewModel.ListaDistritosSul = distritosSul.Select(s => new Checkbox()
                {
                    Id = s.DistritosId,
                    NomeDistrito = s.Nome,
                    Selecionado = false
                }).ToList();

                servicosPacotesViewModel.ListaDistritosIlhas = distritosIlhas.Select(s => new Checkbox()
                {
                    Id = s.DistritosId,
                    NomeDistrito = s.Nome,
                    Selecionado = false
                }).ToList();

                return View(servicosPacotesViewModel);

            }

            bd.Pacotes.Add(pacotes);
            await bd.SaveChangesAsync();

            pacoteId = pacotes.PacoteId;
            foreach (var item in distritoscomPacotes)
            {
                item.PacoteId = pacoteId;
                bd.DistritosPacotes.Add(item);
            }
            await bd.SaveChangesAsync();

            foreach (var item in servicosNosPacotes)
            {
                item.PacoteId = pacoteId;
                bd.ServicosPacotes.Add(item);
            }
            await bd.SaveChangesAsync();



            ViewBag.Mensagem = "Pacote adicionado com sucesso.";
            return View("Sucesso");

        }

        private static void AtualizaImagem(Pacotes Pacotes, IFormFile Imagem)
        {
            if (Imagem != null && Imagem.Length > 0)
            {
                using (var ficheiroMemoria = new MemoryStream())
                {
                    Imagem.CopyTo(ficheiroMemoria);
                    Pacotes.Imagem = ficheiroMemoria.ToArray();
                }
            }
        }

        // GET: Pacotes/Edit/5
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int? id)
        {
            var servicos = bd.Servicos.ToList();
            var tiposServicos = bd.TiposServicos.ToList();

            var pacote = await bd.Pacotes.Include(p => p.DistritosPacotes)
                .ThenInclude(c => c.Distritos)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.PacoteId == (int)id);

            ViewData["Tipo1"] = tiposServicos[0].Nome;
            ViewData["Tipo2"] = tiposServicos[1].Nome;
            ViewData["Tipo3"] = tiposServicos[2].Nome;
            ViewData["Tipo4"] = tiposServicos[3].Nome;
            ViewData["Tipo5"] = tiposServicos[4].Nome;

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



            var servicosIncluidos = bd.ServicosPacotes
                .Include(p => p.Servico)
                 .Where(p => p.PacoteId == id)
                 .ToList();

            int servico1 = 0; int servico2 = 0; int servico3 = 0; int servico4 = 0; int servico5 = 0;

            foreach (var item in servicosIncluidos)
            {
                switch (item.Servico.TipoServicoId)
                {
                    case 1:
                    servico1 = item.ServicoId;
                    break;

                    case 2:
                        servico2 = item.ServicoId;
                        break;

                    case 3:
                        servico3 = item.ServicoId;
                        break;

                    case 4:
                        servico4 = item.ServicoId;
                        break;
                    case 5:
                        servico5 = item.ServicoId;
                        break;
                    default:
                        break;
                }
            }

            ViewData["Lista1"] = new SelectList(Lista1, "ServicoId", "Nome");
            ViewData["Lista2"] = new SelectList(Lista2, "ServicoId", "Nome");
            ViewData["Lista3"] = new SelectList(Lista3, "ServicoId", "Nome");
            ViewData["Lista4"] = new SelectList(Lista4, "ServicoId", "Nome");
            ViewData["Lista5"] = new SelectList(Lista5, "ServicoId", "Nome");

            ServicosPacotesViewModel servicosPacotesViewModel = new ServicosPacotesViewModel();

            if (servico1 != 0)
            {
                servicosPacotesViewModel.Servico1 = servico1;
            }
            if (servico2 != 0)
            {
                servicosPacotesViewModel.Servico2 = servico2;
            }
            if (servico3 != 0)
            {
                servicosPacotesViewModel.Servico3 = servico3;
            }
            if (servico4 != 0)
            {
                servicosPacotesViewModel.Servico4 = servico4;
            }
            if (servico5 != 0)
            {
                servicosPacotesViewModel.Servico5 = servico5;
            }


            var listaDistritosNorte = bd.Distritos.Where(p => p.Nome == "Viana do Castelo" || p.Nome == "Braga" || p.Nome == "Porto"
            || p.Nome == "Vila Real" || p.Nome == "Bragança")
                .Select(p => new Checkbox()
                {
                    Id = p.DistritosId,
                    NomeDistrito = p.Nome,
                    Selecionado = p.DistritosPacotes.Any(p => p.PacoteId == pacote.PacoteId) ? true : false
                }).ToList();

            var listaDistritosCentro = bd.Distritos
                .Where(p => p.Nome == "Coimbra" || p.Nome == "Aveiro" || p.Nome == "Viseu"
            || p.Nome == "Leiria" || p.Nome == "Castelo Branco" || p.Nome == "Guarda")
                .Select(s => new Checkbox()
                {
                    Id = s.DistritosId,
                    NomeDistrito = s.Nome,
                    Selecionado = s.DistritosPacotes.Any(s => s.PacoteId == pacote.PacoteId) ? true : false
                }).ToList();

            var listaDistritosSul = bd.Distritos
                .Where(p => p.Nome == "Lisboa" || p.Nome == "Setúbal" || p.Nome == "Santarém"
            || p.Nome == "Portalegre" || p.Nome == "Évora" || p.Nome == "Beja" || p.Nome == "Faro")
                .Select(s => new Checkbox()
                {
                    Id = s.DistritosId,
                    NomeDistrito = s.Nome,
                    Selecionado = s.DistritosPacotes.Any(s => s.PacoteId == pacote.PacoteId) ? true : false
                }).ToList();

            var listaDistritosIlhas = bd.Distritos
                .Where(p => p.Nome == "Açores" || p.Nome == "Madeira")
                .Select(s => new Checkbox()
                {
                    Id = s.DistritosId,
                    NomeDistrito = s.Nome,
                    Selecionado = s.DistritosPacotes.Any(s => s.PacoteId == pacote.PacoteId) ? true : false
                }).ToList();

            servicosPacotesViewModel.Nome = pacote.Nome;
            servicosPacotesViewModel.Descricao = pacote.Descricao;
            servicosPacotesViewModel.Preco = pacote.Preco;
            servicosPacotesViewModel.PacoteId = (int)id;
            servicosPacotesViewModel.ListaDistritosCentro = listaDistritosCentro;
            servicosPacotesViewModel.ListaDistritosIlhas = listaDistritosIlhas;
            servicosPacotesViewModel.ListaDistritosNorte = listaDistritosNorte;
            servicosPacotesViewModel.ListaDistritosSul = listaDistritosSul;

            return View(servicosPacotesViewModel);
        }

        // POST: Pacotes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Edit(int id, ServicosPacotesViewModel servicosPacotesViewModel, IFormFile Imagem)
        {
            id = servicosPacotesViewModel.PacoteId;
            List<ServicosPacotes> servicosNosPacotes = new List<ServicosPacotes>();
            Pacotes pacote = await bd.Pacotes.Include(p => p.ServicosPacotes)
                .ThenInclude(c => c.Servico)
                .AsNoTracking()
                .SingleOrDefaultAsync(p => p.PacoteId == id);

            pacote.Nome = servicosPacotesViewModel.Nome;
            pacote.Descricao = servicosPacotesViewModel.Descricao;
            pacote.Preco = servicosPacotesViewModel.Preco;
            pacote.Imagem = servicosPacotesViewModel.Imagem;
            AtualizaImagem(pacote, Imagem);

            bd.Update(pacote);
            await bd.SaveChangesAsync();

            int pacoteId = pacote.PacoteId;

            //Listas de Serviços

            var servico1id = bd.Servicos.SingleOrDefault(e => e.ServicoId == servicosPacotesViewModel.Servico1);
            var servico2id = bd.Servicos.SingleOrDefault(e => e.ServicoId == servicosPacotesViewModel.Servico2);
            var servico3id = bd.Servicos.SingleOrDefault(e => e.ServicoId == servicosPacotesViewModel.Servico3);
            var servico4id = bd.Servicos.SingleOrDefault(e => e.ServicoId == servicosPacotesViewModel.Servico4);
            var servico5id = bd.Servicos.SingleOrDefault(e => e.ServicoId == servicosPacotesViewModel.Servico5);

            var servicosPreviamenteIncluidos = bd.ServicosPacotes
                .Where(p => p.PacoteId == id)
                .ToList();

            foreach (var item in servicosPreviamenteIncluidos)
            {

                bd.ServicosPacotes.Remove(item);
            }
            await bd.SaveChangesAsync();

            if (servico1id.Nome != "---")
            {
                servicosNosPacotes.Add(new ServicosPacotes() { PacoteId = pacoteId, ServicoId = servicosPacotesViewModel.Servico1 });
            }

            if (servico2id.Nome != "---")
            {
                servicosNosPacotes.Add(new ServicosPacotes() { PacoteId = pacoteId, ServicoId = servicosPacotesViewModel.Servico2 });
            }

            if (servico3id.Nome != "---")
            {
                servicosNosPacotes.Add(new ServicosPacotes() { PacoteId = pacoteId, ServicoId = servicosPacotesViewModel.Servico3 });
            }

            if (servico4id.Nome != "---")
            {
                servicosNosPacotes.Add(new ServicosPacotes() { PacoteId = pacoteId, ServicoId = servicosPacotesViewModel.Servico4 });
            }

            if (servico5id.Nome != "---")
            {
                servicosNosPacotes.Add(new ServicosPacotes() { PacoteId = pacoteId, ServicoId = servicosPacotesViewModel.Servico5 });
            }

            if (servicosNosPacotes.Count == 0)
            {

                ModelState.AddModelError("Servico1", "O pacote deve ter pelo menos um serviço associado.");

            }

            

            //Checklist de Distritos
            List<DistritosPacotes> distritoscomPacotes = new List<DistritosPacotes>();

            foreach (var item in servicosPacotesViewModel.ListaDistritosCentro)
            {
                if (item.Selecionado == true)
                {
                    distritoscomPacotes.Add(new DistritosPacotes() { PacoteId = pacoteId, DistritosId = item.Id });
                }
            }
            foreach (var item in servicosPacotesViewModel.ListaDistritosIlhas)
            {
                if (item.Selecionado == true)
                {
                    distritoscomPacotes.Add(new DistritosPacotes() { PacoteId = pacoteId, DistritosId = item.Id });
                }
            }
            foreach (var item in servicosPacotesViewModel.ListaDistritosNorte)
            {
                if (item.Selecionado == true)
                {
                    distritoscomPacotes.Add(new DistritosPacotes() { PacoteId = pacoteId, DistritosId = item.Id });
                }
            }
            foreach (var item in servicosPacotesViewModel.ListaDistritosSul)
            {
                if (item.Selecionado == true)
                {
                    distritoscomPacotes.Add(new DistritosPacotes() { PacoteId = pacoteId, DistritosId = item.Id });
                }

            }

            if (distritoscomPacotes.Count == 0)
            {

                ModelState.AddModelError("ListaDistritosCentro", "O pacote que está a editar não vai ficar disponível em nenhum distrito");

            }

            var listaDistritosPacotes = bd.DistritosPacotes.Where(p => p.PacoteId == id).ToList();
            var resultado = listaDistritosPacotes.Except(distritoscomPacotes).ToList();

            foreach (var distrito in resultado)
            {
                bd.DistritosPacotes.Remove(distrito);
                await bd.SaveChangesAsync();
            }

            var novalistaDistritosPacotes = bd.DistritosPacotes.Where(p => p.PacoteId == id).ToList();

            

            if (!ModelState.IsValid)
            {
                var servicos = bd.Servicos.ToList();
                var tiposServicos = bd.TiposServicos.ToList();

                ViewData["Tipo1"] = tiposServicos[0].Nome;
                ViewData["Tipo2"] = tiposServicos[1].Nome;
                ViewData["Tipo3"] = tiposServicos[2].Nome;
                ViewData["Tipo4"] = tiposServicos[3].Nome;
                ViewData["Tipo5"] = tiposServicos[4].Nome;

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

                var distritosCentro = bd.Distritos.Where(p => p.Nome == "Coimbra" || p.Nome == "Aveiro" || p.Nome == "Viseu"
            || p.Nome == "Leiria" || p.Nome == "Castelo Branco" || p.Nome == "Guarda")
                .ToList();

                var distritosNorte = bd.Distritos.Where(p => p.Nome == "Viana do Castelo" || p.Nome == "Braga" || p.Nome == "Porto"
                || p.Nome == "Vila Real" || p.Nome == "Bragança")
                    .ToList();

                var distritosSul = bd.Distritos.Where(p => p.Nome == "Lisboa" || p.Nome == "Setúbal" || p.Nome == "Santarém"
                || p.Nome == "Portalegre" || p.Nome == "Évora" || p.Nome == "Beja" || p.Nome == "Faro")
                    .ToList();

                var distritosIlhas = bd.Distritos.Where(p => p.Nome == "Açores" || p.Nome == "Madeira")
                    .ToList();

                servicosPacotesViewModel.ListaDistritosCentro = distritosCentro.Select(s => new Checkbox()
                {
                    Id = s.DistritosId,
                    NomeDistrito = s.Nome,
                    Selecionado = false
                }).ToList();

                servicosPacotesViewModel.ListaDistritosNorte = distritosNorte.Select(s => new Checkbox()
                {
                    Id = s.DistritosId,
                    NomeDistrito = s.Nome,
                    Selecionado = false
                }).ToList();

                servicosPacotesViewModel.ListaDistritosSul = distritosSul.Select(s => new Checkbox()
                {
                    Id = s.DistritosId,
                    NomeDistrito = s.Nome,
                    Selecionado = false
                }).ToList();

                servicosPacotesViewModel.ListaDistritosIlhas = distritosIlhas.Select(s => new Checkbox()
                {
                    Id = s.DistritosId,
                    NomeDistrito = s.Nome,
                    Selecionado = false
                }).ToList();

                return View(servicosPacotesViewModel);

            }
            foreach (var item in servicosNosPacotes)
            {
                item.PacoteId = pacote.PacoteId;
                bd.ServicosPacotes.Add(item);
                await bd.SaveChangesAsync();


            }
            foreach (var distrito in distritoscomPacotes)
            {
                if (!novalistaDistritosPacotes.Contains(distrito))
                {
                    distrito.PacoteId = pacote.PacoteId;
                    bd.DistritosPacotes.Add(distrito);
                    await bd.SaveChangesAsync();

                }
            }

            

            ViewBag.Mensagem = "Pacote alterado com sucesso";
            return View("Sucesso");
        }

        // GET: Pacotes/Delete/5
        [Authorize(Roles = "Administrador")]
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
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacotes = await bd.Pacotes.FindAsync(id);
            pacotes.Inactivo = true;
            //atribui uma data de inactivação
            pacotes.DataInactivo = DateTime.Now;
            bd.Update(pacotes);
            await bd.SaveChangesAsync();
            ViewBag.Mensagem = "O Pacote foi arquivado com sucesso";
            return View("Sucesso");
        }

        private bool PacotesExists(int id)
        {
            return bd.Pacotes.Any(e => e.PacoteId == id);
        }


        #region API Calls
        [HttpGet]
        [Authorize(Roles = "Administrador, Operador")]
        public async Task<IActionResult> GetAll()
        {
            var servicos = await bd.Pacotes
                .Select(s => new { s.PacoteId, s.Nome, s.Preco, s.Inactivo })
                .Where(i => i.Inactivo == false)
                .ToListAsync();
            return Json(new { data = servicos });
        }

        [HttpDelete]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Delete(int id)
        {
            var pacoteFromDb = await bd.Pacotes.FirstOrDefaultAsync(s => s.PacoteId == id);
            if (pacoteFromDb == null)
            {
                return Json(new { success = false, message = "Erro ao arquivar o pacote" });
            }
            pacoteFromDb.Inactivo = true;
            bd.Pacotes.Update(pacoteFromDb);
            await bd.SaveChangesAsync();
            return Json(new { success = true, message = "O Pacote foi arquivado com sucesso" });
        }
        #endregion

        
    }
}
