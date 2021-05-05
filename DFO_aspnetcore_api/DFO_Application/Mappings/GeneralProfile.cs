using AutoMapper;
using DFO_Application.Features.Users.Commands;
using DFO_Application.Features.Users.Queries;
using DFO_Domain.Entities;

namespace DFO_Application.Mappings
{
    public class GeneralProfile: Profile
    {
        public GeneralProfile()
        {
            CreateMap<DFOUser, UserViewModel>().ReverseMap();
            CreateMap<CreateUserCommand, DFOUser>().ReverseMap();
            CreateMap<GetAllUsersQuery, GetAllUsersParameter>();
        }
    }
}