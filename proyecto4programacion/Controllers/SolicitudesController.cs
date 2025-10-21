using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using proyecto4programacion.Data;
using proyecto4programacion.Entities;

namespace proyecto4programacion.Controllers
{
    public class SolicitudesController : Controller
    {
        private readonly PrometeoContext _context;

        public SolicitudesController(PrometeoContext context)
        {
            _context = context;
        }

        // GET: Inicio de sección
        public async Task<IActionResult> Index()
        {
            return View(await _context.Solicitudes.ToListAsync());
        }

        // GET: Solicitudes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitudes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solicitud == null)
            {
                return NotFound();
            }

            return View(solicitud);
        }

        // GET: Pagina de nueva Solicitud (carga de datos)
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Creación de nueva Solicitud (recibo de datos)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FechaInicio,FechaCierre,ActivoId,ColaboradorId")] Solicitud solicitud)
        {
            solicitud.ReferenteId = 1;  //Referente generico
            solicitud.EstadoId = 1;     // Estado: Pendiente
            solicitud.FechaCreacion = DateOnly.FromDateTime(DateTime.Now);

            if (ModelState.IsValid)
            {
                _context.Add(solicitud);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(solicitud);
        }

        // GET: Pagina de edición de Solicitud
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitudes.FindAsync(id);
            if (solicitud == null)
            {
                return NotFound();
            }
            return View(solicitud);
        }

        // POST: Actualizacion de datos recibida
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FechaInicio,FechaCierre,ColaboradorId,ActivoId,Id,EstadoId,FechaCreacion,ReferenteId")] Solicitud solicitud)
        {
            if (id != solicitud.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(solicitud);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SolicitudExists(solicitud.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(solicitud);
        }

        // GET: Confirmación de Eliminar registro
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var solicitud = await _context.Solicitudes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (solicitud == null)
            {
                return NotFound();
            }

            return View(solicitud);
        }

        // POST: Eliminar registro 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var solicitud = await _context.Solicitudes.FindAsync(id);
            if (solicitud != null)
            {
                _context.Solicitudes.Remove(solicitud);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SolicitudExists(int id)
        {
            return _context.Solicitudes.Any(e => e.Id == id);
        }
    }
}
