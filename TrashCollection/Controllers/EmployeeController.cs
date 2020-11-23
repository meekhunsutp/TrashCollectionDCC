using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrashCollection.Data;
using TrashCollection.Models;

namespace TrashCollection.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = _context.Employee.Include(e => e.Address).Where(c => c.IdentityUserId == userId).FirstOrDefault();
            if (employee == null)
            {
                return RedirectToAction("Create");
            }
            var workForToday = TodaysCustomers(employee, employee.CollectionDay.Date);
            //var applicationDbContext = _context.Employee.Include(e => e.Address).Include(e => e.IdentityUser);
            return RedirectToAction("FindWork", new { employee.Id });
        }

        public async Task<IActionResult> FindWork(int? id)
        {
            var employee = await _context.Employee
                .Include(e => e.Address)
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            ViewBag.EmployeeId = employee.Id;
            ViewBag.DateSelected = employee.CollectionDay.ToShortDateString();
            ViewBag.Date = employee.CollectionDay.Date;
            var workForToday = TodaysCustomers(employee, employee.CollectionDay.Date);
            return View(workForToday);
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var employee = await _context.Employee
                .Include(e => e.Address)
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            return View(employee);
        }


        // GET: Employee/Create
        public IActionResult Create()
        {

            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            employee.IdentityUserId = userId;
            _context.Add(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { employee.Id });
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToAction("FindWork", new { employee.Id });
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employee
                .Include(e => e.Address)
                .Include(e => e.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employee.FindAsync(id);
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employee.Any(e => e.Id == id);
        }

        private List<Customer> TodaysCustomers(Employee employee, DateTime dateSelected)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            employee.IdentityUserId = userId;
            List<Customer> TodaysCustomersList = _context.Customer.Where(c =>
                c.Address.Zip == employee.Address.Zip
                && c.CustomerConfirmPickUp == false
                && (c.CollectionDay == dateSelected.DayOfWeek || c.ExtraPickUp == dateSelected)
                && ((c.SuspendServiceStart > dateSelected || c.SuspendServiceStart == null)
                || (c.SuspendServiceEnd < dateSelected || c.SuspendServiceEnd == null))).ToList();
            return TodaysCustomersList;
        }
        public async Task<IActionResult> ConfirmPickUp(int? id) 
        {
            var customer = _context.Customer.Where(c => c.Id == id).FirstOrDefault();
            //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var employee = _context.Employee.Where(c => c.IdentityUserId ==
            //userId).SingleOrDefault();
            //if(employee.CollectionDay != )
            AddToBalance(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private static void AddToBalance(Customer customer)
        {
            if (customer.CustomerConfirmPickUp == false)
            {
                customer.AccountBalance += 25;
                customer.CustomerConfirmPickUp = true;
            }
        }
    }
}
