using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Manage.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_Lab_Web_Grupo3.Data
{
    public class EnvioEmails
    {
        private readonly Projeto_Lab_WebContext bd;

        public EnvioEmails(Projeto_Lab_WebContext context)
        {
            bd = context;
        }

        private readonly IEmailSender _emailSender;

        public EnvioEmails(Projeto_Lab_WebContext context, IEmailSender emailSender)
        {
            bd = context;
            _emailSender = emailSender;
        }


        public async Task TesteEnvioEmail(string email, string assunto, string mensagem)
        {
            foreach(var item in bd.Contratos)
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
           
        }
    }
}
