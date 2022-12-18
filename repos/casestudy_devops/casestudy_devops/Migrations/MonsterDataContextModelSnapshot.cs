﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using casestudy_devops;

#nullable disable

namespace casestudydevops.Migrations
{
    [DbContext(typeof(MonsterDataContext))]
    partial class MonsterDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.1");

            modelBuilder.Entity("MonsterMove", b =>
                {
                    b.Property<int>("MonstersId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MovesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("MonstersId", "MovesId");

                    b.HasIndex("MovesId");

                    b.ToTable("MonsterMove");
                });

            modelBuilder.Entity("casestudy_devops.Entities.BattleResult", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Winner")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("BattleResults");
                });

            modelBuilder.Entity("casestudy_devops.Entities.Monster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Attack")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Defense")
                        .HasColumnType("INTEGER");

                    b.Property<int>("HP")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("TypeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Monsters");
                });

            modelBuilder.Entity("casestudy_devops.Entities.Move", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Damage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Moves");
                });

            modelBuilder.Entity("casestudy_devops.Entities.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("MonsterMove", b =>
                {
                    b.HasOne("casestudy_devops.Entities.Monster", null)
                        .WithMany()
                        .HasForeignKey("MonstersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("casestudy_devops.Entities.Move", null)
                        .WithMany()
                        .HasForeignKey("MovesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("casestudy_devops.Entities.Monster", b =>
                {
                    b.HasOne("casestudy_devops.Entities.Type", "Type")
                        .WithMany("Monsters")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("casestudy_devops.Entities.Type", b =>
                {
                    b.Navigation("Monsters");
                });
#pragma warning restore 612, 618
        }
    }
}
