using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RiwiEmplea.Applications.Interfaces;
using RiwiEmplea.Applications.Services.Repositories;
using RiwiEmplea.Dtos.Users;
using RiwiEmplea.Models;
using System.Threading.Tasks;

namespace RiwiEmplea.Applications.Controllers.Users
{
    public class PasswordRecoveryController : Controller
    {
        private readonly IEmailRepository _emailRepository;
        private readonly IUsersRepository _userRepository;
        private readonly ILogger<PasswordRecoveryController> _logger;

        public PasswordRecoveryController(IEmailRepository emailRepository, IUsersRepository userRepository, ILogger<PasswordRecoveryController> logger)
        {
            _emailRepository = emailRepository;
            _userRepository = userRepository;
            _logger = logger;
        }

        // Acción para mostrar el formulario de recuperación de contraseña
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        // Acción para manejar el envío del formulario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            if (ModelState.IsValid)
            {
                var user = await _userRepository.GetUserByEmailAsync(forgotPasswordDto.Email);
                if (user == null)
                {
                    ModelState.AddModelError(string.Empty, "User not found.");
                    return View(forgotPasswordDto);
                }

                var password = user.Password;
                var subject = "Recuperación de contraseña";
                var body = $"Su contraseña es: {password}";

                await _emailRepository.SendEmailAsync(forgotPasswordDto.Email, subject, body);
                return RedirectToAction("ForgotPasswordConfirmation");
            }

            return View(forgotPasswordDto);
        }

        // Acción para mostrar la confirmación de envío del correo
        [HttpGet]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }
    }
}