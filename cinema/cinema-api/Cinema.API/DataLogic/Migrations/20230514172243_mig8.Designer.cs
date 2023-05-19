﻿// <auto-generated />
using System;
using DataLogic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataLogic.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230514172243_mig8")]
    partial class mig8
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataLogic.Entities.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Name")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("DataLogic.Entities.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<Guid?>("PhotoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("DataLogic.Entities.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PublicId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MovieId")
                        .IsUnique();

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("DataLogic.Entities.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("DataLogic.Entities.Seat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Row")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("DataLogic.Entities.Showing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("RoomId");

                    b.ToTable("Showings");
                });

            modelBuilder.Entity("DataLogic.Entities.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SeatId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ShowingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SeatId");

                    b.HasIndex("ShowingId");

                    b.HasIndex("UserId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("DataLogic.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DataLogic.Entities.Genre", b =>
                {
                    b.HasOne("DataLogic.Entities.Movie", "Movie")
                        .WithMany("Genres")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("DataLogic.Entities.Photo", b =>
                {
                    b.HasOne("DataLogic.Entities.Movie", "Movie")
                        .WithOne("Photo")
                        .HasForeignKey("DataLogic.Entities.Photo", "MovieId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("DataLogic.Entities.Seat", b =>
                {
                    b.HasOne("DataLogic.Entities.Room", "Room")
                        .WithMany("Seats")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("DataLogic.Entities.Showing", b =>
                {
                    b.HasOne("DataLogic.Entities.Movie", "Movie")
                        .WithMany("Showings")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DataLogic.Entities.Room", "Room")
                        .WithMany("Showings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("DataLogic.Entities.Ticket", b =>
                {
                    b.HasOne("DataLogic.Entities.Seat", "Seat")
                        .WithMany("Tickets")
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DataLogic.Entities.Showing", "Showing")
                        .WithMany("Tickets")
                        .HasForeignKey("ShowingId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DataLogic.Entities.User", "User")
                        .WithMany("Tickets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Seat");

                    b.Navigation("Showing");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DataLogic.Entities.Movie", b =>
                {
                    b.Navigation("Genres");

                    b.Navigation("Photo");

                    b.Navigation("Showings");
                });

            modelBuilder.Entity("DataLogic.Entities.Room", b =>
                {
                    b.Navigation("Seats");

                    b.Navigation("Showings");
                });

            modelBuilder.Entity("DataLogic.Entities.Seat", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("DataLogic.Entities.Showing", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("DataLogic.Entities.User", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}
