﻿// <auto-generated />
using System;
using DemoAPI.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DemoAPI.Migrations
{
    [DbContext(typeof(DbApontamentoHoras))]
    partial class DbApontamentoHorasModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("DemoAPI.Models.Classes.ApontamentoDeHoras", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Data")
                        .HasColumnType("TEXT");

                    b.Property<string>("HoraFimManha")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HoraFimTarde")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HoraInicioManha")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HoraInicioTarde")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ApontamentoDeHoras");
                });
#pragma warning restore 612, 618
        }
    }
}
