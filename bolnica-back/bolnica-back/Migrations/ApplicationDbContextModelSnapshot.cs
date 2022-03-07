﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using bolnica_back.Model;

namespace bolnica_back.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("bolnica_back.Model.Doctor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:IdentitySequenceOptions", "'100', '1', '', '', 'False', '1'")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("EMail")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<bool>("Specialist")
                        .HasColumnType("boolean");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.Property<int>("WorkingDuration")
                        .HasColumnType("integer");

                    b.Property<int>("WorkingStart")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 2L,
                            EMail = "ss@gmail.com",
                            Name = "Stole",
                            Password = "123",
                            Phone = "347237942",
                            Specialist = false,
                            Surname = "Stosic",
                            Username = "stole",
                            WorkingDuration = 5,
                            WorkingStart = 10
                        },
                        new
                        {
                            Id = 3L,
                            EMail = "misa@gmail.com",
                            Name = "Misa",
                            Password = "123",
                            Phone = "7998237",
                            Specialist = false,
                            Surname = "Misic",
                            Username = "misa",
                            WorkingDuration = 8,
                            WorkingStart = 10
                        },
                        new
                        {
                            Id = 4L,
                            EMail = "rada@gmail.com",
                            Name = "Rada",
                            Password = "123",
                            Phone = "480238048",
                            Specialist = false,
                            Surname = "Radic",
                            Username = "rada",
                            WorkingDuration = 4,
                            WorkingStart = 8
                        });
                });

            modelBuilder.Entity("bolnica_back.Model.Review", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:IdentitySequenceOptions", "'100', '1', '', '', 'False', '1'")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("DoctorId")
                        .HasColumnType("bigint");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<bool>("IsCanceled")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DoctorId = 2L,
                            Duration = 30,
                            IsCanceled = false,
                            StartTime = new DateTime(2022, 2, 26, 10, 20, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            DoctorId = 2L,
                            Duration = 30,
                            IsCanceled = false,
                            StartTime = new DateTime(2022, 2, 26, 11, 20, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1L
                        },
                        new
                        {
                            Id = 3L,
                            DoctorId = 2L,
                            Duration = 30,
                            IsCanceled = false,
                            StartTime = new DateTime(2022, 2, 26, 12, 20, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1L
                        },
                        new
                        {
                            Id = 4L,
                            DoctorId = 2L,
                            Duration = 30,
                            IsCanceled = false,
                            StartTime = new DateTime(2022, 12, 26, 12, 20, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1L
                        });
                });

            modelBuilder.Entity("bolnica_back.Model.ReviewRating", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:IdentitySequenceOptions", "'100', '1', '', '', 'False', '1'")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<int>("Grade")
                        .HasColumnType("integer");

                    b.Property<long>("ReviewId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ReviewId")
                        .IsUnique();

                    b.ToTable("ReviewRatings");
                });

            modelBuilder.Entity("bolnica_back.Model.Survey", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:IdentitySequenceOptions", "'100', '1', '', '', 'False', '1'")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Grade")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAnonymous")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPublished")
                        .HasColumnType("boolean");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Surveys");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Comment = "Neki komentar 1",
                            CreationDate = new DateTime(2021, 12, 10, 10, 10, 10, 0, DateTimeKind.Unspecified),
                            Grade = 4,
                            IsAnonymous = false,
                            IsPublished = false,
                            UserId = 1L
                        },
                        new
                        {
                            Id = 2L,
                            Comment = "Neki komentar 2",
                            CreationDate = new DateTime(2022, 1, 12, 12, 30, 55, 0, DateTimeKind.Unspecified),
                            Grade = 3,
                            IsAnonymous = true,
                            IsPublished = false,
                            UserId = 1L
                        },
                        new
                        {
                            Id = 3L,
                            Comment = "Neki komentar 3",
                            CreationDate = new DateTime(2021, 10, 1, 8, 21, 22, 0, DateTimeKind.Unspecified),
                            Grade = 5,
                            IsAnonymous = false,
                            IsPublished = false,
                            UserId = 1L
                        });
                });

            modelBuilder.Entity("bolnica_back.Model.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:IdentitySequenceOptions", "'100', '1', '', '', 'False', '1'")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("EMail")
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("boolean");

                    b.Property<string>("Jmbg")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Address = "Svetosavska 11",
                            EMail = "pp@gmail.com",
                            Gender = 0,
                            IsAdmin = false,
                            IsBlocked = false,
                            Jmbg = "123123123",
                            Name = "Petar",
                            Password = "123",
                            PhoneNumber = "023857197",
                            Surname = "Petrovic",
                            Username = "pera"
                        },
                        new
                        {
                            Id = 2L,
                            Address = "Dositejeva 2",
                            EMail = "mm@gmail.com",
                            Gender = 0,
                            IsAdmin = false,
                            IsBlocked = false,
                            Jmbg = "321321321",
                            Name = "Mika",
                            Password = "123",
                            PhoneNumber = "023857555",
                            Surname = "Mikic",
                            Username = "mika"
                        },
                        new
                        {
                            Id = 3L,
                            Address = "Pupinova 222",
                            EMail = "nn@gmail.com",
                            Gender = 1,
                            IsAdmin = true,
                            IsBlocked = false,
                            Jmbg = "98989898",
                            Name = "Nadica",
                            Password = "123",
                            PhoneNumber = "023857999",
                            Surname = "Nadic",
                            Username = "nada"
                        });
                });

            modelBuilder.Entity("bolnica_back.Model.Review", b =>
                {
                    b.HasOne("bolnica_back.Model.Doctor", "Doctor")
                        .WithMany("Reviews")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("bolnica_back.Model.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("bolnica_back.Model.ReviewRating", b =>
                {
                    b.HasOne("bolnica_back.Model.Review", "Review")
                        .WithOne("Rating")
                        .HasForeignKey("bolnica_back.Model.ReviewRating", "ReviewId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("bolnica_back.Model.Survey", b =>
                {
                    b.HasOne("bolnica_back.Model.User", "User")
                        .WithMany("Surveys")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
