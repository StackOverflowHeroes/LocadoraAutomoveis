using System.Net.Mail;
using LocadoraAutomoveis.Dominio.ModuloAluguel;

namespace LocadoraAutomovel.Infra.Email
{
    public class LocadoraAutomovelEmEmail : IEmailSender
    {
        public string from { get => "stackoverflowheroes@gmail.com"; }
        public string password { get => "nvsmjktpgafpuste"; }

        public SmtpClient smtp;

        public LocadoraAutomovelEmEmail()
        {
            smtp = Configuration();
        }
        public void SendEmail(string email, string title="", string message="", Attachment att = null)
        {
            MailMessage emailMessage = new MailMessage();
            emailMessage.From = new MailAddress(from);
            emailMessage.Subject = title;
            emailMessage.To.Add(new MailAddress(email));
            emailMessage.Body = $"<html><body>{message}</body></html>";
            emailMessage.IsBodyHtml = true;

            if (att != null)
                emailMessage.Attachments.Add(att);

            smtp.Send(emailMessage);

        }

        public SmtpClient Configuration()
        {
            var smtpClient = new SmtpClient()
            {
                Host = "smtp.gmail.com",
                Credentials = new System.Net.NetworkCredential(from, password),
                Port = 587,
                EnableSsl = true
            };

            return smtpClient;
        }
    }
}