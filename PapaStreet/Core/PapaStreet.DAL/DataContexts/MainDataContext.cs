using PapaStreet.DAL.DAOs;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;
using System.Threading.Tasks;

namespace PapaStreet.DAL.DataContexts
{
    public class MainDataContext : DbContext
    {
        public MainDataContext() : base("PapaStreetConStr")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<CustomerDao> Customers { get; set; }
        public DbSet<CustomerPhoneNumberDao> CustomerPhones { get; set; }
        public DbSet<CityDao> Cities { get; set; }
        public DbSet<PhoneNumberDao> PhoneNumbers { get; set; }
        public DbSet<AnnouncementDao> Announcements { get; set; }
        public DbSet<AnnouncementImageDao> AnnouncementImages { get; set; }
        public DbSet<AnnouncementTypeDao> AnnouncementTypes { get; set; }
        public DbSet<DocumentTypeDao> DocumentTypes { get; set; }
        public DbSet<PropertyTypeDao> PropertyTypes { get; set; }
        public DbSet<RepairDao> Repairs { get; set; }
        public DbSet<GenericAnnouncementDao> GenericAnnouncements { get; set; }
        public DbSet<RegionDao> Regions { get; set; }
        public DbSet<RegionDepartamentDao> RegionDepartaments { get; set; }
        public DbSet<DepartamentDao> Departaments { get; set; }
        public DbSet<DepartamentCityDao>  DepartamentCities { get; set; }
        public DbSet<PricePlanDao>  PricePlans { get; set; }
        public DbSet<FrequencyDao>  Frequencies { get; set; }
        public DbSet<PricePlanHistoryDao>  PricePlanHistories { get; set; }
        public DbSet<AnnouncementAdditionDao> AnnouncementAdditions { get; set; }
    }
}
