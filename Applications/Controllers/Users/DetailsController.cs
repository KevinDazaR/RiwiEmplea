    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;
    using RiwiEmplea.Applications.Interfaces;
    using RiwiEmplea.Dtos.Users;
    using RiwiEmplea.Models;

    namespace RiwiEmplea.Applications.Controllers.Users
    {
        public class DetailsController : Controller
        {
            private readonly IUsersRepository _usersRepository;
            private readonly ILogger<DetailsController> _logger;

            public DetailsController(IUsersRepository usersRepository, ILogger<DetailsController> logger)
            {
                _usersRepository = usersRepository;
                _logger = logger;
            }

           // GET: Details/Details
            public IActionResult Details()
            {
                return View();
            }

            // GET: Register/Details/{id}
            // [HttpGet]
            // public async Task<IActionResult> Details(int id)
            // {
            //     try
            //     {
            //         var user = await _usersRepository.GetUserByIdAsync(id);

            //         if (user == null)
            //         {
            //             _logger.LogWarning($"User with ID {id} not found.");
            //             return NotFound();
            //         }

            //         // Aquí podrías devolver una vista de detalles con los datos del usuario
            //         return View(user);
            //     }
            //     catch (Exception ex)
            //     {
            //         _logger.LogError($"Something went wrong inside Details action: {ex.Message}");
            //         return StatusCode(500, "Internal server error");
            //     }
            // }

        }
    }
