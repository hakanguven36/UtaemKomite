﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UtaemKomite.Models;

namespace UtaemKomite.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("UtaemKomite.Models.Kullar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("admin")
                        .HasColumnType("bit");

                    b.Property<string>("adminCode")
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<string>("cerez")
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<int>("hatali")
                        .HasColumnType("int");

                    b.Property<bool>("hatirla")
                        .HasColumnType("bit");

                    b.Property<DateTime>("kilitliTarih")
                        .HasColumnType("datetime2");

                    b.Property<string>("kulname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("kulpass")
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.HasKey("ID");

                    b.ToTable("Kullar");
                });

            modelBuilder.Entity("UtaemKomite.Models.Prodosya", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("bytenumber")
                        .HasColumnType("int");

                    b.Property<int>("downloads")
                        .HasColumnType("int");

                    b.Property<int>("kulID")
                        .HasColumnType("int");

                    b.Property<string>("orjisim")
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<string>("orjuzantı")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<int>("projeID")
                        .HasColumnType("int");

                    b.Property<string>("sysname")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime>("tarih")
                        .HasColumnType("datetime2");

                    b.Property<int>("versiyon")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Prodosya");
                });

            modelBuilder.Entity("UtaemKomite.Models.Proje", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("durum")
                        .HasColumnType("int");

                    b.Property<bool>("görünür")
                        .HasColumnType("bit");

                    b.Property<string>("isim")
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<int>("kulID")
                        .HasColumnType("int");

                    b.Property<DateTime>("tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Proje");
                });

            modelBuilder.Entity("UtaemKomite.Models.Toplantı", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("gündem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Toplantı");
                });

            modelBuilder.Entity("UtaemKomite.Models.Tutanak", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("ToplantıID")
                        .HasColumnType("int");

                    b.Property<int>("kulID")
                        .HasColumnType("int");

                    b.Property<string>("metin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("projeID")
                        .HasColumnType("int");

                    b.Property<DateTime>("tarih")
                        .HasColumnType("datetime2");

                    b.Property<int>("yazanID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Tutanak");
                });

            modelBuilder.Entity("UtaemKomite.Models.Tutdosya", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("bytenumber")
                        .HasColumnType("int");

                    b.Property<int>("downloads")
                        .HasColumnType("int");

                    b.Property<string>("orjisim")
                        .HasMaxLength(600)
                        .HasColumnType("nvarchar(600)");

                    b.Property<string>("orjuzantı")
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.Property<string>("sysname")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime>("tarih")
                        .HasColumnType("datetime2");

                    b.Property<int>("toplantıID")
                        .HasColumnType("int");

                    b.Property<int>("tutanakID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Tutdosya");
                });
#pragma warning restore 612, 618
        }
    }
}
