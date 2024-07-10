using AutoMapper;
using RiwiEmplea.Dtos.Users;
using RiwiEmplea.Models;

namespace RiwiEmplea.Applications.Utils.Profiles
{
    public class UsersProfile : Profile
    {
         public UsersProfile()
        {
            CreateMap<UsersDTO, User>().ForAllMembers(options => options.Condition((src, dest, srcMember) => srcMember != null));;
        }
    }
}

