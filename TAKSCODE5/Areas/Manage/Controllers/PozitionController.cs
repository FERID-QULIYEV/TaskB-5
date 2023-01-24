using Microsoft.AspNetCore.Mvc;
using TAKSCODE5.DAL;

namespace TAKSCODE5.Areas.Manage.Controllers
{
    public class PozitionController: Controller
    {
        public AppDbContext _context { get; }
        public IWebHostEnvironment _env { get; set; }
        public PozitionController(AppDbContext context, IWebHostEnvironment env)
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
    }
}
