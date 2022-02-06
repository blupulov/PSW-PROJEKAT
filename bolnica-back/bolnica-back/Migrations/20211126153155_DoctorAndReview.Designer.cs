﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using bolnica_back.Model;

namespace bolnica_back.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211126153155_DoctorAndReview")]
    partial class DoctorAndReview
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("bolnica_back.Model.Review", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
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
                });

            modelBuilder.Entity("bolnica_back.Model.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
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
                        .HasForeignKey("DoctorId");

                    b.HasOne("bolnica_back.Model.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}
