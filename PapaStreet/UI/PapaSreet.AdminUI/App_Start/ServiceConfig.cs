using AutoMapper;
using LightInject;
using PapaSreet.AdminUI.ServiceFacades;
using PapaStreet.BLL.Repositories;
using PapaStreet.BLL.Services;
using PapaStreet.DAL.Repositories;

namespace PapaSreet.AdminUI.App_Start
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
            serviceContainer.Register<UserServiceFacade>(Lifetime);

            serviceContainer.Register<CityServiceFacade>(Lifetime);
            serviceContainer.Register<AnnouncementTypeServiceFacade>(Lifetime);
            serviceContainer.Register<DocumentTypeServiceFacade>(Lifetime);
            serviceContainer.Register<RepairServiceFacade>(Lifetime);
            serviceContainer.Register<PropertyTypeServiceFacade>(Lifetime);
            serviceContainer.Register<ManageUsersServiceFacade>(Lifetime);
            serviceContainer.Register<AnnouncementManageServiceFacade>(Lifetime);
            serviceContainer.Register<AnnouncementImageServiceFacade>(Lifetime);
            serviceContainer.Register<PhoneNumberServiceFacade>(Lifetime);
            serviceContainer.Register<CommonServiceFacade>(Lifetime);
            serviceContainer.Register<CustomerServiceFacade>(Lifetime);
            serviceContainer.Register<CustomerPhoneServiceFacade>(Lifetime);
            serviceContainer.Register<RegionServiceFacade>(Lifetime);
            serviceContainer.Register<RegionDepartamentServiceFacade>(Lifetime);
            serviceContainer.Register<DepartamentServiceFacade>(Lifetime);
            serviceContainer.Register<DepartamentCityServiceFacade>(Lifetime);
            serviceContainer.Register<PricePlanServiceFacade>(Lifetime);
            serviceContainer.Register<PricePlanHistoryServiceFacade>(Lifetime);
            serviceContainer.Register<FrequencyServiceFacade>(Lifetime);
            serviceContainer.Register<AnnouncementAdditionServiceFacade>(Lifetime);
            serviceContainer.Register<GenericAnnouncementServiceFacade>(Lifetime);

        }

        private static void RegisterServices(ServiceContainer serviceContainer)
        {
            serviceContainer.Register<UserService>(Lifetime);

            serviceContainer.Register<CustomerService>(Lifetime);
            serviceContainer.Register<CustomerPhoneNumberService>(Lifetime);
            serviceContainer.Register<CityService>(Lifetime);
            serviceContainer.Register<AnnouncementService>(Lifetime);
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
            serviceContainer.Register<PricePlanHistoryService>(Lifetime);
            serviceContainer.Register<FrequencyService>(Lifetime);
            serviceContainer.Register<AnnouncementAdditionService>(Lifetime);
            serviceContainer.Register<GenericAnnouncementService>(Lifetime);
        }

        private static void RegisterRepositories(ServiceContainer serviceContainer)
        {
            serviceContainer.Register<IUserRepository,UserRepository>(Lifetime);
            serviceContainer.Register<ICustomerRepository, CustomerRepository>(Lifetime);
            serviceContainer.Register<ICustomerPhoneNumberRepository, CustomerPhoneNumberRepository>(Lifetime);
            serviceContainer.Register<ICityRepository, CityRepository>(Lifetime);
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
            serviceContainer.Register<IPricePlanHistoryRepository, PricePlanHistoryRepository>(Lifetime);
            serviceContainer.Register<IFrequencyRepository, FrequencyRepository>(Lifetime);
            serviceContainer.Register<IAnnouncementAdditionRepository, AnnouncementAdditionRepository>(Lifetime);
            serviceContainer.Register<IGenericAnnouncementRepository, GenericAnnouncementRepository>(Lifetime);
        }

        private static void RegisterMappers()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<MapperConfigAdmin>();
                cfg.AddProfile<PapaStreet.DAL.DataContexts.MapperConfig>();
            });

        }
        private static ILifetime Lifetime
        {
            get { return new PerContainerLifetime(); }
        }
    }
}