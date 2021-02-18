using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SchoolApp.Data;
using SchoolApp.Models;
using SchoolApp.Models.ViewModels;
using SchoolApp.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LinkUserToClassController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IIdentityService _identityService;
        private readonly UserManager<ApplicationUser> _userManager;

        public LinkUserToClassController(ApplicationDbContext context, IIdentityService identityService, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _identityService = identityService;
            _userManager = userManager;
        }

        public async Task <IActionResult> AddToClass(string id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            IEnumerable<SelectListItem> TypeDropDown = _context.SchoolClasses.Select(i => new SelectListItem
            {
                Text = i.ClassName,
                Value = i.Id.ToString()
            });
            ViewBag.TypeDropdown = TypeDropDown;

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <ActionResult> AddToClass(string id, [Bind("FirstName, LastName, ClassId")]ApplicationUser model)
        {
            var user = await _userManager.FindByIdAsync(id);
            
            user.ClassId = model.ClassId;
            
                _context.Update(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");

        }
    }
}
