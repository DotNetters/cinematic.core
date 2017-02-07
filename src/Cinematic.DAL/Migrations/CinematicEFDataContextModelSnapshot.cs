using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Cinematic.DAL;

namespace Cinematic.DAL.Migrations
{
    [DbContext(typeof(CinematicEFDataContext))]
    partial class CinematicEFDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("Cinematic.Domain.Seat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Reserved");

                    b.Property<int>("Row");

                    b.Property<int>("SeatNumber");

                    b.Property<int?>("SessionId");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("Cinematic.Domain.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Status");

                    b.Property<DateTime>("TimeAndDate");

                    b.HasKey("Id");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("Cinematic.Domain.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Price");

                    b.Property<int?>("SeatId");

                    b.Property<DateTime>("TimeAndDate");

                    b.HasKey("Id");

                    b.HasIndex("SeatId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Cinematic.Domain.Seat", b =>
                {
                    b.HasOne("Cinematic.Domain.Session", "Session")
                        .WithMany()
                        .HasForeignKey("SessionId");
                });

            modelBuilder.Entity("Cinematic.Domain.Ticket", b =>
                {
                    b.HasOne("Cinematic.Domain.Seat", "Seat")
                        .WithMany()
                        .HasForeignKey("SeatId");
                });
        }
    }
}
