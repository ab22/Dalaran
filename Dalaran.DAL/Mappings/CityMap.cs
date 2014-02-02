using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dalaran.DAL.Entities;

namespace Dalaran.DAL.Mappings
{
    public class CityMap : EntityTypeConfiguration<City>
    {
        public CityMap()
        {
            //Table
            this.ToTable("Cities");

            //Columns & Properties
            this.Property(x => x.CityId)
                .HasColumnName("CityId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(45);
            this.Property(x => x.StateId).HasColumnName("StateId");

            //PK
            this.HasKey(x => x.CityId);

            //Properties
            this.Property(x => x.CityId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Name)
                .HasMaxLength(45);

            //Relationships
            this.HasRequired(x => x.State)
                .WithMany(x => x.Cities)
                .HasForeignKey(x => x.StateId);
        }
    }
}
