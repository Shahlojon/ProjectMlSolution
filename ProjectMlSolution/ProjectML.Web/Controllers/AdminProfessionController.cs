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
    public class AdminProfessionController : Controller
    {
        private readonly IProfessionRepository _context;

        public AdminProfessionController(IProfessionRepository context)
        {
            _context = context;
        }

        // GET: AdminProfession
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: AdminProfession/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profession = await _context.GetById(id);
            if (profession == null)
            {
                return NotFound();
            }

            return View(profession);
        }

        // GET: AdminProfession/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminProfession/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Profession profession)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(profession);
                return RedirectToAction(nameof(Index));
            }
            return View(profession);
        }

        // GET: AdminProfession/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profession = await _context.GetById(id);
            if (profession == null)
            {
                return NotFound();
            }
            return View(profession);
        }

        // POST: AdminProfession/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Profession profession)
        {
            if (id != profession.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(profession);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfessionExists(profession.Id))
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
            return View(profession);
        }

        // GET: AdminProfession/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profession = await _context.GetById(id);
            if (profession == null)
            {
                return NotFound();
            }

            return View(profession);
        }

        // POST: AdminProfession/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProfessionExists(int id)
        {
            var profession = _context.GetById(id);
            if (profession != null)
                return true;
            return false;
        }
    }
}
