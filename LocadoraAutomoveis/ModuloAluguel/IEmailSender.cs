
using System.Net.Mail;

namespace LocadoraAutomoveis.Dominio.ModuloAluguel
{
    public interface IEmailSender
    {
        public string from { get; }
        public string password { get; }
        public void SendEmail(string email, string title = "", string message = "", Attachment att = null);
        public SmtpClient Configuration();

    }
}
