
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Dalaran.DAL.Entities;

namespace Dalaran.DAL.Mappings
{
    public class CountryMap : EntityTypeConfiguration<Country>
    {
        public CountryMap()
        {
            //Table
            this.ToTable("Countries");

            //Columns
            this.Property(x => x.CountryId).HasColumnName("CountryId");
            this.Property(x => x.Name).HasColumnName("Name");

            //PK
            this.HasKey(x => x.CountryId);

            //Properties
            this.Property(x => x.CountryId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(x => x.Name)
                .HasMaxLength(45);
        }
    }
}
