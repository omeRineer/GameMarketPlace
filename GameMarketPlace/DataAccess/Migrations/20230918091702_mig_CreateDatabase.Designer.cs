﻿// <auto-generated />
using System;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230918091702_mig_CreateDatabase")]
    partial class mig_CreateDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Core.Entities.Concrete.GeneralSettings.GeneralSetting", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<int?>("CacheDuration")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCached")
                        .HasColumnType("bit");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RecordState")
                        .HasColumnType("bit");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GeneralSettings", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Concrete.ProcessGroups.ProcessGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("RecordState")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("ProcessGroups", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Concrete.ProcessGroups.StatusLookup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProcessGroupId")
                        .HasColumnType("int");

                    b.Property<bool>("RecordState")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProcessGroupId");

                    b.ToTable("StatusLookups", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Concrete.ProcessGroups.TypeLookup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProcessGroupId")
                        .HasColumnType("int");

                    b.Property<bool>("RecordState")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ProcessGroupId");

                    b.ToTable("TypeLookups", (string)null);
                });

            modelBuilder.Entity("Entities.Main.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RecordState")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("Entities.Main.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DeveloperId")
                        .HasColumnType("int");

                    b.Property<int?>("DistributorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("RecordState")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Games", (string)null);
                });

            modelBuilder.Entity("Entities.Main.SystemRequirement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DisplayCard")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("OS")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Processor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ram")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RecordState")
                        .HasColumnType("bit");

                    b.Property<string>("Storage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SystemRequirementTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.HasIndex("SystemRequirementTypeId");

                    b.ToTable("SystemRequirements", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Concrete.ProcessGroups.StatusLookup", b =>
                {
                    b.HasOne("Core.Entities.Concrete.ProcessGroups.ProcessGroup", "ProcessGroup")
                        .WithMany("StatusLookup")
                        .HasForeignKey("ProcessGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProcessGroup");
                });

            modelBuilder.Entity("Core.Entities.Concrete.ProcessGroups.TypeLookup", b =>
                {
                    b.HasOne("Core.Entities.Concrete.ProcessGroups.ProcessGroup", "ProcessGroup")
                        .WithMany("TypeLookups")
                        .HasForeignKey("ProcessGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProcessGroup");
                });

            modelBuilder.Entity("Entities.Main.Game", b =>
                {
                    b.HasOne("Entities.Main.Category", "Category")
                        .WithMany("Games")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Entities.Main.SystemRequirement", b =>
                {
                    b.HasOne("Entities.Main.Game", "Game")
                        .WithMany("SystemRequirements")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Concrete.ProcessGroups.TypeLookup", "SystemRequirementType")
                        .WithMany()
                        .HasForeignKey("SystemRequirementTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("SystemRequirementType");
                });

            modelBuilder.Entity("Core.Entities.Concrete.ProcessGroups.ProcessGroup", b =>
                {
                    b.Navigation("StatusLookup");

                    b.Navigation("TypeLookups");
                });

            modelBuilder.Entity("Entities.Main.Category", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("Entities.Main.Game", b =>
                {
                    b.Navigation("SystemRequirements");
                });
#pragma warning restore 612, 618
        }
    }
}