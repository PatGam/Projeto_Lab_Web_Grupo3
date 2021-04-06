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
        internal static void CalculoFaturacaoOperadores(Projeto_Lab_WebContext bd)
        {
            List<Contratos> contratos = new List<Contratos>();

            List<Utilizadores> operadores = new List<Utilizadores>();


            foreach (var item in bd.Contratos)
            {
                contratos.Add(item);
            }

            foreach (var item in bd.Utilizadores)
            {
                if(item.Role =="Operador")
                operadores.Add(item);
            }

            List<Contratos> contratosOrdenados = contratos
                .OrderBy(p => p.DataInicio)
                .ToList();


            DateTime primeirocontrato = contratosOrdenados[0].DataInicio;
            DateTime hoje = DateTime.Today;

            List<FaturacaoOperadores> faturacaoOperadores = new List<FaturacaoOperadores>();

            int primeiroano = primeirocontrato.Year;
            int anocorrente = hoje.Year;

            decimal lucromensal = 0;

            foreach (var operador in operadores)
            {
                    for (int ano = primeiroano; ano <= anocorrente; ano++)
                    {
                        for (int mes = 1; mes <= 12; mes++)
                        {
                            DateTime primeirodia = new DateTime(ano, mes, 1);
                            DateTime ultimodia = new DateTime();

                            try
                            {
                                ultimodia = new DateTime(ano, mes, 31);
                            }
                            catch (Exception)
                            {
                                try
                                {
                                    ultimodia = new DateTime(ano, mes, 30);
                                }
                                catch (Exception)
                                {
                                    try
                                    {
                                        ultimodia = new DateTime(ano, mes, 29);
                                    }
                                    catch (Exception)
                                    {

                                        ultimodia = new DateTime(ano, mes, 28); ;
                                    }

                                }

                            }
                            foreach (var contrato in contratos)
                            {
                                if (contrato.DataInicio >= primeirodia && contrato.DataInicio <= ultimodia)
                                {
                                        if (contrato.FuncionarioId == operador.UtilizadorId)
                                        {
                                            lucromensal += contrato.PrecoFinal;
                                        }

                                }
                            }
                            faturacaoOperadores.Add(new FaturacaoOperadores() { UtilizadorId = operador.UtilizadorId, TotalFaturacao = lucromensal, Mes = mes, Ano = ano });
                            lucromensal = 0;
                        }

                    }
                }
            
                    

            foreach (var item in faturacaoOperadores)
            {
                bd.FaturacaoOperadores.Add(item);

            }
            bd.SaveChanges();

        }
    }
}
