namespace LH_PET_WEB.Services
{
    public interface IEmailService
    {
        Task<bool> EnviarEmailAsync(string destinatario, string assunto, string mensagem);
    }
}