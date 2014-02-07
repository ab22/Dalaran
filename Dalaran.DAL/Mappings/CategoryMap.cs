using System.ComponentModel.DataAnnotations.Schema;
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

            //Columns & Properties
            this.Property(x => x.CategoryId)
                .HasColumnName("CategoryId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(45);

            //PK
            this.HasKey(x => x.CategoryId);
        }
    }
}
