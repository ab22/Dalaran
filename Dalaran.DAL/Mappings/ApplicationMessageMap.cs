using Dalaran.DAL.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Dalaran.DAL.Mappings
{
    public class ApplicationMessageMap : EntityTypeConfiguration<ApplicationMessage>
    {
        public ApplicationMessageMap()
        {
            //Table Name
            this.ToTable("ApplicationMessage");

            //Columns & Properties
            this.Property(x => x.KeyName)
                .HasMaxLength(45)
                .HasColumnName("KeyName")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.Property(x => x.Message)
                .HasMaxLength(200)
                .HasColumnName("Message");

            //PK
            this.HasKey(x => x.KeyName);
        }
    }
}
