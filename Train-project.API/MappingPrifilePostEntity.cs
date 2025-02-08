using AutoMapper;
using Train_project.API.Models;
using Train_project.Core.Entities;

namespace Train_project.API
{
    public class MappingPrifilePostEntity:Profile
    {
        public MappingPrifilePostEntity()
        {
            CreateMap<EmployeePostModel, EmployeeDto>();
            CreateMap<PublicInquiryPostModal, PublicInquiryDto>();
            CreateMap<StationPostModal, StationDto>();
            CreateMap<TrainPostModel, TrainDto>();
            CreateMap<TrainRoutePostModal, TrainRouteEntity>();
        }
    }
}
