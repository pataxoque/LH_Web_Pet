using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using LH_PET_WEB.Data;
using LH_PET_WEB.Models;
using LH_PET_WEB.Services;

namespace LH_PET_WEB.Controllers
{
    public class AutenticacaoController : Controller
    {
        private readonly ContextoBanco _contexto;
        private readonly IEmailService _emailService;

        public AutenticacaoController(ContextoBanco contexto, IEmailService emailService)
        {
            _contexto = contexto;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string email, string senha)
        {
            var usuario = _contexto.Usuarios.FirstOrDefault(u => u.Email == email && u.Ativo);

            if (usuario != null && BCrypt.Net.BCrypt.Verify(senha, usuario.SenhaHash))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Nome),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.Perfil)
                };

                var identidade = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                    new ClaimsPrincipal(identidade));

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Erro = "Usuário ou senha incorretos.";
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}