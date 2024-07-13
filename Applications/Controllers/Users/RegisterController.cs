    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;
    using RiwiEmplea.Applications.Interfaces;
    using RiwiEmplea.Dtos.Users;
    using RiwiEmplea.Models;
    using Newtonsoft.Json;

    namespace RiwiEmplea.Applications.Controllers.Users
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

           // GET: Register/Create
            public IActionResult Create()
            {
                return View();
            }

            // POST: Register/Create
            [HttpPost]
            public async Task<IActionResult> Create(UsersDTO userDTO)
            {
                Console.WriteLine("Entrando a Create action...");

                // Convertir userDTO a JSON para depuración
                var userDtoJson = JsonConvert.SerializeObject(userDTO);
                Console.WriteLine($"Datos del usuario recibidos: {userDtoJson}");

                if (userDTO == null)
                {
                    Console.WriteLine("userDTO es nulo");
                    _logger.LogError("UserDTO object sent from client is null.");
                    return View(userDTO);
                }
                
                    Console.WriteLine("ModelState es válido");

                    if (userDTO.Password != userDTO.ConfirmPassword)
                    {
                        ModelState.AddModelError("ConfirmPassword", "The password and confirmation password do not match.");
                        return View(userDTO);
                    }

                    try
                    {
                        // Establecer el valor de RoleId
                        userDTO.RoleId = 2;

                        var createdUser = await _usersRepository.CreateUserAsync(userDTO);
                        return RedirectToAction("Details", "Details", new { id = createdUser.Id });
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError($"Something went wrong inside CreateUser action: {ex.Message}");
                        ModelState.AddModelError(string.Empty, "An error occurred while creating the user.");
                    }
                

                // Si ModelState no es válido o hay un error, retorna la vista con el modelo
                return View(userDTO);
            }




        }
    }
