using Microsoft.AspNetCore.Mvc;
using MiVeterinaria.Data;
using MiVeterinaria.Models;
using Microsoft.EntityFrameworkCore;

namespace MiVeterinaria.Controllers
{
    public class MascotaController : Controller
    {
        private readonly AppDBContext _appDBContext;
        public MascotaController(AppDBContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        [HttpGet]
        public async Task<IActionResult> Lista()
        {
            List<Mascota> lista = await _appDBContext.Mascotas.ToListAsync();
            return View(lista);
        }
    }
}
