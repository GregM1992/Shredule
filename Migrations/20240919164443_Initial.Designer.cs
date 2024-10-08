﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Shredule.Migrations
{
    [DbContext(typeof(ShreduleDbContext))]
    [Migration("20240919164443_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BandUser", b =>
                {
                    b.Property<int>("BandsId")
                        .HasColumnType("integer");

                    b.Property<int>("MembersId")
                        .HasColumnType("integer");

                    b.HasKey("BandsId", "MembersId");

                    b.HasIndex("MembersId");

                    b.ToTable("BandUser");
                });

            modelBuilder.Entity("Shredule.Models.Availability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<bool>("FriMorn")
                        .HasColumnType("boolean");

                    b.Property<bool>("FriNight")
                        .HasColumnType("boolean");

                    b.Property<bool>("MonMorn")
                        .HasColumnType("boolean");

                    b.Property<bool>("MonNight")
                        .HasColumnType("boolean");

                    b.Property<bool>("SatMorn")
                        .HasColumnType("boolean");

                    b.Property<bool>("SatNight")
                        .HasColumnType("boolean");

                    b.Property<bool>("SunMorn")
                        .HasColumnType("boolean");

                    b.Property<bool>("SunNight")
                        .HasColumnType("boolean");

                    b.Property<bool>("ThurMorn")
                        .HasColumnType("boolean");

                    b.Property<bool>("ThurNight")
                        .HasColumnType("boolean");

                    b.Property<bool>("TueMorn")
                        .HasColumnType("boolean");

                    b.Property<bool>("TueNight")
                        .HasColumnType("boolean");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.Property<bool>("WedMorn")
                        .HasColumnType("boolean");

                    b.Property<bool>("WedNight")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Availability");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FriMorn = false,
                            FriNight = false,
                            MonMorn = true,
                            MonNight = true,
                            SatMorn = true,
                            SatNight = true,
                            SunMorn = false,
                            SunNight = false,
                            ThurMorn = false,
                            ThurNight = true,
                            TueMorn = true,
                            TueNight = false,
                            UserId = 1,
                            WedMorn = false,
                            WedNight = true
                        },
                        new
                        {
                            Id = 2,
                            FriMorn = false,
                            FriNight = false,
                            MonMorn = false,
                            MonNight = true,
                            SatMorn = true,
                            SatNight = true,
                            SunMorn = false,
                            SunNight = true,
                            ThurMorn = false,
                            ThurNight = false,
                            TueMorn = true,
                            TueNight = false,
                            UserId = 2,
                            WedMorn = true,
                            WedNight = true
                        });
                });

            modelBuilder.Entity("Shredule.Models.Band", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("LeaderId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Bands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LeaderId = 1,
                            Name = "Cull",
                            Password = "nunusCrawfish",
                            ScheduleId = 1
                        });
                });

            modelBuilder.Entity("Shredule.Models.Practice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BandId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Location")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BandId");

                    b.ToTable("Practices");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BandId = 1,
                            DateTime = new DateTime(24, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Shredule.Models.Show", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BandId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Venue")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BandId");

                    b.ToTable("Shows");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            BandId = 1,
                            DateTime = new DateTime(24, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Venue = "BlackBird Tattoo"
                        });
                });

            modelBuilder.Entity("Shredule.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AvailabilityId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AvailabilityId = 1,
                            Name = "Greg Markus",
                            Password = "PrimusSucks",
                            UserName = "BassBoi92"
                        },
                        new
                        {
                            Id = 2,
                            AvailabilityId = 2,
                            Name = "Elias Macdonald",
                            Password = "ThickieBig",
                            UserName = "BigThickie"
                        },
                        new
                        {
                            Id = 3,
                            AvailabilityId = 3,
                            Name = "Justin Welch",
                            Password = "DerfoBlood",
                            UserName = "JasonWalkerBRI"
                        });
                });

            modelBuilder.Entity("BandUser", b =>
                {
                    b.HasOne("Shredule.Models.Band", null)
                        .WithMany()
                        .HasForeignKey("BandsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shredule.Models.User", null)
                        .WithMany()
                        .HasForeignKey("MembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shredule.Models.Practice", b =>
                {
                    b.HasOne("Shredule.Models.Band", null)
                        .WithMany("Practices")
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shredule.Models.Show", b =>
                {
                    b.HasOne("Shredule.Models.Band", null)
                        .WithMany("Shows")
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Shredule.Models.Band", b =>
                {
                    b.Navigation("Practices");

                    b.Navigation("Shows");
                });
#pragma warning restore 612, 618
        }
    }
}
