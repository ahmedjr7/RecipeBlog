using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipeBlog.Models;
using MailKit.Net.Smtp;
using MimeKit;
using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace RecipeBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ModelContext _context;
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, ModelContext context, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var chefs = _context.Users.Where(u => u.Roleid == 3).ToList(); // Fetching only chefs
            var categories = _context.Categories.ToList();
            var testimonials = _context.Testimonials.Include(t => t.User).ToList(); // Include User data with testimonials

            // Fetch dynamic content for the home page
            ViewBag.HeroTitle = _context.Pagecontents.FirstOrDefault(pc => pc.Pagename == "Home" && pc.Contentkey == "HeroTitle")?.Contentvalue;
            ViewBag.HeroDescription = _context.Pagecontents.FirstOrDefault(pc => pc.Pagename == "Home" && pc.Contentkey == "HeroDescription")?.Contentvalue;
            ViewBag.HeroImage = _context.Pagecontents.FirstOrDefault(pc => pc.Pagename == "Home" && pc.Contentkey == "HeroImage")?.Contentvalue;

            return View((Chefs: chefs as IEnumerable<User>, Categories: categories as IEnumerable<Category>, Testimonials: testimonials as IEnumerable<Testimonial>));
        }



        public IActionResult MyProfile()
        {
            int? userId = HttpContext.Session.GetInt32("UserID");

            if (userId == null)
            {
                return RedirectToAction("LogIn", "Login_Register");
            }

            var user = _context.Users.FirstOrDefault(u => u.Userid == userId);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(User model)
        {
            int? userId = HttpContext.Session.GetInt32("UserID");

            if (userId == null)
            {
                return RedirectToAction("LogIn", "Login_Register");
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Userid == userId);

            if (user == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrEmpty(model.Username))
            {
                user.Username = model.Username;
            }

            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var fileName = Path.GetFileName(model.ImageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserImages", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(stream);
                }

                user.Profileimage = fileName;
            }

            _context.Update(user);
            await _context.SaveChangesAsync();

            return RedirectToAction("MyProfile", "Home");
        }


        public IActionResult getRecipyByCategoryId(int Categoryid)
        {
            var recipes = _context.Recipes.Where(r => r.Categoryid == Categoryid).ToList();
            return View(recipes);
        }
        public IActionResult getRecipeByChefId(int Userid)
        {
            var recipes = _context.Recipes.Where(r => r.Userid == Userid).ToList();
            return View("getRecipeByChefId", recipes); // Make sure to use the correct view name here
        }
        //__________________________________________________________________________________________________________________________________________
        public IActionResult Purchase(decimal id)
        {
            var recipe = _context.Recipes.Find(id);
            if (recipe == null)
            {
                return NotFound();
            }

            ViewBag.RecipeId = recipe.Recipeid;
            ViewBag.RecipeName = recipe.Name;  // Assuming 'Name' is the actual property for the recipe's name
            ViewBag.RecipeImage = recipe.Mainimage;
            ViewBag.Price = recipe.Price;  // Ensure your Recipe model includes a 'Price' property

            return View();
        }

        //__________________________________________________________________________________________________________________________________________
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CompletePurchase(int RecipeId, decimal PurchaseAmount, string CardHolderName, string CardNumber, string CardSecurityNumber, int ExpiryMonth, int ExpiryYear)
        {
            var userId = HttpContext.Session.GetInt32("UserID");
            if (userId == null)
            {
                return RedirectToAction("Login", "Account"); // Ensure you have a login route
            }

            var card = _context.Payments.FirstOrDefault(c =>
                c.Cardid == CardNumber &&
                c.Cardholdername == CardHolderName &&
                c.Cardsecuritynumber == CardSecurityNumber &&
                c.Cardexpirydate.HasValue &&
                c.Cardexpirydate.Value.Month == ExpiryMonth &&
                c.Cardexpirydate.Value.Year == ExpiryYear);

            if (card == null || card.Amount < PurchaseAmount)
            {
                ViewBag.ErrorMessage = "Invalid card details or insufficient funds.";
                return View("Error");
            }

            card.Amount -= PurchaseAmount; // Deduct the purchase amount
            _context.SaveChanges(); // Save payment info

            var recipe = _context.Recipes.Find((decimal)RecipeId);
            if (recipe != null)
            {
                var pdfPath = GenerateRecipePdf(recipe);
                var user = _context.Users.Find((decimal)userId);
                if (user != null)
                {
                    SendEmail(user.Email, $"Your Recipe Purchase: {recipe.Name}", "Thank you for your purchase. Please find the recipe attached.", pdfPath);
                }
            }

            return View("CompletePurchase");
        }

        private string GenerateRecipePdf(Recipe recipe)
        {
            // Generating a unique file name to prevent conflicts if the same recipe is accessed simultaneously
            string pdfFileName = $"{recipe.Name}_{DateTime.Now:yyyyMMddHHmmssfff}.pdf";
            string pdfPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Pdf", pdfFileName);

            // Using the 'using' statement to ensure the file stream and document are properly closed and disposed of
            using (FileStream stream = new FileStream(pdfPath, FileMode.Create))
            {
                using (Document document = new Document())
                {
                    PdfWriter writer = PdfWriter.GetInstance(document, stream);

                    document.Open();
                    document.Add(new Paragraph($"Recipe Name: {recipe.Name}"));
                    document.Add(new Paragraph($"Description: {recipe.Description}"));
                    document.Add(new Paragraph($"Ingredients: {recipe.Ingredients}"));
                    document.Add(new Paragraph($"Instructions: {recipe.Instructions}"));
                    document.Close();  // Closing the document also flushes content to the stream
                }  // Document is disposed here, ensuring all content is written
            }  // FileStream is disposed here, releasing the file handle

            return pdfPath;
        }


        private void SendEmail(string toEmail, string subject, string body, string attachmentPath)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Jr7 Recipe Blog", "jr7Recipe@gmail.com"));
            message.To.Add(new MailboxAddress("", toEmail));
            message.Subject = subject;

            var builder = new BodyBuilder { HtmlBody = body };
            builder.Attachments.Add(attachmentPath);
            message.Body = builder.ToMessageBody();

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.ethereal.email", 587, false); // Correctly initiate StartTLS
                client.Authenticate("lauriane.hintz@ethereal.email", "9nsU7vHJMrp8z7Vf7r"); // Ensure you are using correct and valid credentials
                client.Send(message);
                client.Disconnect(true);
            }

        }

        public IActionResult AddRecipe()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Recipeid,Userid,Name,Description,Ingredients,Instructions,Categoryid,Addedtime,ImageFile,Status,Price")] Recipe recipe)
        {
            if (recipe.ImageFile != null)
            {
                string wwwrootpath = _webHostEnvironment.WebRootPath;
                string fileName = Path.GetFileName(recipe.ImageFile.FileName);
                string imageName = Guid.NewGuid().ToString() + "_" + fileName;
                string fullpath = Path.Combine(wwwrootpath + "/RecipeImages/", imageName);

                using (var filestream = new FileStream(fullpath, FileMode.Create))
                {
                    await recipe.ImageFile.CopyToAsync(filestream);
                }

                recipe.Mainimage = imageName;
            }
            if (ModelState.IsValid)
            {
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Categoryid"] = new SelectList(_context.Categories, "Categoryid", "Categoryid", recipe.Categoryid);
            ViewData["Userid"] = new SelectList(_context.Users, "Userid", "Userid", recipe.Userid);
            return View(recipe);
        }



        public IActionResult AboutUs()
        {                                                                      
            ViewBag.Image1 = _context.Pagecontents.FirstOrDefault(pc => pc.Pagename == "AboutUs" && pc.Contentkey == "Image1")?.Contentvalue;
            ViewBag.Image2 = _context.Pagecontents.FirstOrDefault(pc => pc.Pagename == "AboutUs" && pc.Contentkey == "Image2")?.Contentvalue;
            ViewBag.Image3 = _context.Pagecontents.FirstOrDefault(pc => pc.Pagename == "AboutUs" && pc.Contentkey == "Image3")?.Contentvalue;
            ViewBag.Image4 = _context.Pagecontents.FirstOrDefault(pc => pc.Pagename == "AboutUs" && pc.Contentkey == "Image4")?.Contentvalue;
            ViewBag.MainText = _context.Pagecontents.FirstOrDefault(pc => pc.Pagename == "AboutUs" && pc.Contentkey == "MainText")?.Contentvalue;

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }


    }
}
