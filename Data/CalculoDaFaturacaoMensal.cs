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
            if (bd.FaturacaoOperadores.Any()) return;

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
                            faturacaoOperadores.Add(new FaturacaoOperadores() { UtilizadorId = operador.UtilizadorId, TotalFaturacao = lucromensal, Mes = mes, Ano = ano, NomeMes = NomesDoMes(mes) });
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

        internal static string NomesDoMes(int mes)
        {
            string NomedoMes = "";
            switch (mes)
            {
                case 1:
                    NomedoMes = "Janeiro";
                    break;
                case 2:
                    NomedoMes = "Fevereiro";
                    break;
                case 3:
                    NomedoMes = "Março";
                    break;
                case 4:
                    NomedoMes = "Abril";
                    break;
                case 5:
                    NomedoMes = "Maio";
                    break;
                case 6:
                    NomedoMes = "Junho";
                    break;
                case 7:
                    NomedoMes = "Julho";
                    break;
                case 8:
                    NomedoMes = "Agosto";
                    break;
                case 9:
                    NomedoMes = "Setembro";
                    break;
                case 10:
                    NomedoMes = "Outubro";
                    break;
                case 11:
                    NomedoMes = "Novembro";
                    break;
                case 12:
                    NomedoMes = "Dezembro";
                    break;
                
                default:
                    break;
            }

            return NomedoMes;
        }

    }
}
