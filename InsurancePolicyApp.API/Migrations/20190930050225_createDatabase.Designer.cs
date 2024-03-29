﻿// <auto-generated />
using System;
using InsurancePolicyApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InsurancePolicyApp.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190930050225_createDatabase")]
    partial class createDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InsurancePolicyApp.API.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("InsurancePolicyApp.API.Models.EventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("EventTypes");
                });

            modelBuilder.Entity("InsurancePolicyApp.API.Models.Policy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CoveragePeriod");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.ToTable("Policies");
                });

            modelBuilder.Entity("InsurancePolicyApp.API.Models.PolicyClient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<int>("PolicyId");

                    b.Property<DateTime>("ValidityStarted");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("PolicyId");

                    b.ToTable("PolicyClient");
                });

            modelBuilder.Entity("InsurancePolicyApp.API.Models.PolicyEventType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventTypeId");

                    b.Property<double>("Percent");

                    b.Property<int>("PolicyId");

                    b.Property<int>("RiskTypeId");

                    b.HasKey("Id");

                    b.HasIndex("EventTypeId");

                    b.HasIndex("PolicyId");

                    b.HasIndex("RiskTypeId");

                    b.ToTable("PolicyEventType");
                });

            modelBuilder.Entity("InsurancePolicyApp.API.Models.RiskType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("RiskTypes");
                });

            modelBuilder.Entity("InsurancePolicyApp.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired();

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("InsurancePolicyApp.API.Models.PolicyClient", b =>
                {
                    b.HasOne("InsurancePolicyApp.API.Models.Client", "Client")
                        .WithMany("PolicyClients")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InsurancePolicyApp.API.Models.Policy", "Policy")
                        .WithMany("PolicyClients")
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InsurancePolicyApp.API.Models.PolicyEventType", b =>
                {
                    b.HasOne("InsurancePolicyApp.API.Models.EventType", "EventType")
                        .WithMany("PolicyEventTypes")
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InsurancePolicyApp.API.Models.Policy", "Policy")
                        .WithMany("PolicyEventTypes")
                        .HasForeignKey("PolicyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("InsurancePolicyApp.API.Models.RiskType", "RiskType")
                        .WithMany("PolicyEventTypes")
                        .HasForeignKey("RiskTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
