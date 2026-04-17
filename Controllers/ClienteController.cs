using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LH_PET_WEB.Data;
using LH_PET_WEB.Models;
using Microsoft.AspNetCore.Authorization;

namespace LH_PET_WEB.Controllers
{
    [Authorize] // Bloqueia acesso de pessoas não logadas
    public class ClienteController : Controller
    {
        private readonly ContextoBanco _contexto;

        public ClienteController(ContextoBanco contexto)
        {
            _contexto = contexto;
        }

        // TELA 1: LISTA DE CLIENTES
        public async Task<IActionResult> Index()
        {
            var lista = await _contexto.Clientes.OrderBy(c => c.Nome).ToListAsync();
            return View(lista);
        }

        // TELA 2: FORMULÁRIO DE CADASTRO
        public IActionResult Criar() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Cliente model)
        {
            if (ModelState.IsValid)
            {
                // Verifica se o CPF já existe para evitar duplicidade
                if (await _contexto.Clientes.AnyAsync(c => c.Cpf == model.Cpf))
                {
                    ModelState.AddModelError("Cpf", "Este CPF já está cadastrado no sistema.");
                    return View(model);
                }

                _contexto.Add(model);
                await _contexto.SaveChangesAsync();
                TempData["Sucesso"] = "Cliente cadastrado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // TELA 3: FORMULÁRIO DE EDIÇÃO
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null) return NotFound();
            var cliente = await _contexto.Clientes.FindAsync(id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Cliente model)
        {
            if (id != model.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _contexto.Update(model);
                    await _contexto.SaveChangesAsync();
                    TempData["Sucesso"] = "Dados atualizados!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(model.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // AÇÃO: EXCLUIR (Botão direto da lista)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(int id)
        {
            var cliente = await _contexto.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _contexto.Clientes.Remove(cliente);
                await _contexto.SaveChangesAsync();
                TempData["Sucesso"] = "Cliente removido.";
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id) => _contexto.Clientes.Any(e => e.Id == id);
    }
}