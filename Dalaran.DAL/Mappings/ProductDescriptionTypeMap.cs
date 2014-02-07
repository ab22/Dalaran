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

            //Columns & Properties
            this.Property(x => x.ProductDescriptionTypeId)
                .HasColumnName("ProductDescriptionTypeId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Description)
                .HasColumnName("Description")
                .HasMaxLength(60);

            //PK
            this.HasKey(x => x.ProductDescriptionTypeId);
        }
    }
}
