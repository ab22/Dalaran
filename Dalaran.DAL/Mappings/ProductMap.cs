﻿using System.ComponentModel.DataAnnotations.Schema;
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

            //Columns & Properties
            this.Property(x => x.ProductId)
                .HasColumnName("ProductId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(45);
            this.Property(x => x.Description)
                .HasColumnName("Description")
                .HasMaxLength(150);
            this.Property(x => x.Price)
                .HasColumnName("Price");
            this.Property(x => x.Manufacturer)
                .HasColumnName("Manufacturer")
                .HasMaxLength(45);
            this.Property(x => x.Model)
                .HasColumnName("Model")
                .HasMaxLength(45);
            this.Property(x => x.Upc)
                .HasColumnName("UPC")
                .HasMaxLength(45);
            this.Property(x => x.Condition)
                .HasColumnName("Condition");

            //PK
            this.HasKey(x => x.ProductId);

            //Relationships
            this.HasRequired(x => x.User)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.UserId);

            this.HasRequired(x => x.SubCategory)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.SubCategoryId);
        }
    }
}
