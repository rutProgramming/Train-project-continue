using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Train_project.API.Models;
using Train_project.Core.Entities;

namespace Train_project.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeEntity, EmployeeDto>().ReverseMap();
            CreateMap<PublicInquiryEntity, PublicInquiryDto>().ReverseMap();
            CreateMap<StationEntity, StationDto>().ReverseMap();
            CreateMap<TrainEntity, TrainDto>().ReverseMap();
            CreateMap<TrainRouteEntity, TrainRouteDto>().ReverseMap();
        }
    }
}
