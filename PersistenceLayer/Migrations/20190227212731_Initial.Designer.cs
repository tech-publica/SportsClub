﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersistenceLayer.EF;

namespace PersistenceLayer.Migrations
{
    [DbContext(typeof(SportsClubContext))]
    [Migration("20190227212731_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SportsClubModel.Domain.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<long>("MemberId");

                    b.Property<string>("StreetAddress");

                    b.Property<string>("StreetNumber");

                    b.Property<string>("ZIP");

                    b.HasKey("Id");

                    b.HasIndex("MemberId")
                        .IsUnique();

                    b.ToTable("Address");
                });

            modelBuilder.Entity("SportsClubModel.Domain.Challenge", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ReservationId");

                    b.Property<string>("Result");

                    b.HasKey("Id");

                    b.ToTable("Challenges");
                });

            modelBuilder.Entity("SportsClubModel.Domain.ChallengeRegistration", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("ChallengeId");

                    b.Property<long>("MemberId");

                    b.Property<string>("Team");

                    b.HasKey("Id");

                    b.HasIndex("ChallengeId");

                    b.HasIndex("MemberId");

                    b.ToTable("ChallengeRegistrations");
                });

            modelBuilder.Entity("SportsClubModel.Domain.Court", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourtType");

                    b.Property<bool>("HasRoof");

                    b.Property<decimal>("HourlyCourtCost");

                    b.Property<decimal>("HourlyIlluminationCost");

                    b.Property<double>("Length");

                    b.Property<int>("Surface");

                    b.Property<double>("Width");

                    b.HasKey("Id");

                    b.ToTable("Courts");

                    b.HasDiscriminator<int>("CourtType");
                });

            modelBuilder.Entity("SportsClubModel.Domain.Member", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Phone");

                    b.HasKey("Id");

                    b.ToTable("Member");
                });

            modelBuilder.Entity("SportsClubModel.Domain.Reservation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("CourtId");

                    b.Property<DateTime>("End");

                    b.Property<long>("MemberId");

                    b.Property<DateTime>("Start");

                    b.HasKey("Id");

                    b.HasIndex("CourtId");

                    b.HasIndex("MemberId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("SportsClubModel.Domain.Skill", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("MemberId");

                    b.Property<string>("Ranking");

                    b.Property<string>("Sport");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("SportsClubModel.Domain.PadelCourt", b =>
                {
                    b.HasBaseType("SportsClubModel.Domain.Court");

                    b.HasDiscriminator().HasValue(1);
                });

            modelBuilder.Entity("SportsClubModel.Domain.TennisCourt", b =>
                {
                    b.HasBaseType("SportsClubModel.Domain.Court");

                    b.HasDiscriminator().HasValue(0);
                });

            modelBuilder.Entity("SportsClubModel.Domain.Address", b =>
                {
                    b.HasOne("SportsClubModel.Domain.Member")
                        .WithOne("Address")
                        .HasForeignKey("SportsClubModel.Domain.Address", "MemberId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SportsClubModel.Domain.ChallengeRegistration", b =>
                {
                    b.HasOne("SportsClubModel.Domain.Challenge", "Challenge")
                        .WithMany("ChallengeRegistrations")
                        .HasForeignKey("ChallengeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SportsClubModel.Domain.Member", "Member")
                        .WithMany("ChallengeRegistrations")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SportsClubModel.Domain.Reservation", b =>
                {
                    b.HasOne("SportsClubModel.Domain.Court", "Court")
                        .WithMany()
                        .HasForeignKey("CourtId");

                    b.HasOne("SportsClubModel.Domain.Member", "Owner")
                        .WithMany("Reservations")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SportsClubModel.Domain.Skill", b =>
                {
                    b.HasOne("SportsClubModel.Domain.Member", "Member")
                        .WithMany("Skills")
                        .HasForeignKey("MemberId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
