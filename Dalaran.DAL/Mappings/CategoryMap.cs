using Dalaran.DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Dalaran.DAL.Mappings
{
    public partial class CategoryMap: EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            //Table
            this.ToTable("Categories");

            //Columns
            this.Property(x => x.CategoryId).HasColumnName("CategoryId");
            this.Property(x => x.Name).HasColumnName("Name");

            //PK
            this.HasKey(x => x.CategoryId);

            //Properties
            this.Property(x => x.Name)
                .HasMaxLength(45);
        }
    }
}
