using AutoMapper;
using SportActivityAPI.Repository.Models;
using SportActivityAPI.Service.Models.Requests;
using SportActivityAPI.Service.Models.Responses;

namespace SportActivityAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRequest, User>();
            CreateMap<User, UserResponse>();
            CreateMap<ActivityRequest, Activity>();
            CreateMap<Activity, ActivityResponse>();
        }
    }
}
