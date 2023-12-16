﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PuppyYoga.Data;

#nullable disable

namespace PuppyYoga.Migrations
{
    [DbContext(typeof(PuppyYogaContext))]
    [Migration("20231117161044_PuppySession")]
    partial class PuppySession
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PuppyYoga.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnrollmentID"), 1L, 1);

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.Property<int?>("YogaClassID")
                        .HasColumnType("int");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("UserID");

                    b.HasIndex("YogaClassID");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("PuppyYoga.Models.Feedback", b =>
                {
                    b.Property<int>("FeedbackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeedbackId"), 1L, 1);

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("YogaClassID")
                        .HasColumnType("int");

                    b.HasKey("FeedbackId");

                    b.HasIndex("UserId");

                    b.HasIndex("YogaClassID");

                    b.ToTable("Feedback");
                });

            modelBuilder.Entity("PuppyYoga.Models.Instructor", b =>
                {
                    b.Property<int>("InstructorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InstructorId"), 1L, 1);

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InstructorId");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("PuppyYoga.Models.PuppySession", b =>
                {
                    b.Property<int>("PuppySessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PuppySessionId"), 1L, 1);

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<int>("YogaClassId")
                        .HasColumnType("int");

                    b.HasKey("PuppySessionId");

                    b.HasIndex("SessionId");

                    b.HasIndex("YogaClassId");

                    b.ToTable("PuppySession");
                });

            modelBuilder.Entity("PuppyYoga.Models.Session", b =>
                {
                    b.Property<int>("SessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SessionId"), 1L, 1);

                    b.Property<string>("SessionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SessionId");

                    b.ToTable("Session");
                });

            modelBuilder.Entity("PuppyYoga.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"), 1L, 1);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("User");
                });

            modelBuilder.Entity("PuppyYoga.Models.YogaClass", b =>
                {
                    b.Property<int>("YogaClassID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("YogaClassID"), 1L, 1);

                    b.Property<string>("ClassName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InstructorId")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MaxCapacity")
                        .HasColumnType("int");

                    b.HasKey("YogaClassID");

                    b.HasIndex("InstructorId");

                    b.ToTable("YogaClasses");
                });

            modelBuilder.Entity("PuppyYoga.Models.Enrollment", b =>
                {
                    b.HasOne("PuppyYoga.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.HasOne("PuppyYoga.Models.YogaClass", "YogaClass")
                        .WithMany("Enrollments")
                        .HasForeignKey("YogaClassID");

                    b.Navigation("User");

                    b.Navigation("YogaClass");
                });

            modelBuilder.Entity("PuppyYoga.Models.Feedback", b =>
                {
                    b.HasOne("PuppyYoga.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("PuppyYoga.Models.YogaClass", "YogaClass")
                        .WithMany()
                        .HasForeignKey("YogaClassID");

                    b.Navigation("User");

                    b.Navigation("YogaClass");
                });

            modelBuilder.Entity("PuppyYoga.Models.PuppySession", b =>
                {
                    b.HasOne("PuppyYoga.Models.Session", "Session")
                        .WithMany("PuppySessions")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PuppyYoga.Models.YogaClass", "YogaClass")
                        .WithMany("PuppySessions")
                        .HasForeignKey("YogaClassId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");

                    b.Navigation("YogaClass");
                });

            modelBuilder.Entity("PuppyYoga.Models.YogaClass", b =>
                {
                    b.HasOne("PuppyYoga.Models.Instructor", "Instructor")
                        .WithMany("YogaClasses")
                        .HasForeignKey("InstructorId");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("PuppyYoga.Models.Instructor", b =>
                {
                    b.Navigation("YogaClasses");
                });

            modelBuilder.Entity("PuppyYoga.Models.Session", b =>
                {
                    b.Navigation("PuppySessions");
                });

            modelBuilder.Entity("PuppyYoga.Models.YogaClass", b =>
                {
                    b.Navigation("Enrollments");

                    b.Navigation("PuppySessions");
                });
#pragma warning restore 612, 618
        }
    }
}
