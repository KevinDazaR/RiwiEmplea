using System.Collections.Generic;
using System.Threading.Tasks;
using RiwiEmplea.Dtos.Users;
using RiwiEmplea.Models;

namespace RiwiEmplea.Applications.Interfaces
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(UsersDTO userDTO);
        Task<User> UpdateUserAsync(int id, UsersDTO userDTO);
        // Task<User> DeleteUserAsync(int id);
    }
}
