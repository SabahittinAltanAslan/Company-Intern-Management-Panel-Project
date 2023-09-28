﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using stajerYonetim.Models;

#nullable disable

namespace stajerYonetim.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230728081725_mg5")]
    partial class mg5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("InternPdfRecord", b =>
                {
                    b.Property<int>("InternsInternId")
                        .HasColumnType("int");

                    b.Property<int>("PdfRecordsId")
                        .HasColumnType("int");

                    b.HasKey("InternsInternId", "PdfRecordsId");

                    b.HasIndex("PdfRecordsId");

                    b.ToTable("InternPdfRecord");
                });

            modelBuilder.Entity("stajerYonetim.Models.Admin", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AdminId"));

                    b.Property<string>("AdminName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdminSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyCompId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AdminId");

                    b.HasIndex("CompanyCompId");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("stajerYonetim.Models.Company", b =>
                {
                    b.Property<int>("CompId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompId"));

                    b.Property<string>("CompName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("stajerYonetim.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InternId")
                        .HasColumnType("int");

                    b.Property<string>("OriginalFileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InternId");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("stajerYonetim.Models.Intern", b =>
                {
                    b.Property<int>("InternId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InternId"));

                    b.Property<int>("CompId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyCompId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("InternClass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InternDepart")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InternGitHub")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InternLengues")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InternMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InternName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InternNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InternUni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InternWant")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InterntSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InternId");

                    b.HasIndex("CompanyCompId");

                    b.ToTable("Interns");
                });

            modelBuilder.Entity("stajerYonetim.Models.PdfRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("InternId")
                        .HasColumnType("int");

                    b.Property<string>("OriginalFileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PdfRecords");
                });

            modelBuilder.Entity("stajerYonetim.Models.Request", b =>
                {
                    b.Property<int>("ReqId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReqId"));

                    b.Property<int>("CompId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyCompId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReqClass")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReqDepart")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReqGitHub")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReqLengues")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReqMail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReqName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReqNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReqUni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReqWant")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReqtSurname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReqId");

                    b.HasIndex("CompanyCompId");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("InternPdfRecord", b =>
                {
                    b.HasOne("stajerYonetim.Models.Intern", null)
                        .WithMany()
                        .HasForeignKey("InternsInternId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("stajerYonetim.Models.PdfRecord", null)
                        .WithMany()
                        .HasForeignKey("PdfRecordsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("stajerYonetim.Models.Admin", b =>
                {
                    b.HasOne("stajerYonetim.Models.Company", "Company")
                        .WithMany("Admins")
                        .HasForeignKey("CompanyCompId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("stajerYonetim.Models.Document", b =>
                {
                    b.HasOne("stajerYonetim.Models.Intern", "Intern")
                        .WithMany("Documents")
                        .HasForeignKey("InternId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Intern");
                });

            modelBuilder.Entity("stajerYonetim.Models.Intern", b =>
                {
                    b.HasOne("stajerYonetim.Models.Company", "Company")
                        .WithMany("Interns")
                        .HasForeignKey("CompanyCompId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("stajerYonetim.Models.Request", b =>
                {
                    b.HasOne("stajerYonetim.Models.Company", "Company")
                        .WithMany("Requests")
                        .HasForeignKey("CompanyCompId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("stajerYonetim.Models.Company", b =>
                {
                    b.Navigation("Admins");

                    b.Navigation("Interns");

                    b.Navigation("Requests");
                });

            modelBuilder.Entity("stajerYonetim.Models.Intern", b =>
                {
                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}
