    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;
    using RiwiEmplea.Applications.Interfaces;
    using RiwiEmplea.Dtos.Users;
    using RiwiEmplea.Models;
using RiwiEmplea.Dtos.PersonalData;

namespace RiwiEmplea.Applications.Controllers.Users
    {
        public class FormResumeController : Controller
        {
            private readonly IPersonalDataService _personalDataService;

            public FormResumeController(IPersonalDataService personalDataService)
            {
                _personalDataService = personalDataService;
            }

           // GET: Details/Details
            public async Task<IActionResult> Index()
            {
                PersonalDataDTO userData = await _personalDataService.GetPersonalDataAsync(1);

                return View(userData);
            }

        }
    }
