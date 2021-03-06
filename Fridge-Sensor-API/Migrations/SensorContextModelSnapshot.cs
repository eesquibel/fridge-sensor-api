﻿// <auto-generated />
using FridgeSensorAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FridgeSensorAPI.Migrations
{
    [DbContext(typeof(SensorContext))]
    partial class SensorContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("FridgeSensorAPI.Models.Record", b =>
                {
                    b.Property<long>("TimeStamp")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Humidity")
                        .HasColumnType("REAL");

                    b.Property<float>("Temperature")
                        .HasColumnType("REAL");

                    b.HasKey("TimeStamp");

                    b.ToTable("Records");
                });
#pragma warning restore 612, 618
        }
    }
}
