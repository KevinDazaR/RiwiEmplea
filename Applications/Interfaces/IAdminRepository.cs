using System.Collections;
using PagedList;
using RiwiEmplea.Models;

namespace RiwiEmplea.Applications.Interfaces
{
    public interface IAdminRepository
    {
        Task<IPagedList<User>> GetUsers(int page, int size);
    }
}