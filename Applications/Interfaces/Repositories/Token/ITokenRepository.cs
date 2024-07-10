using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RiwiEmplea.Models;

namespace RiwiEmplea.Applications.Interfaces.Repositories.Token
{
    public interface ITokenRepository
    {
        string GetToken(User user);
    }
}