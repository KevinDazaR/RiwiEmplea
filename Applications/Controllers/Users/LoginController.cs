using Microsoft.AspNetCore.Mvc;
using RiwiEmplea.Applications.Interfaces.Repositories.Token;
using RiwiEmplea.Infrastructure.Data;
using RiwiEmplea.Models;

namespace RiwiEmplea.Applications.Controllers.Users
{
    public class LoginController : Controller
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly BaseContext _context;
        public LoginController(BaseContext context, ITokenRepository tokenRepository)
        {
            _context = context;
            _tokenRepository = tokenRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromForm] User user)
        {
            /* Organizar mas adelante */
            var usuario = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);
            if (usuario != null)
            {
                string token = _tokenRepository.GetToken(user);

                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized();
                };

                var tokenEncrypt = BCrypt.Net.BCrypt.HashPassword(token);

                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true, // La cookie no será accesible a través de JavaScript
                    Secure = true, // La cookie solo se enviará a través de conexiones HTTPS
                    Expires = DateTime.UtcNow.AddHours(1) // Establecer la expiración de la cookie
                };

                Response.Cookies.Append("jwtToken", tokenEncrypt, cookieOptions);

                return RedirectToAction("Index", "Home");
            }
            else{
                return NotFound("email or password are not correct.");
            }
        }
    }
}