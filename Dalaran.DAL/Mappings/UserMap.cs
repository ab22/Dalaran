using System.ComponentModel.DataAnnotations.Schema;
using Dalaran.DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Dalaran.DAL.Mappings
{
    public class UserMap: EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            //Table
            this.ToTable("Users");

            //Columns
            this.Property(x => x.UserId)
                .HasColumnName("UserId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(45);
            this.Property(x => x.LastName)
                .HasColumnName("LastName")
                .HasMaxLength(45);
            this.Property(x => x.DoB)
                .HasColumnName("DOB");
            this.Property(x => x.Address)
                .HasColumnName("Address")
                .HasMaxLength(45);
            this.Property(x => x.Email)
                .HasColumnName("Email")
                .HasMaxLength(45);
            this.Property(x => x.Password)
                .HasColumnName("Password")
                .HasMaxLength(100);
            this.Property(x => x.PasswordSalt)
                .HasColumnName("PasswordSalt")
                .HasMaxLength(100);
            this.Property(x => x.RegisterDate)
                .HasColumnName("RegisterDate");
            this.Property(x => x.Rating)
                .HasColumnName("Rating");
            this.Property(x => x.CityId)
                .HasColumnName("CityId");
            this.Property(x => x.AccountState)
                .HasColumnName("AccountState");

            //PK
            this.HasKey(x => x.UserId);
            
            //Relationships
            this.HasRequired(x => x.City)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.CityId);
        }
    }
}
