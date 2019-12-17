using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using assignment_uploader.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace assignment_uploader.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private AppDBContext _context;

        public AssignmentController(AppDBContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (signInManager.IsSignedIn(User))
            {
                return View(_context.Assignments.ToList());
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        [HttpGet]
        public IActionResult Add()
        {
            if (signInManager.IsSignedIn(User))
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        //Function to convert file to byte[] so it can be stored in DB
        private byte[] GetByteArrayFromFile(IFormFile file)
        {
            using (var target = new MemoryStream())
            {
                file.CopyTo(target);
                return target.ToArray();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(AssignmentModel model)
        {
            if (ModelState.IsValid)
            {
                string[] permittedExtension = { ".zip" };
                var ext = Path.GetExtension(model.File.FileName).ToLowerInvariant();

                if (model.File.FileName == null || !permittedExtension.Contains(ext))
                {
                    ModelState.AddModelError("", "File must be of type .zip");
                }
                else
                {
                    var assignment = new AppAssignment
                    {
                        Title = model.Title,
                        Date = DateTime.Now,
                        File = GetByteArrayFromFile(model.File),
                        Uploader = userManager.GetUserId(User)
                    };

                    _context.Assignments.Add(assignment);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult DownloadFileFromDB(int id)
        {
            
            var fileUpload = _context.Assignments.SingleOrDefault(aa => aa.Id == id);
            MemoryStream memoryStream = new MemoryStream(fileUpload.File);
            string fileName = fileUpload.Title.ToString() + ".zip";

            if (userManager.GetUserId(User) == fileUpload.Uploader)
            {
                return File(memoryStream, "application/zip", fileName);
            }
            else
            {
                return View();
            }
        }
    }
}