using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LH_PET_WEB.Data;
using LH_PET_WEB.Models;
using Microsoft.AspNetCore.Authorization;

namespace LH_PET_WEB.Controllers
{
    [Authorize]
    public class PetController : Controller
    {
        private readonly ContextoBanco _contexto;

        public PetController(ContextoBanco contexto)
        {
            _contexto = contexto;
        }

        public async Task<IActionResult> Index()
        {
            // O .Include(p => p.Cliente) serve para trazer o nome do dono junto com o pet
            var pets = await _contexto.Pets.Include(p => p.Cliente).ToListAsync();
            return View(pets);
        }

        public async Task<IActionResult> Criar()
        {
            // Cria a lista de seleção de donos para o formulário
            ViewBag.ClienteId = new SelectList(await _contexto.Clientes.ToListAsync(), "Id", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar(Pet model)
        {
            if (ModelState.IsValid)
            {
                _contexto.Add(model);
                await _contexto.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ClienteId = new SelectList(await _contexto.Clientes.ToListAsync(), "Id", "Nome", model.ClienteId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Excluir(int id)
        {
            var pet = await _contexto.Pets.FindAsync(id);
            if (pet != null)
            {
                _contexto.Pets.Remove(pet);
                await _contexto.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}