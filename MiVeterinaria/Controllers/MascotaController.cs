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

        [HttpGet]
        public IActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Nuevo(Mascota mascota)
        {
            await _appDBContext.Mascotas.AddAsync(mascota);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof (Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            Mascota mascota = await _appDBContext.Mascotas.FirstAsync(e => e.IdMascota == id);
            return View(mascota);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Mascota mascota)
        {
             _appDBContext.Mascotas.Update(mascota);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(int id)
        {
            Mascota mascota = await _appDBContext.Mascotas.FirstAsync(e => e.IdMascota == id);
            _appDBContext.Mascotas.Remove(mascota);
            await _appDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Lista));
         }

    }
}
