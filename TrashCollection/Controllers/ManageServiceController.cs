using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollection.Data;
using TrashCollection.Models;

namespace TrashCollection.Controllers
{
    public class ManageServiceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManageServiceController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ManageService
        public async Task<IActionResult> Index()
        {
            return View(await _context.ManageService.ToListAsync());
        }

        // GET: ManageService/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manageService = await _context.ManageService
                .FirstOrDefaultAsync(m => m.ServiceId == id);
            if (manageService == null)
            {
                return NotFound();
            }

            return View(manageService);
        }

        // GET: ManageService/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ManageService/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ServiceId,ServiceDay,ExtraPickUp,SuspendServiceStart,SuspendServiceEnd,Cost,CustomerConfirmPickUp,EmployeeConfirmPickUp")] ManageService manageService)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manageService);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(manageService);
        }

        // GET: ManageService/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manageService = await _context.ManageService.FindAsync(id);
            if (manageService == null)
            {
                return NotFound();
            }
            return View(manageService);
        }

        // POST: ManageService/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ServiceId,ServiceDay,ExtraPickUp,SuspendServiceStart,SuspendServiceEnd,Cost,CustomerConfirmPickUp,EmployeeConfirmPickUp")] ManageService manageService)
        {
            if (id != manageService.ServiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manageService);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManageServiceExists(manageService.ServiceId))
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
            return View(manageService);
        }

        // GET: ManageService/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manageService = await _context.ManageService
                .FirstOrDefaultAsync(m => m.ServiceId == id);
            if (manageService == null)
            {
                return NotFound();
            }

            return View(manageService);
        }

        // POST: ManageService/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manageService = await _context.ManageService.FindAsync(id);
            _context.ManageService.Remove(manageService);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManageServiceExists(int id)
        {
            return _context.ManageService.Any(e => e.ServiceId == id);
        }
    }
}
