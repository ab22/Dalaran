﻿using System.ComponentModel.DataAnnotations.Schema;
using Dalaran.DAL.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Dalaran.DAL.Mappings
{
    public class StateMap: EntityTypeConfiguration<State>
    {
        public StateMap()
        {
            //Table
            this.ToTable("States");

            //Columns
            this.Property(x => x.StateId)
                .HasColumnName("StateId")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(x => x.Name)
                .HasColumnName("Name")
                .HasMaxLength(45);
            this.Property(x => x.CountryId)
                .HasColumnName("CountryId");

            //PK
            this.HasKey(x => x.StateId);

            //Relationships
            this.HasRequired(x => x.Country)
                .WithMany(x => x.States)
                .HasForeignKey(x => x.CountryId);
        }
    }
}
