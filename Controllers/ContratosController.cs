﻿using System;
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
        public async Task<IActionResult> Index()
        {
            var projeto_Lab_WebContext = bd.Contratos.Include(c => c.Cliente).Include(c => c.Funcionario).Include(c => c.PromocoesPacotesNavigation);
            return View(await projeto_Lab_WebContext.ToListAsync());
        }

        // GET: Contratos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratos = await bd.Contratos
                .Include(c => c.Cliente)
                .Include(c => c.Funcionario)
                .Include(c => c.PromocoesPacotesNavigation)
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
            ViewData["ClienteId"] = new SelectList(bd.Clientes, "ClienteId", "CodigoPostal");
            ViewData["FuncionarioId"] = new SelectList(bd.Funcionarios, "FuncionarioId", "CodigoPostal");
            ViewData["PromocoesPacotes"] = new SelectList(bd.PromocoesPacotes, "PromocoesPacotesId", "NomePacote");
            return View();
        }

        // POST: Contratos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContratoId,ClienteId,FuncionarioId,DataInicio,PrecoFinal,DataFim,PromocoesPacotes,PrecoPacote,PromocaoDesc,NomeCliente,NomeFuncionario,Telefone")] Contratos contratos)
        {
            if (!ModelState.IsValid)
            {
                ViewData["ClienteId"] = new SelectList(bd.Clientes, "ClienteId", "CodigoPostal", contratos.ClienteId);
                ViewData["FuncionarioId"] = new SelectList(bd.Funcionarios, "FuncionarioId", "CodigoPostal", contratos.FuncionarioId);
                ViewData["PromocoesPacotes"] = new SelectList(bd.PromocoesPacotes, "PromocoesPacotesId", "NomePacote", contratos.PromocoesPacotes);
                return View(contratos);
            }
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
                return View ("Inexistente");
            }
            ViewData["ClienteId"] = new SelectList(bd.Clientes, "ClienteId", "CodigoPostal", contratos.ClienteId);
            ViewData["FuncionarioId"] = new SelectList(bd.Funcionarios, "FuncionarioId", "CodigoPostal", contratos.FuncionarioId);
            ViewData["PromocoesPacotes"] = new SelectList(bd.PromocoesPacotes, "PromocoesPacotesId", "NomePacote", contratos.PromocoesPacotes);
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
            ViewData["PromocoesPacotes"] = new SelectList(bd.PromocoesPacotes, "PromocoesPacotesId", "NomePacote", contratos.PromocoesPacotes);
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
                .Include(c => c.Cliente)
                .Include(c => c.Funcionario)
                .Include(c => c.PromocoesPacotesNavigation)
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
