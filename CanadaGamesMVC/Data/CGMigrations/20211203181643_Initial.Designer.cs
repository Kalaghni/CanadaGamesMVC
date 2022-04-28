﻿// <auto-generated />
using System;
using CanadaGamesMVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CanadaGamesMVC.Data.CGMigrations
{
    [DbContext(typeof(CanadaGamesContext))]
    [Migration("20211203181643_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("CG")
                .HasAnnotation("ProductVersion", "3.1.21");

            modelBuilder.Entity("CanadaGamesMVC.Models.Athlete", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Affiliation")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(255);

                    b.Property<string>("AthleteCode")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(7);

                    b.Property<int?>("CoachID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContingentID")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<int>("GenderID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Goals")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(255);

                    b.Property<int>("Height")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HometownID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("MediaInfo")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000);

                    b.Property<string>("MiddleName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("Position")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("RoleModel")
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<int>("SportID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Weight")
                        .HasColumnType("INTEGER");

                    b.Property<int>("YearsInSport")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("AthleteCode")
                        .IsUnique();

                    b.HasIndex("CoachID");

                    b.HasIndex("ContingentID");

                    b.HasIndex("GenderID");

                    b.HasIndex("HometownID");

                    b.HasIndex("SportID");

                    b.ToTable("Athletes");
                });

            modelBuilder.Entity("CanadaGamesMVC.Models.AthletePhoto", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AthleteID")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Content")
                        .HasColumnType("BLOB");

                    b.Property<string>("MimeType")
                        .HasColumnType("TEXT")
                        .HasMaxLength(255);

                    b.HasKey("ID");

                    b.HasIndex("AthleteID")
                        .IsUnique();

                    b.ToTable("AthletePhotos");
                });

            modelBuilder.Entity("CanadaGamesMVC.Models.AthleteSport", b =>
                {
                    b.Property<int>("SportID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AthleteID")
                        .HasColumnType("INTEGER");

                    b.HasKey("SportID", "AthleteID");

                    b.HasIndex("AthleteID");

                    b.ToTable("AthleteSports");
                });

            modelBuilder.Entity("CanadaGamesMVC.Models.AthleteThumbnail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AthleteID")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Content")
                        .HasColumnType("BLOB");

                    b.Property<string>("MimeType")
                        .HasColumnType("TEXT")
                        .HasMaxLength(255);

                    b.HasKey("ID");

                    b.HasIndex("AthleteID")
                        .IsUnique();

                    b.ToTable("AthleteThumbnails");
                });

            modelBuilder.Entity("CanadaGamesMVC.Models.Coach", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(100);

                    b.Property<string>("MiddleName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("CanadaGamesMVC.Models.Contingent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(2);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Contingents");
                });

            modelBuilder.Entity("CanadaGamesMVC.Models.Event", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("GenderID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.Property<int>("SportID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(10);

                    b.HasKey("ID");

                    b.HasIndex("GenderID");

                    b.HasIndex("SportID");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("CanadaGamesMVC.Models.FileContent", b =>
                {
                    b.Property<int>("FileContentID")
                        .HasColumnType("INTEGER");

                    b.Property<byte[]>("Content")
                        .HasColumnType("BLOB");

                    b.Property<string>("MimeType")
                        .HasColumnType("TEXT")
                        .HasMaxLength(255);

                    b.HasKey("FileContentID");

                    b.ToTable("FileContent");
                });

            modelBuilder.Entity("CanadaGamesMVC.Models.Gender", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(10);

                    b.HasKey("ID");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("CanadaGamesMVC.Models.Hometown", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContingentID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("ContingentID");

                    b.HasIndex("ID")
                        .IsUnique();

                    b.ToTable("Hometowns");
                });

            modelBuilder.Entity("CanadaGamesMVC.Models.Placement", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AthleteID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comments")
                        .HasColumnType("TEXT")
                        .HasMaxLength(2000);

                    b.Property<int>("EventID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Place")
                        .HasColumnType("INTEGER");

                    b.HasKey("ID");

                    b.HasIndex("EventID");

                    b.HasIndex("AthleteID", "EventID")
                        .IsUnique();

                    b.ToTable("Placements");
                });

            modelBuilder.Entity("CanadaGamesMVC.Models.Sport", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(3);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasMaxLength(50);

                    b.HasKey("ID");

                    b.ToTable("Sports");
                });

            modelBuilder.Entity("CanadaGamesMVC.Models.UploadedFile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FileName")
                        .HasColumnType("TEXT")
                        .HasMaxLength(255);

                    b.HasKey("ID");

                    b.ToTable("UploadedFiles");

                    b.HasDiscriminator<string>("Discriminator").HasValue("UploadedFile");
                });

            modelBuilder.Entity("CanadaGamesMVC.Models.AthleteDocument", b =>
                {
                    b.HasBaseType("CanadaGamesMVC.Models.UploadedFile");

                    b.Property<int>("AthleteID")
                        .HasColumnType("INTEGER");

                    b.HasIndex("AthleteID");

                    b.HasDiscriminator().HasValue("AthleteDocument");
                });

            modelBuilder.Entity("CanadaGamesMVC.Models.Athlete", b =>
                {
                    b.HasOne("CanadaGamesMVC.Models.Coach", "Coach")
                        .WithMany("Athletes")
                        .HasForeignKey("CoachID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CanadaGamesMVC.Models.Contingent", "Contingent")
                        .WithMany("Athletes")
                        .HasForeignKey("ContingentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CanadaGamesMVC.Models.Gender", "Gender")
                        .WithMany("Athletes")
                        .HasForeignKey("GenderID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CanadaGamesMVC.Models.Hometown", "Hometown")
                        .WithMany("Athletes")
                        .HasForeignKey("HometownID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CanadaGamesMVC.Models.Sport", "Sport")
                        .WithMany("Athletes")
                        .HasForeignKey("SportID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CanadaGamesMVC.Models.AthletePhoto", b =>
                {
                    b.HasOne("CanadaGamesMVC.Models.Athlete", "Athlete")
                        .WithOne("AthletePhoto")
                        .HasForeignKey("CanadaGamesMVC.Models.AthletePhoto", "AthleteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CanadaGamesMVC.Models.AthleteSport", b =>
                {
                    b.HasOne("CanadaGamesMVC.Models.Athlete", "Athlete")
                        .WithMany("AthleteSports")
                        .HasForeignKey("AthleteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CanadaGamesMVC.Models.Sport", "Sport")
                        .WithMany("AthleteSports")
                        .HasForeignKey("SportID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CanadaGamesMVC.Models.AthleteThumbnail", b =>
                {
                    b.HasOne("CanadaGamesMVC.Models.Athlete", "Athlete")
                        .WithOne("AthleteThumbnail")
                        .HasForeignKey("CanadaGamesMVC.Models.AthleteThumbnail", "AthleteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CanadaGamesMVC.Models.Event", b =>
                {
                    b.HasOne("CanadaGamesMVC.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CanadaGamesMVC.Models.Sport", "Sport")
                        .WithMany("Events")
                        .HasForeignKey("SportID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CanadaGamesMVC.Models.FileContent", b =>
                {
                    b.HasOne("CanadaGamesMVC.Models.UploadedFile", "UploadedFile")
                        .WithOne("FileContent")
                        .HasForeignKey("CanadaGamesMVC.Models.FileContent", "FileContentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CanadaGamesMVC.Models.Hometown", b =>
                {
                    b.HasOne("CanadaGamesMVC.Models.Contingent", "Contingent")
                        .WithMany("Hometowns")
                        .HasForeignKey("ContingentID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CanadaGamesMVC.Models.Placement", b =>
                {
                    b.HasOne("CanadaGamesMVC.Models.Athlete", "Athlete")
                        .WithMany("Placements")
                        .HasForeignKey("AthleteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CanadaGamesMVC.Models.Event", "Event")
                        .WithMany("Placements")
                        .HasForeignKey("EventID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CanadaGamesMVC.Models.AthleteDocument", b =>
                {
                    b.HasOne("CanadaGamesMVC.Models.Athlete", "Athlete")
                        .WithMany("AthleteDocuments")
                        .HasForeignKey("AthleteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
