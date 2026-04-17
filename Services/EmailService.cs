using System.Net;
using System.Net.Mail;

namespace LH_PET_WEB.Services
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuracao;
        public EmailService(IConfiguration configuracao) => _configuracao = configuracao;

        public async Task<bool> EnviarEmailAsync(string destinatario, string assunto, string mensagem)
        {
            try {
                string servidor = _configuracao["SmtpConfig:Servidor"] ?? "smtp.office365.com";
                int porta = int.Parse(_configuracao["SmtpConfig:Porta"] ?? "587");
                string remetente = _configuracao["SmtpConfig:Usuario"] ?? "";
                string senha = _configuracao["SmtpConfig:Senha"] ?? "";

                using var correio = new MailMessage();
                correio.From = new MailAddress(remetente, "VetPlus Care");
                correio.To.Add(destinatario);
                correio.Subject = assunto;
                correio.Body = mensagem;
                correio.IsBodyHtml = true; // CORREÇÃO CONFORME PDF

                using var clienteSmtp = new SmtpClient(servidor, porta);
                clienteSmtp.Credentials = new NetworkCredential(remetente, senha);
                clienteSmtp.EnableSsl = true;
                await clienteSmtp.SendMailAsync(correio);
                return true;
            } catch { return false; }
        }
    }
}