using PapaSreet.AdminUI.Models;
using PapaStreet.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PapaSreet.AdminUI.App_Start
{
    public class MapperConfigAdmin : AutoMapper.Profile
    {
        public MapperConfigAdmin()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;

            CreateMap<UserViewModel, UserDto>().ReverseMap();
            CreateMap<PropertyTypeViewModel, PropertyTypeDto>().ReverseMap();
            CreateMap<DocumentTypeViewModel, DocumentTypeDto>().ReverseMap();
            CreateMap<AnnouncementTypeViewModel, AnnouncementTypeDto>().ReverseMap();
            CreateMap<RepairViewModel, RepairDto>().ReverseMap();
            CreateMap<CityViewModel, CityDto>().ReverseMap();
            CreateMap<PhoneNumberViewModel,PhoneNumberDto>().ReverseMap();
            CreateMap<AnnouncementImageViewModel, AnnouncementImageDto>().ReverseMap();
            CreateMap<AnnouncementViewModel, AnnouncementDto>().ReverseMap();
            CreateMap<CustomerViewModel, CustomerDto>().ReverseMap();
            CreateMap<CustomerPhoneViewModel, CustomerPhoneNumberDto>().ReverseMap();
            CreateMap<FrequencyViewModel, FrequencyDto>().ReverseMap();
            CreateMap<PricePlanViewModel, PricePlanDto>().ReverseMap();
            CreateMap<PricePlanHistoryViewModel, PricePlanHistoryDto>().ReverseMap();
            CreateMap<GenericAnnouncementViewModel, GenericAnnouncementDto>().ReverseMap();
        }
    }
}