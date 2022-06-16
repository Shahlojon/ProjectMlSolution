using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectML.Core.Interfaces;
using ProjectML.Core.Models;
using ProjectML.Infrastructure.Repository;

namespace DiplomProjectML.Controllers
{
    public class AdminExamController : Controller
    {
        private readonly IExamRepository _context;
        private readonly IGroupRepository _contextGroup;
        private readonly ISubjectRepository _contextSubject;

        public AdminExamController(IExamRepository context, IGroupRepository group, ISubjectRepository subject)
        {
            _context = context;
            _contextGroup = group;
            _contextSubject = subject;
        }

        // GET: AdminExam
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: AdminExam/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.GetById(id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // GET: AdminExam/Create
        public async Task<IActionResult> Create()
        {             
            var group = await _contextGroup.GetAllWithRelation();
            ViewBag.Group = group;
            ViewData["SubjectId"] = new SelectList(await _contextSubject.GetAll(), "Id", "Name");
            return View();
        }

        // POST: AdminExam/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Exam exam)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(exam);
                return RedirectToAction(nameof(Index));
            }
            return View(exam);
        }

        // GET: AdminExam/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.GetById(id);
            if (exam == null)
            {
                return NotFound();
            }
            return View(exam);
        }

        // POST: AdminExam/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Exam exam)
        {
            if (id != exam.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(exam);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamExists(exam.Id))
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
            return View(exam);
        }

        // GET: AdminExam/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.GetById(id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // POST: AdminExam/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ExamExists(int id)
        {
            var exam = _context.GetById(id);
            if (exam != null)
                return true;
            return false;
        }
    }
}
