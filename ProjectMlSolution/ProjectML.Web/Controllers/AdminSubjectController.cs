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
    public class AdminSubjectController : Controller
    {
        private readonly ISubjectRepository _context;

        public AdminSubjectController(ISubjectRepository context)
        {
            _context = context;
        }

        // GET: AdminSubject
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: AdminSubject/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.GetById(id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: AdminSubject/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminSubject/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(subject);
                return RedirectToAction(nameof(Index));
            }
            return View(subject);
        }

        // GET: AdminSubject/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.GetById(id);
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        // POST: AdminSubject/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Subject subject)
        {
            if (id != subject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(subject);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.Id))
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
            return View(subject);
        }

        // GET: AdminSubject/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _context.GetById(id);
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: AdminSubject/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(int id)
        {
            var subject = _context.GetById(id);
            if (subject != null)
                return true;
            return false;
        }
    }
}
