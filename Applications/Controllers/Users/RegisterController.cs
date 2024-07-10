    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;
    using RiwiEmplea.Applications.Interfaces;
    using RiwiEmplea.Dtos.Users;
    using RiwiEmplea.Models;

    namespace RiwiEmplea.Controllers
    {
        public class RegisterController : Controller
        {
            private readonly IUsersRepository _usersRepository;
            private readonly ILogger<RegisterController> _logger;

            public RegisterController(IUsersRepository usersRepository, ILogger<RegisterController> logger)
            {
                _usersRepository = usersRepository;
                _logger = logger;
            }

            // GET: Users/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Users/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create(UsersDTO userDTO)
            {
                if (userDTO == null)
                {
                    _logger.LogError("UserDTO object sent from client is null.");
                    return View(userDTO);
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        var createdUser = await _usersRepository.CreateUserAsync(userDTO);
                        return RedirectToAction(nameof(Details), new { id = createdUser.Id });
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Something went wrong inside CreateUser action: {ex.Message}");
                        ModelState.AddModelError(string.Empty, "An error occurred while creating the user.");
                    }
                }

                return View(userDTO);
            }

            // GET: Users/Details/5
            public async Task<IActionResult> Details(int id)
            {
                var user = await _usersRepository.GetUserByIdAsync(id);
                if (user == null)
                {
                    _logger.LogError($"User with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                return View(user);
            }
        }
    }
