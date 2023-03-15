﻿// <auto-generated />
using System;
using InsurancePoliciesAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InsurancePoliciesAPI.Migrations
{
    [DbContext(typeof(InsurancePoliciesContext))]
    [Migration("20230315034853_AddSeedData")]
    partial class AddSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoveragePolicy", b =>
                {
                    b.Property<int>("CoveragesID")
                        .HasColumnType("int");

                    b.Property<int>("PoliciesID")
                        .HasColumnType("int");

                    b.HasKey("CoveragesID", "PoliciesID");

                    b.HasIndex("PoliciesID");

                    b.ToTable("CoveragePolicy");
                });

            modelBuilder.Entity("CustomerPolicy", b =>
                {
                    b.Property<int>("CustomersID")
                        .HasColumnType("int");

                    b.Property<int>("PoliciesID")
                        .HasColumnType("int");

                    b.HasKey("CustomersID", "PoliciesID");

                    b.HasIndex("PoliciesID");

                    b.ToTable("CustomerPolicy");
                });

            modelBuilder.Entity("InsurancePoliciesAPI.Models.Coverage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Coverage", (string)null);
                });

            modelBuilder.Entity("InsurancePoliciesAPI.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentIdentity")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("DocumentIdentity")
                        .IsUnique();

                    b.ToTable("Customer", (string)null);
                });

            modelBuilder.Entity("Policy", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateInit")
                        .HasColumnType("datetime2");

                    b.Property<int>("MaxCoverage")
                        .HasColumnType("int");

                    b.Property<string>("PolicyNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("PolicyNumber")
                        .IsUnique();

                    b.ToTable("Policy", (string)null);
                });

            modelBuilder.Entity("PolicyCoverage", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CoverageID")
                        .HasColumnType("int");

                    b.Property<int>("PolicyID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CoverageID");

                    b.HasIndex("PolicyID");

                    b.ToTable("PolicyCoverage");
                });

            modelBuilder.Entity("PolicyVehicle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<DateTime>("DateGot")
                        .HasColumnType("datetime2");

                    b.Property<int>("PolicyID")
                        .HasColumnType("int");

                    b.Property<int>("VehicleID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PolicyID");

                    b.HasIndex("VehicleID");

                    b.ToTable("PolicyVehicle");
                });

            modelBuilder.Entity("Vehicle", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<bool>("HaveItInspection")
                        .HasColumnType("bit");

                    b.Property<int>("Model")
                        .HasColumnType("int");

                    b.Property<string>("NumberPlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("NumberPlate")
                        .IsUnique();

                    b.ToTable("Vehicle", (string)null);
                });

            modelBuilder.Entity("CoveragePolicy", b =>
                {
                    b.HasOne("InsurancePoliciesAPI.Models.Coverage", null)
                        .WithMany()
                        .HasForeignKey("CoveragesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Policy", null)
                        .WithMany()
                        .HasForeignKey("PoliciesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CustomerPolicy", b =>
                {
                    b.HasOne("InsurancePoliciesAPI.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Policy", null)
                        .WithMany()
                        .HasForeignKey("PoliciesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PolicyCoverage", b =>
                {
                    b.HasOne("InsurancePoliciesAPI.Models.Coverage", "Coverage")
                        .WithMany()
                        .HasForeignKey("CoverageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Policy", "Policy")
                        .WithMany()
                        .HasForeignKey("PolicyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coverage");

                    b.Navigation("Policy");
                });

            modelBuilder.Entity("PolicyVehicle", b =>
                {
                    b.HasOne("Policy", "Policy")
                        .WithMany()
                        .HasForeignKey("PolicyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vehicle", "Vehicle")
                        .WithMany()
                        .HasForeignKey("VehicleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Policy");

                    b.Navigation("Vehicle");
                });

            modelBuilder.Entity("Vehicle", b =>
                {
                    b.HasOne("InsurancePoliciesAPI.Models.Customer", "Customer")
                        .WithMany("Vehicles")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("InsurancePoliciesAPI.Models.Customer", b =>
                {
                    b.Navigation("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
