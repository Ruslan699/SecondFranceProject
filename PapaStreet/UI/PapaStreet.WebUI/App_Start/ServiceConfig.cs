using AutoMapper;
using LightInject;
using PapaStreet.BLL.Repositories;
using PapaStreet.BLL.Services;
using PapaStreet.DAL.DataContexts;
using PapaStreet.DAL.Repositories;
using PapaStreet.WebUI.ServiceFacades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PapaStreet.WebUI.App_Start
{
    public class ServiceConfig
    {
        public static void Register(ServiceContainer serviceContainer)
        {
            Config(serviceContainer);
            serviceContainer.RegisterControllers();
            serviceContainer.EnableMvc();
        }

        private static void Config(ServiceContainer serviceContainer)
        {
            RegisterServiceFacades(serviceContainer);
            RegisterServices(serviceContainer);
            RegisterRepositories(serviceContainer);
            RegisterMappers();
        }

        private static void RegisterServiceFacades(ServiceContainer serviceContainer)
        {
            serviceContainer.Register<CustomerServiceFacade>(Lifetime);
            serviceContainer.Register<CustomerPhoneNumberServiceFacade>(Lifetime);
            serviceContainer.Register<CityServiceFacade>(Lifetime);
            serviceContainer.Register<AnnouncementServiceFacade>(Lifetime);
            serviceContainer.Register<GenericAnnouncementServiceFacade>(Lifetime);
            serviceContainer.Register<AnnouncementImageServiceFacade>(Lifetime);
            serviceContainer.Register<AnnouncementTypeServiceFacade>(Lifetime);
            serviceContainer.Register<DocumentTypeServiceFacade>(Lifetime);
            serviceContainer.Register<RepairServiceFacade>(Lifetime);
            serviceContainer.Register<PropertyTypeServiceFacade>(Lifetime);
            serviceContainer.Register<PhoneNumberServiceFacade>(Lifetime);
            serviceContainer.Register<RegionServiceFacade>(Lifetime);
            serviceContainer.Register<RegionDepartamentServiceFacade>(Lifetime);
            serviceContainer.Register<DepartamentServiceFacade>(Lifetime);
            serviceContainer.Register<DepartamentCityServiceFacade>(Lifetime);
            serviceContainer.Register<CommonServiceFacade>(Lifetime);
            serviceContainer.Register<PricePlanServiceFacade>(Lifetime);
            serviceContainer.Register<FrequencyServiceFacade>(Lifetime);
            serviceContainer.Register<PricePlanHistoryServiceFacade>(Lifetime);
            serviceContainer.Register<AnnouncementAdditionServiceFacade>(Lifetime);
        }

        private static void RegisterServices(ServiceContainer serviceContainer)
        {
            serviceContainer.Register<CustomerService>(Lifetime);
            serviceContainer.Register<CustomerPhoneNumberService>(Lifetime);
            serviceContainer.Register<CityService>(Lifetime);
            serviceContainer.Register<AnnouncementService>(Lifetime);
            serviceContainer.Register<GenericAnnouncementService>(Lifetime);
            serviceContainer.Register<AnnouncementImageService>(Lifetime);
            serviceContainer.Register<AnnouncementTypeService>(Lifetime);
            serviceContainer.Register<DocumentTypeService>(Lifetime);
            serviceContainer.Register<RepairService>(Lifetime);
            serviceContainer.Register<PropertyTypeService>(Lifetime);
            serviceContainer.Register<PhoneNumberService>(Lifetime);
            serviceContainer.Register<RegionService>(Lifetime);
            serviceContainer.Register<RegionDepartamentService>(Lifetime);
            serviceContainer.Register<DepartamentService>(Lifetime);
            serviceContainer.Register<DepartamentCityService>(Lifetime);
            serviceContainer.Register<PricePlanService>(Lifetime);
            serviceContainer.Register<FrequencyService>(Lifetime);
            serviceContainer.Register<PricePlanHistoryService>(Lifetime);
            serviceContainer.Register<AnnouncementAdditionService>(Lifetime);
        }

        private static void RegisterRepositories(ServiceContainer serviceContainer)
        {
            serviceContainer.Register<ICustomerRepository, CustomerRepository>(Lifetime);
            serviceContainer.Register<ICustomerPhoneNumberRepository, CustomerPhoneNumberRepository>(Lifetime);
            serviceContainer.Register<ICityRepository, CityRepository>(Lifetime);
            serviceContainer.Register<IGenericAnnouncementRepository, GenericAnnouncementRepository>(Lifetime);
            serviceContainer.Register<IAnnouncementRepository, AnnouncementRepository>(Lifetime);
            serviceContainer.Register<IAnnouncementImageRepository, AnnouncementImageRepository>(Lifetime);
            serviceContainer.Register<IAnnouncementTypeRepository, AnnouncementTypeRepository>(Lifetime);
            serviceContainer.Register<IDocumentTypeRepository, DocumentTypeRepository>(Lifetime);
            serviceContainer.Register<IRepairRepository, RepairRepository>(Lifetime);
            serviceContainer.Register<IPropertyTypeRepository, PropertyTypeRepository>(Lifetime);
            serviceContainer.Register<IPhoneNumberRepository, PhoneNumberRepository>(Lifetime);
            serviceContainer.Register<IRegionRepository, RegionRepository>(Lifetime);
            serviceContainer.Register<IDepartamentRepository, DepartamentRepository>(Lifetime);
            serviceContainer.Register<IDepartamentCityRepository, DepartamentCityRepository>(Lifetime);
            serviceContainer.Register<IRegionDepartamentRepository, RegionDepartamentRepository>(Lifetime);
            serviceContainer.Register<IPricePlanRepository, PricePlanRepository>(Lifetime);
            serviceContainer.Register<IFrequencyRepository, FrequencyRepository>(Lifetime);
            serviceContainer.Register<IPricePlanHistoryRepository, PricePlanHistoryRepository>(Lifetime);
            serviceContainer.Register<IAnnouncementAdditionRepository, AnnouncementAdditionRepository>(Lifetime);

        }

        private static void RegisterMappers()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<MapperConfig>();
                cfg.AddProfile<DAL.DataContexts.MapperConfig>();
            });

        }

        private static ILifetime Lifetime
        {
            get { return new PerContainerLifetime(); }
        }
    }
}