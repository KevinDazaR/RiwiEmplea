    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;
    using RiwiEmplea.Applications.Interfaces;
    using RiwiEmplea.Dtos.Users;
    using RiwiEmplea.Models;

    namespace RiwiEmplea.Applications.Controllers.Users
    {
        public class FormResumeController : Controller
        {
            private readonly IUsersRepository _usersRepository;
            private readonly ILogger<FormResumeController> _logger;

            public FormResumeController(IUsersRepository usersRepository, ILogger<FormResumeController> logger)
            {
                _usersRepository = usersRepository;
                _logger = logger;
            }

           // GET: Details/Details
            public IActionResult PersonalInfo()
            {
                return View();
            }

        }
    }
