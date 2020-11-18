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
            var employee = _context.Employee.Where(c => c.IdentityUserId == userId).FirstOrDefault();
            if ( employee == null)
            {
                return RedirectToAction("Create");
            }
            var workForToday = TodaysCustomers(employee);
            var applicationDbContext = _context.Employee.Include(e => e.Address).Include(e => e.IdentityUser);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
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


        // GET: Employee/Create
        public IActionResult Create()
        {
            ViewData["AddressId"] = new SelectList(_context.Address, "Id", "Id");
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdentityUserId,AddressId,FirstName,LastName")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressId"] = new SelectList(_context.Address, "Id", "Id", employee.AddressId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
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
            ViewData["AddressId"] = new SelectList(_context.Address, "Id", "Id", employee.AddressId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdentityUserId,AddressId,FirstName,LastName")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            ViewData["AddressId"] = new SelectList(_context.Address, "Id", "Id", employee.AddressId);
            ViewData["IdentityUserId"] = new SelectList(_context.Users, "Id", "Id", employee.IdentityUserId);
            return View(employee);
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

        ////////GARBAGE LOGIC
        
        ////Need to be able to select day from list to show work for that day
        //public async Task<IActionResult> WorkforToday() //List of customers that need pick ups today (DEFAULT VIEW)
        //{

        //}
        private List<Customer> TodaysCustomers(Employee employee)        //Add customers to this list if their trash should be picked up today, run the conditional checks
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            employee.IdentityUserId = userId;
            List<Customer> TodaysCustomersList = new List<Customer>();
            TodaysCustomersList = ZipCheck(employee, TodaysCustomersList);
            TodaysCustomersList = CollectionDayCheck(TodaysCustomersList);
            TodaysCustomersList = ExtraPickUpCheck(TodaysCustomersList);
            TodaysCustomersList = AlreadyPickedUpCheck(TodaysCustomersList);
            TodaysCustomersList = SuspensionCheck(TodaysCustomersList);
            return TodaysCustomersList;
        }
        private List<Customer> ZipCheck(Employee employee, List<Customer> customers)        //check to see if they are in workers zip code, if so add
        {
            foreach(Customer customer in _context.Customer)
            {
                if (customer.Address.Zip >= employee.Address.Zip - 2 && customer.Address.Zip <= employee.Address.Zip + 2)
                {
                    customers.Add(customer);
                }
            }
            return customers;
        }
        private List<Customer> CollectionDayCheck(List<Customer> customers)        //check to see if customer pick up day matches today, if so add
        {
            foreach( Customer customer in customers)
            {
                if( customer.CollectionDay != DateTime.Today.DayOfWeek)
                {
                    customers.Remove(customer);
                }
            }
            return customers;
        }
        private List<Customer> ExtraPickUpCheck(List<Customer> customers)        //check to see if customer has an extra pick up, if so add
        {
            foreach (Customer customer in customers)
            {
                if (customer.ExtraPickUp.Equals(DateTime.Today.Date)) // Check .Date
                {
                    customers.Add(customer);
                }
            }
            return customers;
        }
        private List<Customer> AlreadyPickedUpCheck(List<Customer> customers)        //check to see if trash has already been picked up, if so remove
        {
            foreach (Customer customer in customers)
            {
                if (customer.CustomerConfirmPickUp == true)
                {
                    customers.Remove(customer);
                }
            }
            return customers;
        }
        private List<Customer> SuspensionCheck(List<Customer> customers)        //check to see if customer is on pause, if so remove
        {
            foreach(Customer customer in customers)
            {
                if( customer.SuspendServiceStart?.CompareTo(DateTime.Today.Date) >= 0 && customer.SuspendServiceEnd?.CompareTo(DateTime.Today.Date) <= 0)
                {
                    customers.Remove(customer);
                }
            }
            return customers;
        }
        public async Task<IActionResult> ConfirmPickUp(int? id) //button to call this function per customer, button can only be clicked once, confirmed by customer button?
        {
            var customer = _context.Customer.Where(c => c.Id == id).FirstOrDefault();
            AddToBalance(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private static void AddToBalance(Customer customer)
        {
            if(customer.CustomerConfirmPickUp == true)
            {
                customer.AccountBalance += 25;
            }
        }
    }
}
