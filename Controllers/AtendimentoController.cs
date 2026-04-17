using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LH_PET_WEB.Data;
using LH_PET_WEB.Models;
using Microsoft.AspNetCore.Authorization;

namespace LH_PET_WEB.Controllers
{
    [Authorize]
    public class AtendimentoController : Controller
    {
        private readonly ContextoBanco _contexto;

        public AtendimentoController(ContextoBanco contexto)
        {
            _contexto = contexto;
        }

        // LISTA DE ATENDIMENTOS REALIZADOS
        public async Task<IActionResult> Index()
        {
            var atendimentos = await _contexto.Atendimentos
                .Include(a => a.Agendamento)
                .ThenInclude(ag => ag!.Pet)
                .OrderByDescending(a => a.Id)
                .ToListAsync();
            return View(atendimentos);
        }

        // TELA PARA CRIAR NOVO ATENDIMENTO (Vindo de um Agendamento)
        public async Task<IActionResult> Criar(int agendamentoId)
        {
            var agendamento = await _contexto.Agendamentos
                .Include(a => a.Pet)
                .FirstOrDefaultAsync(a => a.Id == agendamentoId);

            if (agendamento == null) return NotFound();

            var atendimento = new Atendimento 
            { 
                AgendamentoId = agendamentoId,
                Agendamento = agendamento
            };

            return View(atendimento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Atendimento model)
        {
            if (ModelState.IsValid)
            {
                // Salva o atendimento
                _contexto.Add(model);
                
                // Atualiza o status do agendamento para "Concluído"
                var agendamento = await _contexto.Agendamentos.FindAsync(model.AgendamentoId);
                if (agendamento != null) agendamento.Status = "Concluído";

                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
    }
}