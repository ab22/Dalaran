using System.ComponentModel.DataAnnotations.Schema;
using Dalaran.DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Dalaran.DAL.Mappings
{
    public class ProductDescriptionMap : EntityTypeConfiguration<ProductDescription>
    {
        public ProductDescriptionMap()
        {
            //Table
            this.ToTable("ProductDescriptions");

            //Columns & Properties
            this.Property(x => x.ProductDescriptionId)
                .HasColumnName("ProductDescriptionId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.ProductId)
                .HasColumnName("ProductId");
            this.Property(x => x.ProductDescriptionTypeId)
                .HasColumnName("ProductDescriptionTypeId");
            this.Property(x => x.Description)
                .HasColumnName("Description")
                .HasMaxLength(60);

            //PK
            this.HasKey(x => x.ProductDescriptionId);

            //Relationships
            this.HasRequired(x => x.ProductDescriptionType)
                .WithMany(x => x.ProductDescriptions)
                .HasForeignKey(x => x.ProductDescriptionTypeId);

            this.HasRequired(x => x.Product)
                .WithMany(x => x.ProductDescriptions)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
