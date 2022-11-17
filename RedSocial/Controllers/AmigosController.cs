using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RedSocial.Data;
using RedSocial.Models;

namespace RedSocial.Controllers
{
    public class AmigosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AmigosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Amigos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Amigos.ToListAsync());
        }

        // GET: Amigos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amigos = await _context.Amigos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (amigos == null)
            {
                return NotFound();
            }

            return View(amigos);
        }

        // GET: Amigos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Amigos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id")] Amigos amigos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(amigos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(amigos);
        }

        // GET: Amigos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amigos = await _context.Amigos.FindAsync(id);
            if (amigos == null)
            {
                return NotFound();
            }
            return View(amigos);
        }

        // POST: Amigos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id")] Amigos amigos)
        {
            if (id != amigos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(amigos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AmigosExists(amigos.Id))
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
            return View(amigos);
        }

        // GET: Amigos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var amigos = await _context.Amigos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (amigos == null)
            {
                return NotFound();
            }

            return View(amigos);
        }

        // POST: Amigos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var amigos = await _context.Amigos.FindAsync(id);
            _context.Amigos.Remove(amigos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AmigosExists(int id)
        {
            return _context.Amigos.Any(e => e.Id == id);
        }
    }
}
