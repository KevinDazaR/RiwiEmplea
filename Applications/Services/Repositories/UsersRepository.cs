using Microsoft.EntityFrameworkCore;
using AutoMapper;
using RiwiEmplea.Dtos.Users;
using RiwiEmplea.Models;
using RiwiEmplea.Infrastructure.Data;
using RiwiEmplea.Applications.Interfaces;

namespace RiwiEmplea.Applications.Services.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly BaseContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersRepository> _logger;
        private readonly IEmailRepository _emailRepository;

        public UsersRepository(BaseContext context, IMapper mapper, ILogger<UsersRepository> logger, IEmailRepository emailRepository)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _emailRepository = emailRepository;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
        }

public async Task<User> CreateUserAsync(UsersDTO userDTO)
{
    if (userDTO == null)
    {
        _logger.LogError("userDTO is null");
        throw new ArgumentNullException(nameof(userDTO));
    }

    if (string.IsNullOrEmpty(userDTO.Name)) throw new ArgumentException("Name is required.");
    if (string.IsNullOrEmpty(userDTO.Email)) throw new ArgumentException("Email is required.");
    if (string.IsNullOrEmpty(userDTO.Password)) throw new ArgumentException("Password is required.");

    var user = new User
    {
        FullName = userDTO.Name,
        Email = userDTO.Email,
        Password = userDTO.Password,
        RoleId = userDTO.RoleId  // Asegúrate de que esto esté configurado correctamente
    };

    _context.Users.Add(user);
    await _context.SaveChangesAsync();
    var mensajeCustomer = "Usuario creado con éxito!";

    var subject = "RiwiEmplea - Usuario creado!";
    var emailCustomer = user.Email;

    await _emailRepository.SendEmailAsync(emailCustomer, subject, mensajeCustomer);
    return user;
}


        public async Task<User> UpdateUserAsync(int id, UsersDTO userDTO)
        {
            var userToUpdate = await _context.Users.FindAsync(id);
            if (userToUpdate == null)
            {
                _logger.LogError("User not found.");
                return null;
            }

            _mapper.Map(userDTO, userToUpdate);
            await _context.SaveChangesAsync();
            return userToUpdate;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}