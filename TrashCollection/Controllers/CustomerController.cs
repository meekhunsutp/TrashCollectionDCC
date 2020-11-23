using GoogleMaps.LocationServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TrashCollection.Data;
using TrashCollection.Models;

namespace TrashCollection.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomerController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = _context.Customer.Include(e => e.Address).Where(c => c.IdentityUserId == userId).SingleOrDefault();
            if (customer == null)
            {
                return RedirectToAction("Create");
            }
            var applicationDbContext = _context.Customer.Include(c => c.Address).Include(c => c.IdentityUser);
            return RedirectToAction("Details", new { customer.Id });
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .Include(c => c.Address)
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Customer customer)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            customer.IdentityUserId = userId;
            customer = GeoCode(customer);
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction("ManageServices", new { customer.Id });
        }
        public Customer GeoCode(Customer customer)
        {
            string address = customer.Address.StreetAddress.ToString() + ", " + customer.Address.CityState.ToString() + ", " + customer.Address.Zip.ToString();
            var geocode = new GoogleLocationService("AIzaSyCR_uKNqBSb29DBstYv3ZF9wzzViywcpS0");
            var coords = geocode.GetLatLongFromAddress(address);
            customer.Latitude = coords.Latitude;
            customer.Longtitude = coords.Longitude;
            ViewBag.Latitude = customer.Latitude;
            ViewBag.Longtitude = customer.Longtitude;
            return customer;
        }

        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> ManageServices(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            return View(customer);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ManageServices(int? id, Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }
            _context.Customer.Update(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { customer.Id });
        }

        // GET: Customer/Edit/5
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                            .Include(c => c.Address)
                            .Include(c => c.IdentityUser)
                            .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _context.Customer
                .Include(c => c.Address)
                .Include(c => c.IdentityUser)
                .FirstOrDefaultAsync(m => m.Id == id);
            customer = GeoCode(customer);
            //_context.Customer.Update(customer);
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", new { customer.Id });
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var customer = await _context.Customer
            .Include(c => c.Address)
            .Include(c => c.IdentityUser)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (customer == null)
        {
            return NotFound();
        }

        return View(customer);
    }

    // POST: Customer/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var customer = await _context.Customer.FindAsync(id);
        _context.Customer.Remove(customer);
        await _context.SaveChangesAsync();
        return RedirectToAction("Create");
    }

    private bool CustomerExists(int id)
    {
        return _context.Customer.Any(e => e.Id == id);
    }
}
}