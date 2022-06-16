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
    public class AdminLessonController : Controller
    {
        private readonly ILessonRepository _context;
        private readonly ISubjectRepository _contextSubject;

        public AdminLessonController(ILessonRepository context, ISubjectRepository subject)
        {
            _context = context;
            _contextSubject = subject;
        }

        // GET: AdminLesson
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: AdminLesson/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.GetById(id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // GET: AdminLesson/Create
        public async Task<IActionResult> Create()
        {
            ViewData["SubjectId"] = new SelectList(await _contextSubject.GetAll(), "Id", "Name");
            return View();
        }

        // POST: AdminLesson/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Lesson lesson)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(lesson);
                return RedirectToAction(nameof(Index));
            }
            return View(lesson);
        }

        // GET: AdminLesson/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.GetById(id);
            if (lesson == null)
            {
                return NotFound();
            }

            ViewData["SubjectId"] = new SelectList(await _contextSubject.GetAll(), "Id", "Name", lesson.SubjectId);
            return View(lesson);
        }

        // POST: AdminLesson/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Lesson lesson)
        {
            if (id != lesson.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(lesson);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonExists(lesson.Id))
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
            return View(lesson);
        }

        // GET: AdminLesson/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.GetById(id);
            if (lesson == null)
            {
                return NotFound();
            }

            return View(lesson);
        }

        // POST: AdminLesson/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool LessonExists(int id)
        {
            var lesson = _context.GetById(id);
            if (lesson != null)
                return true;
            return false;
        }
    }
}
