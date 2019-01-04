﻿// <auto-generated />
using System;
using Locker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Locker.Migrations
{
    [DbContext(typeof(LockerDbContext))]
    [Migration("20190104163836_InitialLocker")]
    partial class InitialLocker
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity("Locker.Models.AssignedEmployeeLockerCase", b =>
                {
                    b.Property<int>("EmployeeId");

                    b.Property<int>("LockerCaseId");

                    b.Property<int?>("EmployeeId1");

                    b.HasKey("EmployeeId", "LockerCaseId");

                    b.HasIndex("EmployeeId1");

                    b.HasIndex("LockerCaseId");

                    b.ToTable("AssignedEmployeeLockerCase");
                });

            modelBuilder.Entity("Locker.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("EmployeeName");

                    b.Property<string>("EmployeePhone");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Locker.Models.LockerCase", b =>
                {
                    b.Property<int>("LockerCaseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LockerCaseName");

                    b.HasKey("LockerCaseId");

                    b.ToTable("LockerCase");
                });

            modelBuilder.Entity("Locker.Models.AssignedEmployeeLockerCase", b =>
                {
                    b.HasOne("Locker.Models.Employee", "Employee")
                        .WithMany("AssignedEmployeeLockerCases")
                        .HasForeignKey("EmployeeId1");

                    b.HasOne("Locker.Models.LockerCase", "LockerCase")
                        .WithMany("AssignedEmployeeLockerCases")
                        .HasForeignKey("LockerCaseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
