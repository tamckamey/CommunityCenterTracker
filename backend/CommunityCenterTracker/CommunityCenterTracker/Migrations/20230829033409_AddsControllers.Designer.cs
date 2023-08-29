﻿// <auto-generated />
using System;
using CommunityCenterTracker.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CommunityCenterTracker.Migrations
{
    [DbContext(typeof(CommunityCenterContext))]
    [Migration("20230829033409_AddsControllers")]
    partial class AddsControllers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CommunityCenterTracker.Model.Bundle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("SectionId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("Bundles");
                });

            modelBuilder.Entity("CommunityCenterTracker.Model.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("BundleId")
                        .HasColumnType("integer");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Note")
                        .HasColumnType("text");

                    b.Property<string>("Seasons")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.HasKey("Id");

                    b.HasIndex("BundleId");

                    b.ToTable("Items");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("CommunityCenterTracker.Model.Section", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("CommunityCenterTracker.Model.Items.Crop", b =>
                {
                    b.HasBaseType("CommunityCenterTracker.Model.Item");

                    b.Property<int>("DaysToGrow")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("Crop");
                });

            modelBuilder.Entity("CommunityCenterTracker.Model.Items.Fish", b =>
                {
                    b.HasBaseType("CommunityCenterTracker.Model.Item");

                    b.Property<string>("Locations")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.Property<string>("Times")
                        .IsRequired()
                        .HasColumnType("jsonb");

                    b.HasDiscriminator().HasValue("Fish");
                });

            modelBuilder.Entity("CommunityCenterTracker.Model.Bundle", b =>
                {
                    b.HasOne("CommunityCenterTracker.Model.Section", "Section")
                        .WithMany("Bundles")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Section");
                });

            modelBuilder.Entity("CommunityCenterTracker.Model.Item", b =>
                {
                    b.HasOne("CommunityCenterTracker.Model.Bundle", null)
                        .WithMany("Items")
                        .HasForeignKey("BundleId");
                });

            modelBuilder.Entity("CommunityCenterTracker.Model.Bundle", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("CommunityCenterTracker.Model.Section", b =>
                {
                    b.Navigation("Bundles");
                });
#pragma warning restore 612, 618
        }
    }
}
