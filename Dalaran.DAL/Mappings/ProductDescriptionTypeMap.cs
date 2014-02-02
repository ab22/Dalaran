using System.ComponentModel.DataAnnotations.Schema;
using Dalaran.DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Dalaran.DAL.Mappings
{
    public class ProductDescriptionTypeMap: EntityTypeConfiguration<ProductDescriptionType>
    {
        public ProductDescriptionTypeMap()
        {
            //Table
            this.ToTable("ProductDescriptionTypes");

            //Columns
            this.Property(x => x.ProductDescriptionTypeId).HasColumnName("ProductDescriptionTypeId");
            this.Property(x => x.Description).HasColumnName("Description");

            //PK
            this.HasKey(x => x.ProductDescriptionTypeId);

            //Properties
            this.Property(x => x.Description)
                .HasMaxLength(60);
        }
    }
}
