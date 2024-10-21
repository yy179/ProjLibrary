using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Configurations
{
    public class MilitaryUnitConfiguration : IEntityTypeConfiguration<MilitaryUnitEntity>
    {
        public void Configure(EntityTypeBuilder<MilitaryUnitEntity> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);

            builder
                .HasMany(x => x.ContactPersons)
                .WithOne(x => x.MilitaryUnit)
                .HasForeignKey(x => x.MilitaryUnitId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.ActiveRequests)
                .WithOne(x => x.MilitaryUnit)
                .HasForeignKey(x => x.MilitaryUnitId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.ActiveRequests)
                .WithOne(x => x.MilitaryUnit)
                .HasForeignKey(x => x.MilitaryUnitId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
