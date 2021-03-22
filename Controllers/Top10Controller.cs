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
    public class Top10Controller : Controller
    {
        private readonly Projeto_Lab_WebContext bd;

        public Top10Controller(Projeto_Lab_WebContext context)
        {
            bd = context;
        }

        public async Task<IActionResult> Top10Antigos()
        {
          
                List<Utilizadores> clientesAntigos = await bd.Utilizadores
                    .Where(p => p.Role == "Cliente")
                    .OrderByDescending(p => p.DataAtivacao)
                    .Take(10)
                    .ToListAsync();

            Top10ViewModel top10clientesAntigos = new Top10ViewModel
            {
                   Utilizadores  = clientesAntigos,
            };
                return View(top10clientesAntigos);
            }

        public async Task<IActionResult> Top10Operadores()
        {

            List<LucroClienteOperador> operadores = new List<LucroClienteOperador>();
            decimal lucro = 0;
            foreach(var operador in bd.Utilizadores)
            {
                if (operador.Role == "Operador")
                {
                    foreach (var contrato in bd.Contratos)
                    {
                        if (contrato.UtilizadorId == operador.UtilizadorId)
                        {
                            lucro += contrato.PrecoFinal;
                        }
                    }
                    operadores.Add(new LucroClienteOperador() { UtilizadorId = operador.UtilizadorId, DistritosId = operador.DistritosId, Lucro = lucro });
                    lucro = 0;
                }
            }

            List<LucroClienteOperador> operadoresAveiro = operadores
                .Where(p => p.DistritosId == 1)
                .OrderByDescending(p => p.Lucro)
                .Take(10)
                .ToList();

            List<LucroClienteOperador> operadoresBeja = operadores
             .Where(p => p.DistritosId == 2)
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> operadoresBraga = operadores
             .Where(p => p.DistritosId == 3)
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> operadoresBraganca = operadores
             .Where(p => p.DistritosId ==  4)
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            List<LucroClienteOperador> operadoresCasteloBranco = operadores
             .Where(p => p.DistritosId == 5)
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> operadoresCoimbra = operadores
             .Where(p => p.DistritosId == 6)
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            List<LucroClienteOperador> operadoresEvora = operadores
             .Where(p => p.DistritosId == 7)
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> operadoresFaro = operadores
             .Where(p => p.DistritosId == 8)
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> operadoresGuarda = operadores
             .Where(p => p.DistritosId == 9)
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            List<LucroClienteOperador> operadoresLeiria = operadores
             .Where(p => p.DistritosId == 10)
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();
                
            List<LucroClienteOperador> operadoresLisboa = operadores
             .Where(p => p.DistritosId == 11)
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            List<LucroClienteOperador> operadoresPortalegre = operadores
             .Where(p => p.DistritosId == 12)
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> operadoresPorto = operadores
             .Where(p => p.DistritosId == 13)
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            List<LucroClienteOperador> operadoresSantarem = operadores
             .Where(p => p.DistritosId == 14)
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> operadoresSetubal = operadores
             .Where(p => p.DistritosId == 15)
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            List<LucroClienteOperador> operadoresVianadoCastelo = operadores
             .Where(p => p.DistritosId == 16)
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> operadoresVilaReal = operadores
             .Where(p => p.DistritosId == 17)
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> operadoresViseu = operadores
             .Where(p => p.DistritosId == 18)
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            List<LucroClienteOperador> operadoresAcores = operadores
             .Where(p => p.DistritosId == 19)
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();


            List<LucroClienteOperador> operadoresMadeira = operadores
             .Where(p => p.DistritosId == 20)
             .OrderByDescending(p => p.Lucro)
             .Take(10)
             .ToList();

            Top10ViewModel top10clientesAntigos = new Top10ViewModel
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
            return View(top10clientesAntigos);
        }

    }
}
