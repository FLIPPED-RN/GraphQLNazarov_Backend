﻿// <auto-generated />
using System;
using ExampleGraphQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ExampleGraphQL.Migrations
{
    [DbContext(typeof(CinemaDbContext))]
    [Migration("20241228004741_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ExampleGraphQL.Models.Hall", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Capacity")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Halls");
                });

            modelBuilder.Entity("ExampleGraphQL.Models.Movie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Duration")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("ExampleGraphQL.Models.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("IsSold")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("integer");

                    b.Property<Guid>("SessionId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("SessionId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("Session", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("HallId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MovieId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("HallId");

                    b.HasIndex("MovieId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("ExampleGraphQL.Models.Ticket", b =>
                {
                    b.HasOne("Session", "Session")
                        .WithMany("Tickets")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");
                });

            modelBuilder.Entity("Session", b =>
                {
                    b.HasOne("ExampleGraphQL.Models.Hall", "Hall")
                        .WithMany("Sessions")
                        .HasForeignKey("HallId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExampleGraphQL.Models.Movie", "Movie")
                        .WithMany("Sessions")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hall");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("ExampleGraphQL.Models.Hall", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("ExampleGraphQL.Models.Movie", b =>
                {
                    b.Navigation("Sessions");
                });

            modelBuilder.Entity("Session", b =>
                {
                    b.Navigation("Tickets");
                });
#pragma warning restore 612, 618
        }
    }
}