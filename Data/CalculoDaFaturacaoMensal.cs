using Microsoft.EntityFrameworkCore;
using Projeto_Lab_Web_Grupo3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Data
{
    public class CalculoDaFaturacaoMensal
    {
        internal async static void CalculoFaturacaoOperadores(Projeto_Lab_WebContext bd)
        {
            List<Contratos> contratos = await bd.Contratos
                .OrderBy(p => p.DataInicio)
                .ToListAsync();

            List<Utilizadores> operadores = await bd.Utilizadores
                .Where( p => p.Role == "Operador")
                .ToListAsync();
            DateTime primeirocontrato = contratos[0].DataInicio;

            var primeiromes = new DateTime(primeirocontrato.Year, primeirocontrato.Month, 1);
            var segundomes = primeiromes.AddMonths(1);
            var ultimodiaprimeirmes = segundomes.AddDays(-1);

            List<FaturacaoOperadores> faturacaoOperadores = new List<FaturacaoOperadores>();
            decimal lucromensal = 0;
            foreach(var operador in operadores)
            {
                foreach (var contrato in contratos)
                {
                    if(contrato.FuncionarioId == operador.UtilizadorId)
                    {
                        if (contrato.DataInicio >= primeiromes && contrato.DataInicio <= ultimodiaprimeirmes)
                        {
                            lucromensal += contrato.PrecoFinal;
                        }
                    }
                }
                faturacaoOperadores.Add(new FaturacaoOperadores() { UtilizadorId = operador.UtilizadorId, TotalFaturacao = lucromensal, Mes = 1, NomeMes = "Janeiro" });
                lucromensal = 0;
            }
           
        }
    }
}
