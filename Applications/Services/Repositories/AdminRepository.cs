using Microsoft.EntityFrameworkCore;
using PagedList;
using RiwiEmplea.Applications.Interfaces;
using RiwiEmplea.Infrastructure.Data;
using RiwiEmplea.Models;

namespace RiwiEmplea.Applications.Services.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly BaseContext _context;
        public AdminRepository(BaseContext context)
        {
            _context = context;
        }

        public async Task<IPagedList<User>> GetUsers(int page, int size)
        {
            var pageNumber = page > 0 ? page : 1;
            var user = await _context.Users.ToListAsync();
            var StudentPageList = user.ToPagedList((int)pageNumber, size);
            return StudentPageList;
        }
    }
}