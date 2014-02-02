using Dalaran.DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Dalaran.DAL.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            //Table
            this.ToTable("Products");

            //Columns
            this.Property(x => x.ProductId).HasColumnName("ProductId");
            this.Property(x => x.Name).HasColumnName("Name");
            this.Property(x => x.Description).HasColumnName("Description");
            this.Property(x => x.Price).HasColumnName("Price");
            this.Property(x => x.Manufacturer).HasColumnName("Manufacturer");
            this.Property(x => x.Model).HasColumnName("Model");
            this.Property(x => x.Upc).HasColumnName("UPC");
            this.Property(x => x.Condition).HasColumnName("Condition");

            //PK
            this.HasKey(x => x.ProductId);

            //Properties
            this.Property(x => x.Condition)
                .HasMaxLength(45);
            this.Property(x => x.Description)
                .HasMaxLength(150);
            this.Property(x => x.Manufacturer)
                .HasMaxLength(45);
            this.Property(x => x.Model)
                .HasMaxLength(45);
            this.Property(x => x.Name)
                .HasMaxLength(45);
            this.Property(x => x.Upc)
                .HasMaxLength(45);

            //Relationships
            this.HasRequired(x => x.User)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.UserId);
        }
    }
}
