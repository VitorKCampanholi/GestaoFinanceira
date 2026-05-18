using GestaoFinanceira.Data;
using GestaoFinanceira.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.Net.Mail;

namespace GestaoFinanceira.libraries.Email
{
    public class EmailSender(ILogger<EmailSender> logger, IConfiguration configuration, SmtpClient smtp) : IEmailSender<ApplicationUser>
    {
        private readonly ILogger logger = logger;
        private readonly SmtpClient smtp = smtp;

        public Task SendConfirmationLinkAsync(ApplicationUser user, string email,
            string confirmationLink) => SendEmailAsync(email, "Confirme seu E-mail",
            "<html lang=\"pt-br\"><head></head><body>Por favor confirme seu cadastro clicando no link " +
            $"<a href='{confirmationLink}'>Confirme</a>.</body></html>");

        public Task SendPasswordResetLinkAsync(ApplicationUser user, string email,
            string resetLink) => SendEmailAsync(email, "Resetar senha",
            "<html lang=\"pt-br\"><head></head><body>Clique no link e resete sua senha " +
            $"<a href='{resetLink}'>Resetar senha</a>.</body></html>");

        public Task SendPasswordResetCodeAsync(ApplicationUser user, string email,
            string resetCode) => SendEmailAsync(email, "Resetar senha",
            "<html lang=\"pt-br\"><head></head><body>Por favor redefina sua senha " +
            $"usando o seguinte código:<br>{resetCode}</body></html>");

        public async Task SendEmailAsync(string toEmail, string subject, string message)
        {
            await Execute(subject, message, toEmail);
        }

        public async Task Execute(string subject, string message, string toEmail)
        {

            var mailMessage = new MailMessage();

            mailMessage.From = new MailAddress(configuration.GetValue<string>("EmailSender:User")!);
            mailMessage.Subject = subject;
            mailMessage.To.Add(new MailAddress(toEmail));
            mailMessage.Body = message;
            mailMessage.IsBodyHtml = true;

            await smtp.SendMailAsync(mailMessage);

            logger.LogInformation("E-mail para {EmailAddress} enviado!", toEmail);
        }
    }

}
