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
            CreateMap<UserRequest, UserResponse>();
            CreateMap<ActivityRequest, Activity>();
            CreateMap<Activity, ActivityResponse>();
            CreateMap<UserHasTargetRequest, UserHasTargetResponse>();
            CreateMap<UserHasTargetRequest, UserHasTarget>();
            CreateMap<UserHasTarget, UserHasTargetResponse>();
        }
    }
}
