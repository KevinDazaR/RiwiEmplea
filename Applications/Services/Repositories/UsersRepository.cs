using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

        public UsersRepository(BaseContext context, IMapper mapper, ILogger<UsersRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
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
                Name = userDTO.Name,
                Email = userDTO.Email,
                Password = userDTO.Password
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
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

        // public async Task<User> DeleteUserAsync(int id)
        // {
        //     var user = await _context.Users.FirstOrDefaultAsync(c => c.Id == id);
        //     if (user != null)
        //     {
        //         user.Status = "inactive";
        //         await _context.SaveChangesAsync();
        //     }
        //     return user;
        // }
    }
}
