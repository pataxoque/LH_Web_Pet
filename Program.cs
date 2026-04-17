using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using LH_PET_WEB.Data;
using LH_PET_WEB.Services;

var builder = WebApplication.CreateBuilder(args);

// 1. Configura o Banco de Dados (MySQL via Pomelo)
var conexao = builder.Configuration.GetConnectionString("ConexaoPadrao");
builder.Services.AddDbContext<ContextoBanco>(options =>
    options.UseMySql(conexao, ServerVersion.AutoDetect(conexao)));

// 2. Configura a Autenticação por Cookies (Para o navegador lembrar o login)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Autenticacao/Login";
        options.AccessDeniedPath = "/Autenticacao/AcessoNegado";
    });

// 3. Registra o Serviço de E-mail (Injeção de Dependência)
builder.Services.AddScoped<IEmailService, EmailService>();

// 4. Configura os Controllers e Views
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurações de erro e segurança
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Ativa a Autenticação e Autorização (IMPORTANTE)
app.UseAuthentication();
app.UseAuthorization();

// Define a rota padrão de inicialização
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Autenticacao}/{action=Login}/{id?}");

app.Run();