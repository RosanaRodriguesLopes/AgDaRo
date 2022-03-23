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
    public class PromoçãoController : Controller
    {
        private readonly Context _context;

        public PromoçãoController(Context context)
        {
            _context = context;
        }

        // GET: Promoção
        public async Task<IActionResult> Index()
        {
            return View(await _context.promoções.ToListAsync());
        }

        // GET: Promoção/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoção = await _context.promoções
                .FirstOrDefaultAsync(m => m.Id_Promoção == id);
            if (promoção == null)
            {
                return NotFound();
            }

            return View(promoção);
        }

        // GET: Promoção/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Promoção/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Promoção,Desconto,Valor_Final")] Promoção promoção)
        {
            if (ModelState.IsValid)
            {
                _context.Add(promoção);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(promoção);
        }

        // GET: Promoção/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoção = await _context.promoções.FindAsync(id);
            if (promoção == null)
            {
                return NotFound();
            }
            return View(promoção);
        }

        // POST: Promoção/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Promoção,Desconto,Valor_Final")] Promoção promoção)
        {
            if (id != promoção.Id_Promoção)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(promoção);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PromoçãoExists(promoção.Id_Promoção))
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
            return View(promoção);
        }

        // GET: Promoção/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promoção = await _context.promoções
                .FirstOrDefaultAsync(m => m.Id_Promoção == id);
            if (promoção == null)
            {
                return NotFound();
            }

            return View(promoção);
        }

        // POST: Promoção/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var promoção = await _context.promoções.FindAsync(id);
            _context.promoções.Remove(promoção);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PromoçãoExists(int id)
        {
            return _context.promoções.Any(e => e.Id_Promoção == id);
        }
    }
}
