using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TAKSCODE5.DAL;
using TAKSCODE5.Models;
using TAKSCODE5.ViewModels.Employee;

namespace TAKSCODE5.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class ListController : Controller
    {
        public AppDbContext _context { get; }
        public IWebHostEnvironment _env { get; set; }
        public ListController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(_context.Employees.ToList());
        }
        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeVM employeevm)
        {
            if (!ModelState.IsValid) return View();
            IFormFile file = employeevm.Image;
            if (!file.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("Image", "Duzgun sekil yukle");
                return View();
            }
            if (!(employeevm.Image.Length / 1024 / 1024 < 2))
            {
                ModelState.AddModelError("Image", "Seklin Olcusu Sehvdir");
                return View();
            }
            string filename = Guid.NewGuid() + file.FileName;
            using (FileStream stream = new FileStream(Path.Combine(_env.WebRootPath, "assets", "img", "team", filename), FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Employee employee = new Employee
            {
                Name = employeevm.Name,
                Image = filename,
                Description = employeevm.Description,
                Pozition= employeevm.Pozition,
                Instagram = employeevm.Instagram,
                Facebook = employeevm.Facebook,
                LinkEdin = employeevm.LinkEdin,
                Twitter = employeevm.Twitter
            };
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Update()
        {
            return View();
        }
        public IActionResult Delete(int? id)
        {
            Employee employee = _context.Employees.Find(id);
            if (employee != null) return NotFound();
            _context.Employees.Remove(employee);
            _context.SaveChanges();
            return View();
        }
    }
}
