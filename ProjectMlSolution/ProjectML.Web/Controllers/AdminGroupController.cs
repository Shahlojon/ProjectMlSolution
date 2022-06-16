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
    public class AdminGroupController : Controller
    {
        private readonly IGroupRepository _context;
        private readonly ICourceRepository _contextCource;
        private readonly IProfessionRepository _contextProff;

        public AdminGroupController(IGroupRepository context, IProfessionRepository profession, ICourceRepository cource)
        {
            _context = context;
            _contextCource = cource;
            _contextProff = profession;
        }

        // GET: AdminGroup
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: AdminGroup/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = await _context.GetById(id);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        // GET: AdminGroup/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CourceId"] = new SelectList(await _contextCource.GetAll(), "Id", "Key");
            ViewData["ProfId"] = new SelectList(await _contextProff.GetAll(), "Id", "Key");
            ViewData["GroupId"] = new SelectList(await _context.GetAll(), "Key", "Key");

            return View();
        }

        // POST: AdminGroup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Group group)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(group);
                return RedirectToAction(nameof(Index));
            }
            return View(@group);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNew(Group group)
        {
            if (ModelState.IsValid)
            {
                await _context.AddNew(group);
                return RedirectToAction(nameof(Index));
            }
            return View(@group);
        }
        // GET: AdminGroup/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = await _context.GetById(id);
            if (group == null)
            {
                return NotFound();
            }
            return View(group);
        }

        // POST: AdminGroup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Group @group)
        {
            if (id != @group.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(group);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(group.Id))
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
            return View(group);
        }

        // GET: AdminGroup/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = await _context.GetById(id);
            if (group == null)
            {
                return NotFound();
            }

            return View(group);
        }

        // POST: AdminGroup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _context.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool GroupExists(int id)
        {
            var group = _context.GetById(id);
            if (group != null)
                return true;
            return false;
        }
    }
}
