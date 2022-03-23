using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgDeViagem.Models;

namespace AgDeViagem.Controllers
{
    public class PassagemsController : Controller
    {
        private readonly Context _context;

        public PassagemsController(Context context)
        {
            _context = context;
        }

        // GET: Passagems
        public async Task<IActionResult> Index()
        {
            return View(await _context.passagens.ToListAsync());
        }

        // GET: Passagems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passagem = await _context.passagens
                .FirstOrDefaultAsync(m => m.Id_Passagem == id);
            if (passagem == null)
            {
                return NotFound();
            }

            return View(passagem);
        }

        // GET: Passagems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Passagems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Passagem,Destino,Data_Ida,Data_Volta,Valor,Id_Contato,Id_Promoção")] Passagem passagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(passagem);
        }

        // GET: Passagems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passagem = await _context.passagens.FindAsync(id);
            if (passagem == null)
            {
                return NotFound();
            }
            return View(passagem);
        }

        // POST: Passagems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Passagem,Destino,Data_Ida,Data_Volta,Valor,Id_Contato,Id_Promoção")] Passagem passagem)
        {
            if (id != passagem.Id_Passagem)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassagemExists(passagem.Id_Passagem))
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
            return View(passagem);
        }

        // GET: Passagems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var passagem = await _context.passagens
                .FirstOrDefaultAsync(m => m.Id_Passagem == id);
            if (passagem == null)
            {
                return NotFound();
            }

            return View(passagem);
        }

        // POST: Passagems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var passagem = await _context.passagens.FindAsync(id);
            _context.passagens.Remove(passagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PassagemExists(int id)
        {
            return _context.passagens.Any(e => e.Id_Passagem == id);
        }
    }
}
