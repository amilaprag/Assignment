using Assignment.Context;
using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: Employee
        public async Task<IActionResult> Index(string searchString)
        {
            if (searchString == null)
            {
                var employeeContext = _context.Empoyee.Include(e => e.Department);
                return View(await employeeContext.ToListAsync());
            }
            else
            {
                var employee = await _context.Empoyee.Where(e => e.Name.Contains(searchString)).ToListAsync();
                return View(employee);
            }
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Empoyee == null)
            {
                return NotFound();
            }

            var employee = await _context.Empoyee
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "Name");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeId,Name,StartDate,Title,PayRate,Hours,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "Name", _context.Department.Where(r => r.DepartmentId == employee.DepartmentId).Select(p => p.Name));
            return View(employee);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Empoyee == null)
            {
                return NotFound();
            }

            var employee = await _context.Empoyee.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "Name", _context.Department.Where(r => r.DepartmentId == employee.DepartmentId).Select(p => p.Name));
            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeId,Name,StartDate,Title,PayRate,Hours,DepartmentId")] Employee employee)
        {
            if (id != employee.EmployeeId)
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
                    if (!EmployeeExists(employee.EmployeeId))
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
            ViewData["DepartmentId"] = new SelectList(_context.Department, "DepartmentId", "Name", _context.Department.Where(r => r.DepartmentId == employee.DepartmentId).Select(p => p.Name));
            return View(employee);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Empoyee == null)
            {
                return NotFound();
            }

            var employee = await _context.Empoyee
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
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
            if (_context.Empoyee == null)
            {
                return Problem("Entity set 'EmployeeContext.Empoyee'  is null.");
            }
            var employee = await _context.Empoyee.FindAsync(id);
            if (employee != null)
            {
                _context.Empoyee.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Empoyee.Any(e => e.EmployeeId == id);
        }
    }
}