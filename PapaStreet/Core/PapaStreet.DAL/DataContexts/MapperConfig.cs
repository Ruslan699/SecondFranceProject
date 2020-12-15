using PapaStreet.BLL.DTOs;
using PapaStreet.BLL.DTOs.UserDTOs;
using PapaStreet.DAL.DAOs;
using PapaStreet.DAL.DAOs.UserDAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PapaStreet.Common.Constants.Enums;

namespace PapaStreet.DAL.DataContexts
{
    public class MapperConfig : AutoMapper.Profile
    {
        public MapperConfig()
        {
            AllowNullCollections = true;
            AllowNullDestinationValues = true;

            #region ToDto
            CreateMap<CustomerDao, CustomerDto>()
                .ForMember(dest => dest.CustomerNumbers, opt => opt.MapFrom(e=>e.CustomerNumbers.Where(x => x.Status == Status.Active)));

            CreateMap<AnnouncementDao, AnnouncementDto>()
                .ForMember(dest => dest.PhoneNumbers, opt => opt.MapFrom(e => e.PhoneNumbers.Where(x => x.Status == Status.Active)))
                .ForMember(dest => dest.AnnouncementImages, opt => opt.MapFrom(e => e.AnnouncementImages.Where(x => x.Status == Status.Active)));
            #endregion

            #region ToDao
            CreateMap<AnnouncementDto, AnnouncementDao>()
                .ForMember(s => s.AnnouncementType, d => d.Ignore())
                .ForMember(s => s.AnnouncementImages, d => d.Ignore())
                .ForMember(s => s.DocumentType, d => d.Ignore())
                .ForMember(s => s.PhoneNumbers, d => d.Ignore())
                .ForMember(s => s.City, d => d.Ignore())
                .ForMember(s => s.Repair, d => d.Ignore())
                .ForMember(s => s.PropertyType, d => d.Ignore());

            CreateMap<CustomerDto, CustomerDao>();
            CreateMap<CustomerPhoneNumberDto, CustomerPhoneNumberDao>().ReverseMap();
            CreateMap<GenericAnnouncementDto, GenericAnnouncementDao>().ReverseMap();
            CreateMap<AnnouncementImageDto,AnnouncementImageDao>().ReverseMap();
            CreateMap<AnnouncementTypeDto, AnnouncementTypeDao>().ReverseMap();
            CreateMap<DocumentTypeDto,DocumentTypeDao>().ReverseMap();
            CreateMap<RepairDto,RepairDao>().ReverseMap();
            CreateMap<CityDto, CityDao>().ReverseMap();
            CreateMap<PropertyTypeDto,PropertyTypeDao>().ReverseMap();
            CreateMap<PhoneNumberDto,PhoneNumberDao>().ReverseMap();
            CreateMap<RegionDto,RegionDao>().ReverseMap();
            CreateMap<RegionDepartamentDto, RegionDepartamentDao>().ReverseMap();
            CreateMap<DepartamentDto,DepartamentDao>().ReverseMap();
            CreateMap<DepartamentCityDto,DepartamentCityDao>().ReverseMap();
            CreateMap<UserDto, UserDao>().ReverseMap();
            CreateMap<UserClaimDto, UserClaimsDao>().ReverseMap();
            CreateMap<UserRoleDto, UserRoleDao>().ReverseMap();
            CreateMap<UserLoginDto, UserLoginDao>().ReverseMap();
            CreateMap<PricePlanDto, PricePlanDao>().ReverseMap();
            CreateMap<FrequencyDto, FrequencyDao>().ReverseMap();
            CreateMap<PricePlanHistoryDto, PricePlanHistoryDao>().ReverseMap();
            CreateMap<AnnouncementAdditionDto, AnnouncementAdditionDao>().ReverseMap();
            #endregion

        }
    }
}
