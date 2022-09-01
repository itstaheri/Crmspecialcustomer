﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Request.Infrastructure.Database;

#nullable disable

namespace Request.Infrastructure.Migrations
{
    [DbContext(typeof(RequestDbContext))]
    [Migration("20220829084115_addconfirm")]
    partial class addconfirm
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Request.Domain.RequestAgg.RequestModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("ApplicantName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("CityId")
                        .HasColumnType("bigint");

                    b.Property<string>("ConstantPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<long>("CustomerCode")
                        .HasColumnType("bigint");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsConfirm")
                        .HasColumnType("bit");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ServiceId")
                        .HasColumnType("bigint");

                    b.Property<long>("StateId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("requests");
                });

            modelBuilder.Entity("Request.Domain.RequestServiceAgg.ServiceModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("requestModelId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("requestModelId");

                    b.ToTable("services");
                });

            modelBuilder.Entity("Request.Domain.RequestServiceAgg.ServiceModel", b =>
                {
                    b.HasOne("Request.Domain.RequestAgg.RequestModel", "requestModel")
                        .WithMany("services")
                        .HasForeignKey("requestModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("requestModel");
                });

            modelBuilder.Entity("Request.Domain.RequestAgg.RequestModel", b =>
                {
                    b.Navigation("services");
                });
#pragma warning restore 612, 618
        }
    }
}
