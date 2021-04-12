using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Projeto_Lab_Web_Grupo3.Models;
using Projeto_Lab_Web_Grupo3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Projeto_Lab_Web_Grupo3.Data;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Projeto_Lab_Web_Grupo3.Controllers
{
    public class AdminOpController : Controller
    {

        private readonly Projeto_Lab_WebContext bd;
        private readonly IEmailSender _emailSender;
        

        public AdminOpController(IEmailSender emailSender, IWebHostEnvironment env, Projeto_Lab_WebContext context)
        {
            bd = context;
            _emailSender = emailSender;
           
        }


        public async Task<IActionResult> Index()
        {

            var contratos = await bd.Contratos.ToListAsync();
            var emailenviado = await bd.EnvioDeFaturas.ToListAsync();

            DateTime hoje = DateTime.Today;
            DateTime mespassado = hoje.AddMonths(-1);
            int mes = mespassado.Month;
            int ano = mespassado.Year;

            bool enviado = false;

            foreach (var item in emailenviado)
            {
                if (item.mes == mes && item.ano==ano)
                {
                    enviado = true;
                }
                else
                {
                    enviado = false;
                }
            }

            if(enviado==false)
            {
                string email; string assunto; string mensagem;
                foreach (var item in bd.Contratos)
      
                {
                    var cliente = await bd.Utilizadores.FirstOrDefaultAsync(m => m.UtilizadorId == item.UtilizadorId);
                    decimal preco = item.PrecoFinal;
                    email = cliente.Email;

                    string NomeMes = NomesDoMes(mes);
                    assunto = "Faturação RD Telecom";
                    mensagem = "Caro/a cliente, informamos que tem a pagar " + preco + "€ da fatura de " + NomeMes + ". Obrigado pela sua preferência!";

                    try
                    {
                        //email destino, assunto do email, mensagem a enviar
                        await _emailSender.SendEmailAsync(email, assunto, mensagem);

                        enviado = true;
                    }
                    catch (Exception)
                    {
                        enviado = false;
                    }
                }

                emailenviado.Add(new EnvioDeFaturas() { DataDeEnvio = DateTime.Today, Enviado = true, mes = mes, ano = ano });
                foreach (var item in emailenviado)
                {
                    bd.EnvioDeFaturas.Add(item);
                }
                await bd.SaveChangesAsync();

            }

            List<InfoPacoteViewModel> ListaPacotes = new List<InfoPacoteViewModel>();

            foreach (var pacote in bd.Pacotes)
            {
                InfoPacoteViewModel infoPacote = new InfoPacoteViewModel();

                infoPacote.Pacote = pacote;

                infoPacote.Promocao = await bd.PromocoesPacotes
                    .Include(p => p.Promocoes)
                    .Where(p => p.PacoteId == pacote.PacoteId)
                    .Select(p => p.Promocoes)
                    .Where(p => p.DataInicio < DateTime.Now && p.DataFim > DateTime.Now)
                    .FirstOrDefaultAsync();

                infoPacote.Servicos = await bd.ServicosPacotes
                    .Include(p => p.Servico)
                    .Where(p => p.PacoteId == pacote.PacoteId)
                    .Select(p => p.Servico)
                    .ToListAsync();

                foreach(var item in infoPacote.Servicos)
                {
                    infoPacote.TiposServicos = await bd.Servicos
                    .Include(p => p.TipoServicos)
                    .Where(p => p.ServicoId == item.ServicoId)
                    .Select(p => p.TipoServicos)
                    .ToListAsync();
                }
                

                ListaPacotes.Add(infoPacote);
            }

            var Funcionarios = bd.Utilizadores.Where(p => p.Role != "Cliente").ToList();
            int contagemFunc = Funcionarios.Count();

            var Clientes = bd.Utilizadores.Where(p => p.Role == "Cliente").ToList();
            int contagemClientes = Clientes.Count();

            var Contratos = bd.Contratos.ToList();
            int contagemContratos = Contratos.Count();

            var Reclamacoes = bd.Reclamacoes.Where(r =>r.Inactivo == false).ToList();
            int contagemReclamacoes = Reclamacoes.Count();

            var Reclamacoes1 = bd.Reclamacoes.Where(r => r.Inactivo == true).ToList();
            int reclamacoesfechadas = Reclamacoes1.Count();
           

            decimal receita = 0;
            foreach (var item in Contratos)
            {
                receita += item.PrecoFinal;
            }


            if (User.IsInRole("Operador"))
            {
                var funcionario = bd.Utilizadores.SingleOrDefault(c => c.Email == User.Identity.Name);


                List<Contratos> MeusContratos = await bd.Contratos
                    .Where(p => p.FuncionarioId == funcionario.UtilizadorId)
                    .ToListAsync();
                int contagemMeusContratos = MeusContratos.Count();


                //DateTime now = DateTime.Now;
                //var startDate = new DateTime(now.Year, now.Month, 1);
                //var endDate = startDate.AddMonths(1).AddDays(-1);
                decimal faturacao = 0;
                foreach (var item in MeusContratos)
                {
                    
                    faturacao += item.PrecoFinal;

                }
                ViewData["faturacao"] = faturacao;
                ViewData["Meuscontratos"] = contagemMeusContratos;

            }


            HomeGestaoViewModel modelo = new HomeGestaoViewModel
            {
                enviado = enviado,
                Pacotes = ListaPacotes,
            };
            
            ViewData["clientes"] = contagemClientes;
            ViewData["contratos"] = contagemContratos;
            ViewData["receita"] = receita;
            ViewData["func"] = contagemFunc;
            ViewData["reclamacoes"] = contagemReclamacoes;
            ViewData["reclamacoesfechadas"] = reclamacoesfechadas;


            return View(modelo);
        }

        public async Task<IActionResult> ContaPessoal(int ano)
        {
            DateTime hoje = DateTime.Today;
            int anoCorrente = hoje.Year;
            if (ano == 0)
            {
                ano = anoCorrente;
            }
            var funcionario = bd.Utilizadores.SingleOrDefault(c => c.Email == User.Identity.Name);

            List<FaturacaoOperadores> faturacaoDoOperador = await bd.FaturacaoOperadores
                .Where(p => p.UtilizadorId == funcionario.UtilizadorId)
                .OrderBy(p => p.Ano)
                .ThenBy(p => p.Mes)
                .ToListAsync();

            var PrimeiroContrato = faturacaoDoOperador.First();
            int PrimeiroAno = PrimeiroContrato.Ano;

            List<int> Anos = new List<int>();
            for (int i = PrimeiroAno; i <= anoCorrente; i++)
            {
                Anos.Add(i);
            }

            ViewData["Anos"] = new SelectList(Anos);

            List<FaturacaoOperadores> faturacaoDoOperadorPorAno = await bd.FaturacaoOperadores
                .Where(p => p.UtilizadorId == funcionario.UtilizadorId && p.Ano == ano)
                .OrderBy(p => p.Ano)
                .ThenBy(p=> p.Mes)
                .ToListAsync();

            ViewData[ "PrimeiroAno"] = faturacaoDoOperador[0].Ano;
            ViewData["AnoCorrente"] = DateTime.Now.Year;

            var distrito = bd.Distritos.SingleOrDefault(c => c.DistritosId == funcionario.DistritosId);


            FaturacaoMensalViewModel faturacaoMensalViewModel = new FaturacaoMensalViewModel
            {
                distrito = distrito,
                funcionario = funcionario,
                faturacaoOperadores = faturacaoDoOperadorPorAno,
                ano = ano
            };

            return View(faturacaoMensalViewModel);
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
