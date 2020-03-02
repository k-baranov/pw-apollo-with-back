﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PW.DataAccess;

namespace PW.DataAccess.Migrations
{
    [DbContext(typeof(PwDbContext))]
    [Migration("20200128070659_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PW.Entities.PwTransaction", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<long?>("PayeeId")
                        .HasColumnType("bigint");

                    b.Property<long?>("RecipientId")
                        .HasColumnType("bigint");

                    b.Property<int>("ResultingPayeeBalance")
                        .HasColumnType("int");

                    b.Property<int>("ResultingRecipientBalance")
                        .HasColumnType("int");

                    b.Property<DateTime>("TransactionDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PayeeId");

                    b.HasIndex("RecipientId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("PW.Entities.PwUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Balance")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PW.Entities.PwTransaction", b =>
                {
                    b.HasOne("PW.Entities.PwUser", "Payee")
                        .WithMany("PayeeTransactions")
                        .HasForeignKey("PayeeId");

                    b.HasOne("PW.Entities.PwUser", "Recipient")
                        .WithMany("RecipientTransactions")
                        .HasForeignKey("RecipientId");
                });
#pragma warning restore 612, 618
        }
    }
}