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
    [DbContext(typeof(CoreContext))]
    [Migration("20240619232250_mig_Menu_2")]
    partial class mig_Menu_2
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

            modelBuilder.Entity("Core.Entities.Concrete.Menu.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentMenuId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Priority")
                        .HasColumnType("int");

                    b.Property<bool>("RecordState")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("To")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ParentMenuId");

                    b.ToTable("Menus", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Concrete.ProcessGroups.ProcessGroup", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

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
                        .HasColumnType("int");

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
                        .HasColumnType("int");

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

            modelBuilder.Entity("Entities.Main.Media", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MediaPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MediaTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("RecordState")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("MediaTypeId");

                    b.ToTable("Medias", (string)null);
                });

            modelBuilder.Entity("Entities.Main.SliderContent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Header")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<bool>("RecordState")
                        .HasColumnType("bit");

                    b.Property<int>("SliderTypeId")
                        .HasColumnType("int");

                    b.Property<string>("To")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SliderTypeId");

                    b.ToTable("SliderContents", (string)null);
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

            modelBuilder.Entity("MeArch.Module.Security.Model.UserIdentity.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RecordState")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Permissions", (string)null);
                });

            modelBuilder.Entity("MeArch.Module.Security.Model.UserIdentity.RoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RecordState")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims", (string)null);
                });

            modelBuilder.Entity("MeArch.Module.Security.Model.UserIdentity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RecordState")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("MeArch.Module.Security.Model.UserIdentity.UserPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<bool>("RecordState")
                        .HasColumnType("bit");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.HasIndex("UserId");

                    b.ToTable("UserPermissions", (string)null);
                });

            modelBuilder.Entity("MeArch.Module.Security.Model.UserIdentity.UserRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("RecordState")
                        .HasColumnType("bit");

                    b.Property<int>("RoleClaimId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleClaimId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoleClaims", (string)null);
                });

            modelBuilder.Entity("Core.Entities.Concrete.Menu.Menu", b =>
                {
                    b.HasOne("Core.Entities.Concrete.Menu.Menu", "ParentMenu")
                        .WithMany()
                        .HasForeignKey("ParentMenuId");

                    b.Navigation("ParentMenu");
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

            modelBuilder.Entity("Entities.Main.Media", b =>
                {
                    b.HasOne("Core.Entities.Concrete.ProcessGroups.TypeLookup", "MediaType")
                        .WithMany()
                        .HasForeignKey("MediaTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MediaType");
                });

            modelBuilder.Entity("Entities.Main.SliderContent", b =>
                {
                    b.HasOne("Core.Entities.Concrete.ProcessGroups.TypeLookup", "SliderType")
                        .WithMany()
                        .HasForeignKey("SliderTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SliderType");
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

            modelBuilder.Entity("MeArch.Module.Security.Model.UserIdentity.UserPermission", b =>
                {
                    b.HasOne("MeArch.Module.Security.Model.UserIdentity.Permission", "Permission")
                        .WithMany("UserPermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeArch.Module.Security.Model.UserIdentity.User", "User")
                        .WithMany("UserPermissions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("User");
                });

            modelBuilder.Entity("MeArch.Module.Security.Model.UserIdentity.UserRoleClaim", b =>
                {
                    b.HasOne("MeArch.Module.Security.Model.UserIdentity.RoleClaim", "RoleClaim")
                        .WithMany("UserRoleClaims")
                        .HasForeignKey("RoleClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MeArch.Module.Security.Model.UserIdentity.User", "User")
                        .WithMany("UserRoleClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoleClaim");

                    b.Navigation("User");
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

            modelBuilder.Entity("MeArch.Module.Security.Model.UserIdentity.Permission", b =>
                {
                    b.Navigation("UserPermissions");
                });

            modelBuilder.Entity("MeArch.Module.Security.Model.UserIdentity.RoleClaim", b =>
                {
                    b.Navigation("UserRoleClaims");
                });

            modelBuilder.Entity("MeArch.Module.Security.Model.UserIdentity.User", b =>
                {
                    b.Navigation("UserPermissions");

                    b.Navigation("UserRoleClaims");
                });
#pragma warning restore 612, 618
        }
    }
}
