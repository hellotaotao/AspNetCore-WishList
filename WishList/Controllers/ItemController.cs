using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET
        public IActionResult Index()
        {
            var model = _context.Items.ToList();
            return View("Index", model);
        }

        public IActionResult HttpGet()
        {
            return View("Create");
        }

        public IActionResult HttpPost(Item item)
        {
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            _context.Items.Remove(_context.Items.Find(Id));
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
