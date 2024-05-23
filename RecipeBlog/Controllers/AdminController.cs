using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBlog.Models;

namespace RecipeBlog.Controllers
{
    public class AdminController : Controller

    {
        private readonly ModelContext _context;
        public AdminController(ModelContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            // Fetch categories, recipes, and payments asynchronously if supported, otherwise synchronously
            ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Recipes = _context.Recipes.ToList();
            ViewBag.Payments = _context.Payments.ToList();

            // Counts
            ViewBag.RegisteredUserCount = _context.Users.Count(x => x.Roleid == 2);
            ViewBag.RegisteredChefCount = _context.Users.Count(x => x.Roleid == 3);
            ViewBag.RecipeCount = _context.Recipes.Count();  // Corrected typo from "recipycount" to "RecipeCount" for consistency

            // Attempt to get the user from the session
            var id = HttpContext.Session.GetInt32("UserID");
            var user = _context.Users.FirstOrDefault(u => u.Userid == id);

            if (user == null)
            {
                // If no user is found, handle according to your application's requirements
                ViewBag.ErrorMessage = "No user found. Please log in again.";
            }
            return View(user);
        }
        public async Task<IActionResult> Approve(decimal id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            recipe.Status = Recipe.RecipeStatus.Approved;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Reject(decimal id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            recipe.Status = Recipe.RecipeStatus.Rejected;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



    }
}
