using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RiwiEmplea.Applications.Interfaces;
using RiwiEmplea.Models;

namespace RiwiEmplea.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordRecoveryController : ControllerBase
    {
        private readonly IEmailRepository _emailRepository;

        public PasswordRecoveryController(IEmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest model)
        {
            // Genera el token de recuperación de contraseña y la URL
            var resetToken = "generate-reset-token"; // Implementa la lógica para generar el token
            var resetUrl = Url.Action("ResetPassword", "PasswordRecovery", new { token = resetToken }, Request.Scheme);

            // Envía el correo electrónico de recuperación de contraseña
            await _emailRepository.SendEmailAsync(model.Email, "Password Recovery", $"Please reset your password by clicking <a href='{resetUrl}'>here</a>.");

            return Ok(new { Message = "Password recovery email sent." });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest model)
        {
            return Ok(new { Message = "Password has been reset." });
        }
    }

    public class ForgotPasswordRequest
    {
        public string Email { get; set; }
    }

    public class ResetPasswordRequest
    {
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
