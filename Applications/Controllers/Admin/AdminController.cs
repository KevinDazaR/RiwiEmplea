using Microsoft.AspNetCore.Mvc;
using RiwiEmplea.Applications.Interfaces;

namespace RiwiEmplea.Applications.Controllers.Admin
{
    public class AdminController : Controller
    {
        private readonly IAdminRepository _adminRepository;
        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }
        [HttpGet("admin/index")]

        public async Task<IActionResult> Index(int pagenumber = 1, int pageSize = 10)
        {
            if (pagenumber < 1)
            {
                return NotFound();
            }
            var users = await _adminRepository.GetUsers(pagenumber, pageSize);

            if (users.PageNumber != 1 && pagenumber > users.PageCount)
            {
                return NotFound();
            }

            ViewBag.Users = users;
            return View(users);
        }
    }
}