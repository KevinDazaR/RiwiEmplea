using AutoMapper;
using RiwiEmplea.Dtos.Users;
using RiwiEmplea.Models;

namespace RiwiEmplea.Applications.Utils.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<UsersDTO, User>()
                .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.RoleId));

            CreateMap<User, UsersDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName));
        }
    }
}
