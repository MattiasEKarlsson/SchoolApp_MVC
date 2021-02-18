using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Data;
using SchoolApp.Services.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApp.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IIdentityService _identityService;

        public UsersController(UserManager<ApplicationUser> userManager, IIdentityService identityService)
        {
            _userManager = userManager;
            _identityService = identityService;
        }

        // GET: UsersController1
        public async Task <ActionResult> Index()
        {

            ViewBag.Users = await _identityService.GetAllUsersWithRolesAsync();
            
            return View();
        }

        // GET: UsersController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        
        // GET: UsersController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UsersController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UsersController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> AllStudentsList()
        {
            ViewBag.Users = await _identityService.GetAllUsersWithRolesAsync();
            return View();
        }
    }
}
