﻿// <auto-generated />
using System;
using LazadaAPITest.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LazadaAPITest.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221023161911_addPropertyOfRatingInfo")]
    partial class addPropertyOfRatingInfo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("LazadaAPITest.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("LazadaAPITest.Models.CategoryInfo", b =>
                {
                    b.Property<int>("dbId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("ProductDetailId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("dbId");

                    b.HasIndex("ProductDetailId");

                    b.ToTable("CategoryInfo");
                });

            modelBuilder.Entity("LazadaAPITest.Models.DescriptionInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DescriptionInfo");
                });

            modelBuilder.Entity("LazadaAPITest.Models.ProductDetail", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Description_InfoId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("Rating_InfoId")
                        .HasColumnType("int");

                    b.Property<int?>("Shop_InfoId")
                        .HasColumnType("int");

                    b.Property<string>("Short_Description")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Description_InfoId");

                    b.HasIndex("Rating_InfoId");

                    b.HasIndex("Shop_InfoId");

                    b.ToTable("ProductDetail");
                });

            modelBuilder.Entity("LazadaAPITest.Models.ProductOverView", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("DataId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DataId");

                    b.ToTable("ProductOverView");
                });

            modelBuilder.Entity("LazadaAPITest.Models.RatingInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<float>("Percent_Star")
                        .HasColumnType("real");

                    b.Property<float>("Percent_Star1")
                        .HasColumnType("real");

                    b.Property<float>("Percent_Star2")
                        .HasColumnType("real");

                    b.Property<float>("Percent_Star3")
                        .HasColumnType("real");

                    b.Property<float>("Percent_Star4")
                        .HasColumnType("real");

                    b.Property<float>("Percent_Star5")
                        .HasColumnType("real");

                    b.Property<int>("Star1")
                        .HasColumnType("int");

                    b.Property<int>("Star2")
                        .HasColumnType("int");

                    b.Property<int>("Star3")
                        .HasColumnType("int");

                    b.Property<int>("Star4")
                        .HasColumnType("int");

                    b.Property<int>("Star5")
                        .HasColumnType("int");

                    b.Property<int>("Total_Rated")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("RatingInfo");
                });

            modelBuilder.Entity("LazadaAPITest.Models.ShopInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Phone_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Product_Total")
                        .HasColumnType("int");

                    b.Property<float>("Rating_Avg")
                        .HasColumnType("real");

                    b.Property<int>("Rating_Count")
                        .HasColumnType("int");

                    b.Property<string>("Shop_Id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Shop_Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Shop_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Warehourse_Region_Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ShopInfo");
                });

            modelBuilder.Entity("LazadaAPITest.Models.CategoryInfo", b =>
                {
                    b.HasOne("LazadaAPITest.Models.ProductDetail", null)
                        .WithMany("Category_Info")
                        .HasForeignKey("ProductDetailId");
                });

            modelBuilder.Entity("LazadaAPITest.Models.ProductDetail", b =>
                {
                    b.HasOne("LazadaAPITest.Models.DescriptionInfo", "Description_Info")
                        .WithMany()
                        .HasForeignKey("Description_InfoId");

                    b.HasOne("LazadaAPITest.Models.RatingInfo", "Rating_Info")
                        .WithMany()
                        .HasForeignKey("Rating_InfoId");

                    b.HasOne("LazadaAPITest.Models.ShopInfo", "Shop_Info")
                        .WithMany()
                        .HasForeignKey("Shop_InfoId");

                    b.Navigation("Description_Info");

                    b.Navigation("Rating_Info");

                    b.Navigation("Shop_Info");
                });

            modelBuilder.Entity("LazadaAPITest.Models.ProductOverView", b =>
                {
                    b.HasOne("LazadaAPITest.Models.ProductDetail", "Data")
                        .WithMany()
                        .HasForeignKey("DataId");

                    b.Navigation("Data");
                });

            modelBuilder.Entity("LazadaAPITest.Models.ProductDetail", b =>
                {
                    b.Navigation("Category_Info");
                });
#pragma warning restore 612, 618
        }
    }
}
