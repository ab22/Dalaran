using System.Data.Entity;
using Dalaran.DAL.Mappings;

namespace Dalaran.DAL
{
    public class DalaranContext: DbContext
    {
        public DalaranContext() : base("DalaranContext")
        {
            Database.SetInitializer<DalaranContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CountryMap());
            modelBuilder.Configurations.Add(new StateMap());
            modelBuilder.Configurations.Add(new CityMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            modelBuilder.Configurations.Add(new SubCategoryMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductDescriptionMap());
            modelBuilder.Configurations.Add(new ProductDescriptionTypeMap());
            modelBuilder.Configurations.Add(new ApplicationMessageMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
