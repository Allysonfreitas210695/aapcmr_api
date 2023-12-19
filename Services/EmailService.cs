using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using api_aapcmr.Config;
using api_aapcmr.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api_aapcmr.Services
{
    public class EmailService : IEmailService
    {
        private readonly ApiContext _dbContext;
        public EmailService(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SendEmailAsync(string emailDestino, string subject, string body)
        {
            try
            {
                var smtpClient = new SmtpClient("sandbox.smtp.mailtrap.io")
                {
                    Port = 2525,
                    Credentials = new NetworkCredential("6781038d2c2806", "47a68293b0b54e"),
                    EnableSsl = true, // Alterado para true para usar SSL
                };

                // Conteúdo do e-mail
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("allyson.fernandes@alunos.ufersa.edu.br"),
                    Subject = subject,
                    Body = body
                };
                mailMessage.To.Add(emailDestino);

                // Enviar e-mail
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex?.InnerException?.Message ?? ex.Message);
            }
        }


    }
}