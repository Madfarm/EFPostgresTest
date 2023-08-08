﻿// <auto-generated />
using System;
using EFPostTest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EFPostgresTest.Migrations
{
    [DbContext(typeof(PsqlDbContext))]
    partial class PsqlDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EFPostTest.Models.Collection", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CollectionsTable");
                });

            modelBuilder.Entity("EFPostTest.Models.Jacket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("CollectionId")
                        .HasColumnType("integer");

                    b.Property<string>("Material")
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.Property<int>("Size")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CollectionId");

                    b.ToTable("JacketsTable");
                });

            modelBuilder.Entity("EFPostTest.Models.Jacket", b =>
                {
                    b.HasOne("EFPostTest.Models.Collection", null)
                        .WithMany("Jackets")
                        .HasForeignKey("CollectionId");
                });

            modelBuilder.Entity("EFPostTest.Models.Collection", b =>
                {
                    b.Navigation("Jackets");
                });
#pragma warning restore 612, 618
        }
    }
}
