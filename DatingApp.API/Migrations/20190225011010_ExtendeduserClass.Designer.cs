﻿// <auto-generated />
using System;
using DatingApp.API.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DatingApp.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190225011010_ExtendeduserClass")]
    partial class ExtendeduserClass
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("DatingApp.API.Models.Entity.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnName("DateAdded");

                    b.Property<string>("Description")
                        .HasColumnName("Description");

                    b.Property<string>("IsMain")
                        .HasColumnName("IsMain");

                    b.Property<string>("Url")
                        .HasColumnName("Url");

                    b.Property<int>("UserId")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("DatingApp.API.Models.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("City")
                        .HasColumnName("City");

                    b.Property<string>("Country")
                        .HasColumnName("Country");

                    b.Property<DateTime>("Created")
                        .HasColumnName("Created");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnName("DateOfBirth");

                    b.Property<string>("Gender")
                        .HasColumnName("Gender");

                    b.Property<string>("Interests")
                        .HasColumnName("Interests");

                    b.Property<string>("Introduction")
                        .HasColumnName("Introduction");

                    b.Property<string>("KnownAs")
                        .HasColumnName("KnownAs");

                    b.Property<DateTime>("LastActive")
                        .HasColumnName("LastActive");

                    b.Property<string>("LookingFor")
                        .HasColumnName("LookingFor");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnName("PasswordHash");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnName("PasswordSalt");

                    b.Property<string>("Username")
                        .HasColumnName("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DatingApp.API.Models.Entity.Value", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Values");
                });

            modelBuilder.Entity("DatingApp.API.Models.Entity.Photo", b =>
                {
                    b.HasOne("DatingApp.API.Models.Entity.User", "User")
                        .WithMany("Photos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
