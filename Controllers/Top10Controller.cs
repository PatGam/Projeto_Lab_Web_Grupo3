﻿using System;
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
    public class Top10Controller : Controller
    {
        private readonly Projeto_Lab_WebContext bd;

        public Top10Controller(Projeto_Lab_WebContext context)
        {
            bd = context;
        }

        public async Task<IActionResult> Top10Operadores()
        {

            List<LucroClienteOperador> operadores = new List<LucroClienteOperador>();
            decimal lucro = 0;
            foreach (var operador in bd.Utilizadores)
            {
                if (operador.Role == "Operador")
                {
                    foreach (var contrato in bd.Contratos)
                    {
                        if (contrato.FuncionarioId == operador.UtilizadorId)
                        {
                            lucro += contrato.PrecoFinal;
                        }
                    }
                    var distrito = await bd.Distritos
                        .FirstOrDefaultAsync(m => m.DistritosId == operador.DistritosId);
                    operadores.Add(new LucroClienteOperador() { UtilizadorId = operador.UtilizadorId, DistritosId = operador.DistritosId, Lucro = lucro, OperadorNome = operador.Nome, DistritoNome = distrito.Nome });
                    lucro = 0;
                }
            }

            var nomeDistrito1 = await bd.Distritos
                .FirstOrDefaultAsync(m => m.Nome == "Aveiro");
            var nomeDistrito2 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Beja");
            var nomeDistrito3 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Braga");
            var nomeDistrito4 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Bragança");
            var nomeDistrito5 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Castelo Branco");
            var nomeDistrito6 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Coimbra");
            var nomeDistrito7 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Évora");
            var nomeDistrito8 = await bd.Distritos
                .FirstOrDefaultAsync(m => m.Nome == "Faro");
            var nomeDistrito9 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Guarda");
            var nomeDistrito10 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Leiria");
            var nomeDistrito11 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Lisboa");
            var nomeDistrito12 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Portalegre");
            var nomeDistrito13 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Porto");
            var nomeDistrito14 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Santarém");
            var nomeDistrito15 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Setúbal");
            var nomeDistrito16 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Viana do Castelo");
            var nomeDistrito17 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Vila Real");
            var nomeDistrito18 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Viseu");
            var nomeDistrito19 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Açores");
            var nomeDistrito20 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Madeira");

            ViewData["Aveiro"] = nomeDistrito1.Nome;
            ViewData["Beja"] = nomeDistrito2.Nome;
            ViewData["Braga"] = nomeDistrito3.Nome;
            ViewData["Braganca"] = nomeDistrito4.Nome;
            ViewData["CasteloBranco"] = nomeDistrito5.Nome;
            ViewData["Coimbra"] = nomeDistrito6.Nome;
            ViewData["Evora"] = nomeDistrito7.Nome;
            ViewData["Faro"] = nomeDistrito8.Nome;
            ViewData["Guarda"] = nomeDistrito9.Nome;
            ViewData["Leiria"] = nomeDistrito10.Nome;
            ViewData["Lisboa"] = nomeDistrito11.Nome;
            ViewData["Portalegre"] = nomeDistrito12.Nome;
            ViewData["Porto"] = nomeDistrito13.Nome;
            ViewData["Santarem"] = nomeDistrito14.Nome;
            ViewData["Setubal"] = nomeDistrito15.Nome;
            ViewData["Viana"] = nomeDistrito16.Nome;
            ViewData["VilaReal"] = nomeDistrito17.Nome;
            ViewData["Viseu"] = nomeDistrito18.Nome;
            ViewData["Acores"] = nomeDistrito19.Nome;
            ViewData["Madeira"] = nomeDistrito20.Nome;


            List<LucroClienteOperador> operadoresAveiro = operadores
                .Where(p => p.DistritoNome == "Aveiro")
                .OrderByDescending(p => p.Lucro)
                .Take(10)
                .ToList();

            List<LucroClienteOperador> operadoresBeja = operadores
             .Where(p => p.DistritoNome == "Beja")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> operadoresBraga = operadores
             .Where(p => p.DistritoNome == "Braga")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            List<LucroClienteOperador> operadoresBraganca = operadores
             .Where(p => p.DistritoNome == "Bragança")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            List<LucroClienteOperador> operadoresCasteloBranco = operadores
             .Where(p => p.DistritoNome == "Castelo Branco")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> operadoresCoimbra = operadores
             .Where(p => p.DistritoNome == "Coimbra")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            List<LucroClienteOperador> operadoresEvora = operadores
             .Where(p => p.DistritoNome == "Évora")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> operadoresFaro = operadores
             .Where(p => p.DistritoNome == "Faro")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> operadoresGuarda = operadores
             .Where(p => p.DistritoNome == "Guarda")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            List<LucroClienteOperador> operadoresLeiria = operadores
             .Where(p => p.DistritoNome == "Leiria")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            List<LucroClienteOperador> operadoresLisboa = operadores
             .Where(p => p.DistritoNome == "Lisboa")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            List<LucroClienteOperador> operadoresPortalegre = operadores
             .Where(p => p.DistritoNome == "Portalegre")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> operadoresPorto = operadores
             .Where(p => p.DistritoNome == "Porto")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            List<LucroClienteOperador> operadoresSantarem = operadores
             .Where(p => p.DistritoNome == "Santarém")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> operadoresSetubal = operadores
             .Where(p => p.DistritoNome == "Setúbal")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            List<LucroClienteOperador> operadoresVianadoCastelo = operadores
             .Where(p => p.DistritoNome == "Viana do Castelo")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> operadoresVilaReal = operadores
             .Where(p => p.DistritoNome == "Vila Real")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> operadoresViseu = operadores
             .Where(p => p.DistritoNome == "Viseu")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            List<LucroClienteOperador> operadoresAcores = operadores
             .Where(p => p.DistritoNome == "Açores")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> operadoresMadeira = operadores
             .Where(p => p.DistritoNome == "Madeira")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            Top10ViewModel top10operadores = new Top10ViewModel
            {
                operadoresAveiro = operadoresAveiro,
                operadoresBeja = operadoresBeja,
                operadoresBraga = operadoresBraga,
                operadoresBraganca = operadoresBraganca,
                operadoresCasteloBranco = operadoresCasteloBranco,
                operadoresCoimbra = operadoresCoimbra,
                operadoresEvora = operadoresEvora,
                operadoresFaro = operadoresFaro,
                operadoresGuarda = operadoresGuarda,
                operadoresLeiria = operadoresLeiria,
                operadoresLisboa = operadoresLisboa,
                operadoresPortalegre = operadoresPortalegre,
                operadoresPorto = operadoresPorto,
                operadoresSantarem = operadoresSantarem,
                operadoresSetubal = operadoresSetubal,
                operadoresVianadoCastelo = operadoresVianadoCastelo,
                operadoresVilaReal = operadoresVilaReal,
                operadoresViseu = operadoresViseu,
                operadoresAcores = operadoresAcores,
                operadoresMadeira = operadoresMadeira,

            };
            return View(top10operadores);
        }

        public async Task<IActionResult> Top10Clientes()
        {

            List<Utilizadores> clientesAntigos = await bd.Utilizadores
                .Where(p => p.Role == "Cliente")
                .OrderBy(p => p.DataAtivacao)
                .Take(10)
                .ToListAsync();

            List<LucroClienteOperador> clientes = new List<LucroClienteOperador>();
            decimal lucro = 0;
            foreach (var cliente in bd.Utilizadores)
            {
                if (cliente.Role == "Cliente")
                {
                    foreach (var contrato in bd.Contratos)
                    {
                        if (contrato.UtilizadorId == cliente.UtilizadorId)
                        {
                            lucro += contrato.PrecoFinal;
                        }
                    }
                    var distrito = await bd.Distritos
                        .FirstOrDefaultAsync(m => m.DistritosId == cliente.DistritosId);

                    clientes.Add(new LucroClienteOperador() { UtilizadorId = cliente.UtilizadorId, DistritosId = cliente.DistritosId, 
                        Lucro = lucro, ClienteNome = cliente.Nome, DistritoNome = distrito.Nome });
                    lucro = 0;
                }
            }

            var nomeDistrito1 = await bd.Distritos
                .FirstOrDefaultAsync(m => m.Nome == "Aveiro");
            var nomeDistrito2 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Beja");
            var nomeDistrito3 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Braga");
            var nomeDistrito4 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Bragança");
            var nomeDistrito5 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Castelo Branco");
            var nomeDistrito6 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Coimbra");
            var nomeDistrito7 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Évora");
            var nomeDistrito8 = await bd.Distritos
                .FirstOrDefaultAsync(m => m.Nome == "Faro");
            var nomeDistrito9 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Guarda");
            var nomeDistrito10 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Leiria");
            var nomeDistrito11 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Lisboa");
            var nomeDistrito12 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Portalegre");
            var nomeDistrito13 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Porto");
            var nomeDistrito14 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Santarém");
            var nomeDistrito15 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Setúbal");
            var nomeDistrito16 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Viana do Castelo");
            var nomeDistrito17 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Vila Real");
            var nomeDistrito18 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Viseu");
            var nomeDistrito19 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Açores");
            var nomeDistrito20 = await bd.Distritos
              .FirstOrDefaultAsync(m => m.Nome == "Madeira");

            ViewData["Aveiro"] = nomeDistrito1.Nome;
            ViewData["Beja"] = nomeDistrito2.Nome;
            ViewData["Braga"] = nomeDistrito3.Nome;
            ViewData["Braganca"] = nomeDistrito4.Nome;
            ViewData["CasteloBranco"] = nomeDistrito5.Nome;
            ViewData["Coimbra"] = nomeDistrito6.Nome;
            ViewData["Evora"] = nomeDistrito7.Nome;
            ViewData["Faro"] = nomeDistrito8.Nome;
            ViewData["Guarda"] = nomeDistrito9.Nome;
            ViewData["Leiria"] = nomeDistrito10.Nome;
            ViewData["Lisboa"] = nomeDistrito11.Nome;
            ViewData["Portalegre"] = nomeDistrito12.Nome;
            ViewData["Porto"] = nomeDistrito13.Nome;
            ViewData["Santarem"] = nomeDistrito14.Nome;
            ViewData["Setubal"] = nomeDistrito15.Nome;
            ViewData["Viana"] = nomeDistrito16.Nome;
            ViewData["VilaReal"] = nomeDistrito17.Nome;
            ViewData["Viseu"] = nomeDistrito18.Nome;
            ViewData["Acores"] = nomeDistrito19.Nome;
            ViewData["Madeira"] = nomeDistrito20.Nome;


            List<LucroClienteOperador> clientesAveiro = clientes
                .Where(p => p.DistritoNome == "Aveiro")
                .OrderByDescending(p => p.Lucro)
                .Take(10)
                .ToList();

            List<LucroClienteOperador> clientesBeja = clientes
             .Where(p => p.DistritoNome == "Beja")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> clientesBraga = clientes
             .Where(p => p.DistritoNome == "Braga")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            List<LucroClienteOperador> clientesBraganca = clientes
             .Where(p => p.DistritoNome == "Bragança")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            List<LucroClienteOperador> clientesCasteloBranco = clientes
             .Where(p => p.DistritoNome == "Castelo Branco")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> clientesCoimbra = clientes
             .Where(p => p.DistritoNome == "Coimbra")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            List<LucroClienteOperador> clientesEvora = clientes
             .Where(p => p.DistritoNome == "Évora")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> clientesFaro = clientes
             .Where(p => p.DistritoNome == "Faro")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> clientesGuarda = clientes
             .Where(p => p.DistritoNome == "Guarda")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            List<LucroClienteOperador> clientesLeiria = clientes
             .Where(p => p.DistritoNome == "Leiria")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            List<LucroClienteOperador> clientesLisboa = clientes
             .Where(p => p.DistritoNome == "Lisboa")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            List<LucroClienteOperador> clientesPortalegre = clientes
             .Where(p => p.DistritoNome == "Portalegre")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> clientesPorto = clientes
             .Where(p => p.DistritoNome == "Porto")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            List<LucroClienteOperador> clientesSantarem = clientes
             .Where(p => p.DistritoNome == "Santarém")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> clientesSetubal = clientes
             .Where(p => p.DistritoNome == "Setúbal")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            List<LucroClienteOperador> clientesVianadoCastelo = clientes
             .Where(p => p.DistritoNome == "Viana do Castelo")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> clientesVilaReal = clientes
             .Where(p => p.DistritoNome == "Vila Real")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> clientesViseu = clientes
             .Where(p => p.DistritoNome == "Viseu")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            List<LucroClienteOperador> clientesAcores = clientes
             .Where(p => p.DistritoNome == "Açores")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> clientesMadeira = clientes
             .Where(p => p.DistritoNome == "Madeira")
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            Top10ViewModel top10clientes = new Top10ViewModel
            {
                ClientesAntigos = clientesAntigos,
                clientesAveiro = clientesAveiro,
                clientesBeja = clientesBeja,
                clientesBraga = clientesBraga,
                clientesBraganca = clientesBraganca,
                clientesCasteloBranco = clientesCasteloBranco,
                clientesCoimbra = clientesCoimbra,
                clientesEvora = clientesEvora,
                clientesFaro = clientesFaro,
                clientesGuarda = clientesGuarda,
                clientesLeiria = clientesLeiria,
                clientesLisboa = clientesLisboa,
                clientesPortalegre = clientesPortalegre,
                clientesPorto = clientesPorto,
                clientesSantarem = clientesSantarem,
                clientesSetubal = clientesSetubal,
                clientesVianadoCastelo = clientesVianadoCastelo,
                clientesVilaReal = clientesVilaReal,
                clientesViseu = clientesViseu,
                clientesAcores = clientesAcores,
                clientesMadeira = clientesMadeira,

            };
            return View(top10clientes);
        }

        public async Task<IActionResult> VistaCliente()
        {

            var cliente = bd.Utilizadores.SingleOrDefault(c => c.Email == User.Identity.Name);
            int clienteId = cliente.UtilizadorId;

            ViewData["ClienteId"] = cliente.UtilizadorId;


            int distritoDoCliente = cliente.DistritosId;

            List<Utilizadores> clientesDoDistrito = await bd.Utilizadores
                .Where(p => p.Role == "Cliente" && p.DistritosId == distritoDoCliente)
                .ToListAsync();

            List<LucroClienteOperador> clientes = new List<LucroClienteOperador>();
            decimal lucro = 0;

            foreach (var item in clientesDoDistrito)
            {
                foreach (var contrato in bd.Contratos)
                {
                    if (contrato.UtilizadorId == item.UtilizadorId)
                    {
                        lucro += contrato.PrecoFinal;
                    }
                }
                var distrito = await bd.Distritos
                    .FirstOrDefaultAsync(m => m.DistritosId == item.DistritosId);

                clientes.Add(new LucroClienteOperador()
                {
                    UtilizadorId = item.UtilizadorId,
                    DistritosId = item.DistritosId,
                    Lucro = lucro,
                    ClienteNome = item.Nome,
                    DistritoNome = distrito.Nome
                });
                lucro = 0;
            }
        
            List<LucroClienteOperador> top10ComOCliente = clientes
                .OrderByDescending(p => p.Lucro)
                .Take(10)
                .ToList();

            var distritonome = await bd.Distritos
                    .FirstOrDefaultAsync(m => m.DistritosId == cliente.DistritosId);

            ViewData["Distrito"] = distritonome.Nome;

            int posicaoCliente = 0;

            foreach (var item in top10ComOCliente)
            {
                if(item.UtilizadorId == cliente.UtilizadorId)
                {
                    posicaoCliente = top10ComOCliente.IndexOf(item) + 1;
                }
            }

            ViewData["PosicaoCliente"] = posicaoCliente;


            Top10ViewModel top10clientes = new Top10ViewModel
            {
                vistaCliente = top10ComOCliente
            };

            return View(top10clientes);
        }
    
    }
}
