using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data;
using SchoolApp.Models;
using SchoolApp.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class SchoolClassController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IIdentityService _identityService;
        private readonly UserManager<ApplicationUser> _userManager;

        public SchoolClassController(ApplicationDbContext context, IIdentityService identityService, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _identityService = identityService;
            _userManager = userManager;
        }

        public async Task <IActionResult> Index()
        {
            var classes = await _context.SchoolClasses.ToListAsync();

            foreach (var schoolClass in classes)
            {
                schoolClass.Teacher =  await _userManager.Users.FirstOrDefaultAsync(au => au.Id == schoolClass.TeacherId);
            }
            return View(classes);
        }

        public IActionResult Create()
        {
            IEnumerable<SelectListItem> TypeDropDown = _context.Users.Select(i => new SelectListItem
            {
                Text = i.GetDisplay(),
                Value = i.Id.ToString()
            });
            ViewBag.TypeDropdown = TypeDropDown;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SchoolClass obj)
        {
            if (ModelState.IsValid)
            {
                _context.SchoolClasses.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _context.SchoolClasses.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _context.SchoolClasses.Find(id);
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            _context.SchoolClasses.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
