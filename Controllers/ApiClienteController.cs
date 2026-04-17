using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LH_PET_WEB.Data;
using LH_PET_WEB.Models;

namespace LH_PET_WEB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiClienteController : ControllerBase
    {
        private readonly ContextoBanco _contexto;

        public ApiClienteController(ContextoBanco contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _contexto.Clientes.ToListAsync();
        }
    }
}