
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

            //Columns & Properties
            this.Property(x => x.CountryId)
                .HasColumnName("CountryId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(45);

            //PK
            this.HasKey(x => x.CountryId);
        }
    }
}
