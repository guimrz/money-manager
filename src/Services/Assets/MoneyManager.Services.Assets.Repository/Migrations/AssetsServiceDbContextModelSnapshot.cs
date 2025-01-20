﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MoneyManager.Services.Assets.Repository;

#nullable disable

namespace MoneyManager.Services.Assets.Repository.Migrations
{
    [DbContext(typeof(AssetsServiceDbContext))]
    partial class AssetsServiceDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MoneyManager.Services.Assets.Domain.Asset", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.HasKey("Id");

                    b.HasIndex("CurrencyId");

                    b.ToTable("Assets", (string)null);
                });

            modelBuilder.Entity("MoneyManager.Services.Assets.Domain.Currency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.HasKey("Id");

                    b.ToTable("Currencies", (string)null);
                });

            modelBuilder.Entity("MoneyManager.Services.Assets.Domain.Transaction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AssetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<decimal>("Value")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("AssetId");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("MoneyManager.Services.Assets.Domain.Asset", b =>
                {
                    b.HasOne("MoneyManager.Services.Assets.Domain.Currency", null)
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MoneyManager.Services.Assets.Domain.Transaction", b =>
                {
                    b.HasOne("MoneyManager.Services.Assets.Domain.Asset", null)
                        .WithMany("Transactions")
                        .HasForeignKey("AssetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MoneyManager.Services.Assets.Domain.Asset", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
