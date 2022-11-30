﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WSRQuoterAPI.Models;

namespace WSRQuoterAPI.Migrations
{
    [DbContext(typeof(InsuranceDBContext))]
    [Migration("20221129185531_ValidIntervalCodes")]
    partial class ValidIntervalCodes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.30")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WSRQuoterAPI.Models.Agent", b =>
                {
                    b.Property<int>("AgentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AgentFirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AgentLastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AgentId");

                    b.ToTable("Agents");
                });

            modelBuilder.Entity("WSRQuoterAPI.Models.CoverageLevel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoveragePercentage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CoverageLevels");
                });

            modelBuilder.Entity("WSRQuoterAPI.Models.IntervalCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Months")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("IntervalCodes");
                });

            modelBuilder.Entity("WSRQuoterAPI.Models.PolicyHolder", b =>
                {
                    b.Property<int>("PolicyHolderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PolicyId")
                        .HasColumnType("int");

                    b.HasKey("PolicyHolderId");

                    b.ToTable("PolicyHolders");
                });

            modelBuilder.Entity("WSRQuoterAPI.Models.RainfallYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RainfallYears");
                });

            modelBuilder.Entity("WSRQuoterAPI.Models.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("States");
                });

            modelBuilder.Entity("WSRQuoterAPI.Models.USDACode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IntendedUse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IrrigationPractice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganicPractice")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("USDACodes");
                });

            modelBuilder.Entity("WSRQuoterAPI.Models.USDADtos.County", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Counties");
                });

            modelBuilder.Entity("WSRQuoterAPI.Models.USDADtos.SubCounty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GridId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StateCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SubCounties");
                });

            modelBuilder.Entity("WSRQuoterAPI.Models.ValidIntervalCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CountyCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CoveragePercentage")
                        .HasColumnType("int");

                    b.Property<string>("GridId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IntendedUse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IntervalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IntervalIsValid")
                        .HasColumnType("bit");

                    b.Property<string>("IrrigationPractice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganicPractice")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PremiumRate")
                        .HasColumnType("float");

                    b.Property<string>("StateCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ValidIntervalCodes");
                });
#pragma warning restore 612, 618
        }
    }
}
