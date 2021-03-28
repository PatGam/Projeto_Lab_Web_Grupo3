using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Projeto_Lab_Web_Grupo3.Models;
using Projeto_Lab_Web_Grupo3.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Controllers
{
    public class TesteEmail : Controller
    {
        private readonly IEmailSender _emailSender;

        public TesteEmail(IEmailSender emailSender, IWebHostEnvironment env)
        {
            _emailSender = emailSender;
        }

        public IActionResult EnviaEmail()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnviaEmail(EmailModel email)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TesteEnvioEmail(email.Destino, email.Assunto, email.Mensagem).GetAwaiter();
                    return RedirectToAction("EmailEnviado");
                }
                catch (Exception)
                {
                    return RedirectToAction("EmailFalhou");
                }
            }
            return View(email);
        }

        public async Task TesteEnvioEmail(string email, string assunto, string mensagem)
        {
            try
            {
                //email destino, assunto do email, mensagem a enviar
                await _emailSender.SendEmailAsync(email, assunto, mensagem);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult EmailEnviado()
        {
            return View();
        }

        public ActionResult EmailFalhou()
        {
            return View();
        }
    }
}
