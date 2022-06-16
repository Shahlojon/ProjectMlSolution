using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectML.Core.Interfaces;
using ProjectML.Core.Models;

namespace DiplomProjectML.Controllers
{
    public class AdminCourceController : Controller
    {
        private readonly ICourceRepository _context;

        public AdminCourceController(ICourceRepository context)
        {
            _context = context;
        }

        // GET: AdminCource
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: AdminCource/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cource = await _context.GetById(id);
            if (cource == null)
            {
                return NotFound();
            }

            return View(cource);
        }

        // GET: AdminCource/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminCource/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cource cource)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(cource);
                return RedirectToAction(nameof(Index));
            }
            return View(cource);
        }

        // GET: AdminCource/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cource = await _context.GetById(id);
            if (cource == null)
            {
                return NotFound();
            }
            return View(cource);
        }

        // POST: AdminCource/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Cource cource)
        {
            if (id != cource.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(cource);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourceExists(cource.Id))
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
            return View(cource);
        }

        // GET: AdminCource/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cource = await _context.GetById(id);
            if (cource == null)
            {
                return NotFound();
            }

            return View(cource);
        }

        // POST: AdminCource/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cource = await _context.GetById(id);
            await _context.DeleteById(cource.Id);
            return RedirectToAction(nameof(Index));
        }

        private bool CourceExists(int id)
        {
            var cource = _context.GetById(id);
            if (cource != null)
                return true;
            return false;
        }
    }
}
