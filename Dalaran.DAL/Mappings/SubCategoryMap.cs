using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Dalaran.DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Dalaran.DAL.Mappings
{
    public partial class SubCategoryMap : EntityTypeConfiguration<SubCategory>
    {
        public SubCategoryMap()
        {
            //Table
            this.ToTable("SubCategories");

            //Columns
            this.Property(x => x.SubCategoryId)
                .HasColumnName("SubCategoryId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(45);
            this.Property(x => x.CategoryId)
                .HasColumnName("CategoryId");

            //PK
            this.HasKey(x => x.SubCategoryId);

            //Properties
            this.Property(x => x.Name)
                .HasMaxLength(45);

            //Relationships
            this.HasRequired(x => x.Category)
                .WithMany(x => x.SubCategories)
                .HasForeignKey(x => x.CategoryId);
        }
    }
}
