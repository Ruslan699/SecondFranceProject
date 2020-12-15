using AutoMapper;
using LightInject;
using PapaStreet.BLL.Repositories;
using PapaStreet.BLL.Services;
using PapaStreet.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceContainer = LightInject.ServiceContainer;

namespace Papastreet.JobRunner
{
    public static class ServiceConfig
    {
        public static void Register(ServiceContainer serviceContainer)
        {
            Config(serviceContainer);
        }

        private static void Config(ServiceContainer serviceContainer)
        {
            RegisterServices(serviceContainer);
            RegisterRepositories(serviceContainer);
            RegisterMappers();
        }

        private static void RegisterServices(ServiceContainer serviceContainer)
        {
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
        }

        private static void RegisterRepositories(ServiceContainer serviceContainer)
        {
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

        }

        private static void RegisterMappers()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<PapaStreet.DAL.DataContexts.MapperConfig>();
            });

        }

        private static ILifetime Lifetime
        {
            get { return new PerContainerLifetime(); }
        }
    }
}
