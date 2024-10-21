﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClassLibrary.Configurations
{
    

    public class MessageConfiguration : IEntityTypeConfiguration<MessageEntity>
    {
        public void Configure(EntityTypeBuilder<MessageEntity> builder)
        {
            builder.HasKey(m => m.Id);

            builder
                .HasOne(m => m.FromVolunteer)
                .WithMany(v => v.MessagesSent) 
                .HasForeignKey(m => m.FromVolunteerId) 
                .OnDelete(DeleteBehavior.Restrict);


            builder
                .HasOne(m => m.ToVolunteer)
                .WithMany(v => v.MessagesReceived) 
                .HasForeignKey(m => m.ToVolunteerId)
                .OnDelete(DeleteBehavior.Restrict); 

            builder.Property(m => m.Text)
                .IsRequired()
                .HasMaxLength(1000); 

            builder.Property(m => m.SentDate).IsRequired();
        }
    }

}
