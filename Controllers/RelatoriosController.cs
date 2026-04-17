using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LH_PET_WEB.Data;
using Microsoft.AspNetCore.Authorization;

namespace LH_PET_WEB.Controllers
{
    [Authorize(Roles = "Admin")] // Só administradores entram aqui
    public class RelatoriosController : Controller
    {
        private readonly ContextoBanco _contexto;

        public RelatoriosController(ContextoBanco contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            var hoje = DateTime.Today;
            var primeiroDiaMes = new DateTime(hoje.Year, hoje.Month, 1);

            // Cálculo de faturamento total do mês atual
            var faturamentoMes = await _contexto.Vendas
                .Where(v => v.DataVenda >= primeiroDiaMes)
                .SumAsync(v => v.Total);

            // Quantidade de atendimentos realizados no mês
            var totalAtendimentos = await _contexto.Atendimentos
                .Include(a => a.Agendamento)
                .Where(a => a.Agendamento!.DataHora >= primeiroDiaMes)
                .CountAsync();

            // Manda os dados para a View através da ViewBag
            ViewBag.FaturamentoMes = faturamentoMes;
            ViewBag.TotalAtendimentos = totalAtendimentos;

            return View();
        }
    }
}