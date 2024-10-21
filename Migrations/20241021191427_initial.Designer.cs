﻿// <auto-generated />
using System;
using ClassLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ClassLibrary.Migrations
{
    [DbContext(typeof(ProjDbContext))]
    [Migration("20241021191427_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ClassLibrary.Models.ContactPersonEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MilitaryUnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MilitaryUnitId");

                    b.ToTable("ContactPersons");
                });

            modelBuilder.Entity("ClassLibrary.Models.MessageEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FromVolunteerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("ToVolunteerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FromVolunteerId");

                    b.HasIndex("ToVolunteerId");

                    b.ToTable("MessageEntity");
                });

            modelBuilder.Entity("ClassLibrary.Models.MilitaryUnitEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("MilitaryUnits");
                });

            modelBuilder.Entity("ClassLibrary.Models.OrganizationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(18)
                        .HasColumnType("nvarchar(18)");

                    b.HasKey("Id");

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("ClassLibrary.Models.RequestEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CompletedByVolunteerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Importance")
                        .HasColumnType("int");

                    b.Property<int?>("MilitaryUnitEntityId")
                        .HasColumnType("int");

                    b.Property<int>("MilitaryUnitId")
                        .HasColumnType("int");

                    b.Property<int?>("OrganizationCompletedById")
                        .HasColumnType("int");

                    b.Property<int?>("OrganizationTakenById")
                        .HasColumnType("int");

                    b.Property<int?>("TakenByVolunteerId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CompletedByVolunteerId");

                    b.HasIndex("MilitaryUnitEntityId");

                    b.HasIndex("MilitaryUnitId");

                    b.HasIndex("OrganizationCompletedById");

                    b.HasIndex("OrganizationTakenById");

                    b.HasIndex("TakenByVolunteerId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("ClassLibrary.Models.VolunteerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Volunteers");
                });

            modelBuilder.Entity("ClassLibrary.Models.VolunteerOrganizationEntity", b =>
                {
                    b.Property<int>("VolunteerId")
                        .HasColumnType("int");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("JoinedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("VolunteerId", "OrganizationId");

                    b.HasIndex("OrganizationId");

                    b.ToTable("VolunteerOrganizationEntity");
                });

            modelBuilder.Entity("ClassLibrary.Models.ContactPersonEntity", b =>
                {
                    b.HasOne("ClassLibrary.Models.MilitaryUnitEntity", "MilitaryUnit")
                        .WithMany("ContactPeople")
                        .HasForeignKey("MilitaryUnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MilitaryUnit");
                });

            modelBuilder.Entity("ClassLibrary.Models.MessageEntity", b =>
                {
                    b.HasOne("ClassLibrary.Models.VolunteerEntity", "FromVolunteer")
                        .WithMany("MessagesSent")
                        .HasForeignKey("FromVolunteerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ClassLibrary.Models.VolunteerEntity", "ToVolunteer")
                        .WithMany("MessagesReceived")
                        .HasForeignKey("ToVolunteerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FromVolunteer");

                    b.Navigation("ToVolunteer");
                });

            modelBuilder.Entity("ClassLibrary.Models.RequestEntity", b =>
                {
                    b.HasOne("ClassLibrary.Models.VolunteerEntity", "CompletedByVolunteer")
                        .WithMany("CompletedRequests")
                        .HasForeignKey("CompletedByVolunteerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ClassLibrary.Models.MilitaryUnitEntity", null)
                        .WithMany("CompletedRequests")
                        .HasForeignKey("MilitaryUnitEntityId");

                    b.HasOne("ClassLibrary.Models.MilitaryUnitEntity", "MilitaryUnit")
                        .WithMany("ActiveRequests")
                        .HasForeignKey("MilitaryUnitId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ClassLibrary.Models.OrganizationEntity", "OrganizationCompletedBy")
                        .WithMany("CompletedRequests")
                        .HasForeignKey("OrganizationCompletedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("ClassLibrary.Models.OrganizationEntity", "OrganizationTakenBy")
                        .WithMany("ActiveRequests")
                        .HasForeignKey("OrganizationTakenById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("ClassLibrary.Models.VolunteerEntity", "TakenByVolunteer")
                        .WithMany("ActiveRequests")
                        .HasForeignKey("TakenByVolunteerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CompletedByVolunteer");

                    b.Navigation("MilitaryUnit");

                    b.Navigation("OrganizationCompletedBy");

                    b.Navigation("OrganizationTakenBy");

                    b.Navigation("TakenByVolunteer");
                });

            modelBuilder.Entity("ClassLibrary.Models.VolunteerOrganizationEntity", b =>
                {
                    b.HasOne("ClassLibrary.Models.OrganizationEntity", "Organization")
                        .WithMany("VolunteerOrganizations")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClassLibrary.Models.VolunteerEntity", "Volunteer")
                        .WithMany("VolunteerOrganizations")
                        .HasForeignKey("VolunteerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Organization");

                    b.Navigation("Volunteer");
                });

            modelBuilder.Entity("ClassLibrary.Models.MilitaryUnitEntity", b =>
                {
                    b.Navigation("ActiveRequests");

                    b.Navigation("CompletedRequests");

                    b.Navigation("ContactPeople");
                });

            modelBuilder.Entity("ClassLibrary.Models.OrganizationEntity", b =>
                {
                    b.Navigation("ActiveRequests");

                    b.Navigation("CompletedRequests");

                    b.Navigation("VolunteerOrganizations");
                });

            modelBuilder.Entity("ClassLibrary.Models.VolunteerEntity", b =>
                {
                    b.Navigation("ActiveRequests");

                    b.Navigation("CompletedRequests");

                    b.Navigation("MessagesReceived");

                    b.Navigation("MessagesSent");

                    b.Navigation("VolunteerOrganizations");
                });
#pragma warning restore 612, 618
        }
    }
}