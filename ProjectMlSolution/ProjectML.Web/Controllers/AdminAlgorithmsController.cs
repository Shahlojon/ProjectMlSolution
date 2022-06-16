using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjectML.Core.Interfaces;
using ProjectML.Core.Models;

namespace ProjectML.Web.Controllers
{
    //тут должен быть авторизация и проверка роля админ 
    public class AdminAlgorithmsController : Controller
    {
        readonly IAlgorithmRepository _context;
        public AdminAlgorithmsController(IAlgorithmRepository context)
        {
            _context = context;
        }

        // GET: AdminAlgorithms
        public async Task<IActionResult> Index()
        {
            return View(await _context.GetAll());
        }

        // GET: AdminAlgorithms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var algorithm = await _context.GetById(id);
            if (algorithm == null)
            {
                return NotFound();
            }

            return View(algorithm);
        }

        // GET: AdminAlgorithms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminAlgorithms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Algorithm algorithm)
        {
            if (ModelState.IsValid)
            {
                await _context.Add(algorithm);
                return RedirectToAction(nameof(Index));
            }
            return View(algorithm);
        }

        // GET: AdminAlgorithms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var algorithm = await _context.GetById(id);
            if (algorithm == null)
            {
                return NotFound();
            }
            return View(algorithm);
        }

        // POST: AdminAlgorithms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Algorithm algorithm)
        {
            if (id != algorithm.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Update(algorithm);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlgorithmExists(algorithm.Id))
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
            return View(algorithm);
        }

        // GET: AdminAlgorithms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var algorithm = await _context.GetById(id);
            if (algorithm == null)
            {
                return NotFound();
            }

            return View(algorithm);
        }

        // POST: AdminAlgorithms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var algorithm = await _context.GetById(id);
            await _context.DeleteById(algorithm.Id);
            return RedirectToAction(nameof(Index));
        }

        private bool AlgorithmExists(int id)
        {
            var algorithm = _context.GetById(id);
            if (algorithm != null)
                return true;
            return false;
        }
    }
}
