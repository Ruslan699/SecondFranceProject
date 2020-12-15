using PapaStreet.BLL.DTOs;
using PapaStreet.WebUI.Models;
using PapaStreet.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PapaStreet.WebUI.App_Start
{
    public class MapperConfig : AutoMapper.Profile
    {
        public MapperConfig()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;

            CreateMap<CustomerModel, CustomerDto>().ReverseMap();
            CreateMap<CustomerPhoneNumberModel, CustomerPhoneNumberDto>().ReverseMap();
            CreateMap<AnnouncementModel,AnnouncementDto>().ReverseMap();
            CreateMap<AnnouncementImageModel, AnnouncementImageDto>().ReverseMap();
            CreateMap<AnnouncementTypeModel, AnnouncementTypeDto>().ReverseMap();
            CreateMap<DocumentTypeModel, DocumentTypeDto>().ReverseMap();
            CreateMap<RepairModel, RepairDto>().ReverseMap();
            CreateMap<PropertyTypeModel, PropertyTypeDto>().ReverseMap();
            CreateMap<PhoneNumberModel, PhoneNumberDto>().ReverseMap();
            CreateMap<Search, SearchDto>().ReverseMap();
            CreateMap<RegionModel, RegionDto>().ReverseMap();
            CreateMap<RegionDepartamentModel, RegionDepartamentDto>().ReverseMap();
            CreateMap<DepartamentModel, DepartamentDto>().ReverseMap();
            CreateMap<DepartamentCityModel, DepartamentCityDto>().ReverseMap();
            CreateMap<AnnouncementAdditionalModel, AnnouncementAdditionDto>().ReverseMap();
            
        }
    }
}