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
    public class TesteEmail : Controller
    {
        private readonly IEmailSender _emailSender;
        private readonly Projeto_Lab_WebContext bd;

        

        public TesteEmail(IEmailSender emailSender, IWebHostEnvironment env, Projeto_Lab_WebContext context)
        {
            _emailSender = emailSender;
            bd = context;
            
        }

        public IActionResult EnviaEmail()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult EnviaEmail(EmailModel email)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            TesteEnvioEmail(email.Destino, email.Assunto, email.Mensagem).GetAwaiter();
        //            return RedirectToAction("EmailEnviado");
        //        }
        //        catch (Exception)
        //        {
        //            return RedirectToAction("EmailFalhou");
        //        }
        //    }
        //    return View(email);
        //}

        public async Task<IActionResult> TesteEnvioEmail()
        {
            var contratos = await bd.Contratos.ToListAsync();
            string email; string assunto; string mensagem;
            for (int i = 0; i < 10; i++)
            {
                //var cliente = await bd.Utilizadores.FirstOrDefaultAsync(m => m.UtilizadorId == item.UtilizadorId);
                decimal preco = 20;
                //decimal preco = item.PrecoFinal;
                //email = cliente.Email;
                email = "patriciaimpressoes@gmail.com";
                DateTime hoje = DateTime.Today;
                DateTime mespassado = hoje.AddMonths(-1);
                int mes = mespassado.Month;
                string NomeMes = NomesDoMes(mes);

                assunto = "Faturação RD Telecom";
                mensagem = "Caro/a cliente, informamos que tem a pagar " + preco + "€ da fatura do mês " + NomeMes + ". Obrigado pela sua preferência!";

                try
                {
                    //email destino, assunto do email, mensagem a enviar
                    await _emailSender.SendEmailAsync(email, assunto, mensagem);


                }
                catch (Exception)
                {
                    return RedirectToAction("EmailFalhou");
                }
            }

            return RedirectToAction("EmailEnviado");



        }

        public ActionResult EmailEnviado()
        {
            return View();
        }

        public ActionResult EmailFalhou()
        {
            return View();
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
