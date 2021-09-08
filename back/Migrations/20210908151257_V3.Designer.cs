﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using back.Models;

namespace back.Migrations
{
    [DbContext(typeof(BibliotekaContext))]
    [Migration("20210908151257_V3")]
    partial class V3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("back.Models.Biblioteka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Naziv");

                    b.HasKey("Id");

                    b.ToTable("biblioteka");
                });

            modelBuilder.Entity("back.Models.Knjiga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Naziv")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Naziv");

                    b.Property<int?>("RedId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RedId");

                    b.ToTable("knjiga");
                });

            modelBuilder.Entity("back.Models.Red", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BibliotekaId")
                        .HasColumnType("int");

                    b.Property<string>("Zanr")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Naziv");

                    b.HasKey("Id");

                    b.HasIndex("BibliotekaId");

                    b.ToTable("red");
                });

            modelBuilder.Entity("back.Models.Knjiga", b =>
                {
                    b.HasOne("back.Models.Red", null)
                        .WithMany("knjige")
                        .HasForeignKey("RedId");
                });

            modelBuilder.Entity("back.Models.Red", b =>
                {
                    b.HasOne("back.Models.Biblioteka", null)
                        .WithMany("redovi")
                        .HasForeignKey("BibliotekaId");
                });

            modelBuilder.Entity("back.Models.Biblioteka", b =>
                {
                    b.Navigation("redovi");
                });

            modelBuilder.Entity("back.Models.Red", b =>
                {
                    b.Navigation("knjige");
                });
#pragma warning restore 612, 618
        }
    }
}